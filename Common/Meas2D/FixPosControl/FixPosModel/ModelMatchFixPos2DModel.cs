using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using HalconDotNet;
using Vision2D;
using System.Runtime.InteropServices;

namespace Meas2D.FixPos
{
    public class ModelMatchFixPos2DModel : FixPos2DBaseModel
    {
        public List<Shape2DRect> ROIs = new List<Shape2DRect>();

        private HShapeModel _model = null;

        public int PyramidLevels = 0;

        public ModelMatchFixPos2DModel()
        {
            SetupView = new ModelMatchFixPos2DView(this);
        }

        public override void InitShape()
        {
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}model.shm"))
                _model = new HShapeModel($"{AppDomain.CurrentDomain.BaseDirectory}model.shm");
            foreach (Shape2DRect ROI in ROIs)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved += UpdatePos;
                ROI.OnMoved += UpdateShape;
            }
            OnRepaint?.Invoke();
        }

        public void AddROI()
        {
            Shape2DRect ROI = new Shape2DRect() { Color = "blue" };
            ROIs.Add(ROI);
            OnAddShape(ROI);
            ROI.OnMoved += UpdatePos;
            ROI.OnMoved += UpdateShape;
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void RemoveROI()
        {
            if (ROIs.Count == 0)
                return;
            Shape2DRect ROI = ROIs.Last();
            ROIs.Remove(ROI);
            OnRemoveShape(ROI);
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void CreateModel()
        {
            try
            {
                if (_image == null) return;
                HRegion regions = ROIs[0].GetRegion();
                for (int i = 1; i < ROIs.Count; i++)
                    regions = regions.Union2(ROIs[i].GetRegion());
                regions.AreaCenter(out Row, out Column);
                Angle = 0;
                HImage imgReduced = _image.ReduceDomain(regions);
                _model = new HShapeModel(imgReduced, 7, 0, 2 * Math.PI, 0.1 * Math.PI / 180.0, "point_reduction_high", "use_polarity", "auto", "auto");
                //_model.WriteShapeModel($"{AppDomain.CurrentDomain.BaseDirectory}model.shm");
            }
            catch (Exception ex)
            {
                throw new Exception("模板匹配发生异常" + ex.Message);
            }
        }

        public override void UpdatePos()
        {
            try
            {
                if (_image == null || _model == null) return;
                _model.FindShapeModel(_image, 0, 2 * Math.PI, 0.7, 0, 0.5, "least_squares", 5, 0.9, out HTuple row, out HTuple col, out HTuple angle, out HTuple score);
                Row = row[0];
                Column = col[0];
                Angle = (angle[0].D > Math.PI ? 2 * Math.PI - angle[0].D : -angle[0].D) * 180 / Math.PI;
            }
            catch (Exception ex)
            {
                throw new Exception("模板匹配发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            if (_image == null) return;
            OnRepaint?.Invoke();
        }

        public override void OpenSetupView()
        {
            base.OpenSetupView();
        }

        public override void DeleteFixPos()
        {
            File.Delete($"{AppDomain.CurrentDomain.BaseDirectory}model.shm");
            foreach (var ROI in ROIs)
                OnRemoveShape?.Invoke(ROI);
            OnRepaint?.Invoke();
            base.DeleteFixPos();
        }

        public override void EnableFixPos()
        {
            foreach (var ROI in ROIs)
                ROI.IsEditable = false;
            CreateModel();
            base.EnableFixPos();
            OnRepaint?.Invoke();
        }

        public override void DisableFixPos()
        {
            foreach (var ROI in ROIs)
                ROI.IsEditable = true;
            base.DisableFixPos();
            OnRepaint?.Invoke();
        }
    }
}
