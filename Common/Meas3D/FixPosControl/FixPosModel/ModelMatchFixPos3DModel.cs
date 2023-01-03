using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using HalconDotNet;
using Vision3D;
using System.Runtime.InteropServices;

namespace Meas3D.FixPos
{
    public class ModelMatchFixPos3DModel : FixPos3DBaseModel
    {
        public List<Shape3DRect> ROIs = new List<Shape3DRect>();

        private HShapeModel _model = null;

        public int PyramidLevels = 0;
        
        public ModelMatchFixPos3DModel()
        {
            SetupView = new ModelMatchFixPos3DView(this);
        }

        public override void InitShape()
        {
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}model.shm"))
                _model = new HShapeModel($"{AppDomain.CurrentDomain.BaseDirectory}model.shm");
            foreach (Shape3DRect ROI in ROIs)
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
            Shape3DRect ROI = new Shape3DRect() { Color = "blue" };
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
            Shape3DRect ROI = ROIs.Last();
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
                if (_matrix3D == null) return;
                HRegion regions = ROIs[0].GetRegion();
                for (int i = 1; i < ROIs.Count; i++)
                    regions = regions.Union2(ROIs[i].GetRegion());
                regions.AreaCenter(out double row, out double column);
                HImage imageZ = _matrix3D.GetImageZ();
                double mult = 255.0 / (_matrix3D.GetMaxHeight() - _matrix3D.GetMinHeight());
                double add = 0 - mult * _matrix3D.GetMinHeight();
                imageZ = imageZ.ScaleImage(mult, add);
                imageZ = imageZ.ConvertImageType("byte");
                X = column * _matrix3D.Pitch;
                Y = row * _matrix3D.Pitch;
                Angle = 0;

                HImage imgReduced = imageZ.ReduceDomain(regions);
                _model = new HShapeModel(imgReduced, 5, 0, 2 * Math.PI, 0.1 * Math.PI / 180.0, "auto", "use_polarity", "auto", "auto");
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
                if (_matrix3D == null) return;
                HImage imageZ = _matrix3D.GetImageZ();
                double mult = 255.0 / (_matrix3D.GetMaxHeight() - _matrix3D.GetMinHeight());
                double add = 0 - mult * _matrix3D.GetMinHeight();
                imageZ = imageZ.ScaleImage(mult, add);
                imageZ = imageZ.ConvertImageType("byte");
                if (_model == null) return;
                _model.FindShapeModel(imageZ, 0, 2 * Math.PI, 0.05, 1, 0.5, "least_squares", 5, 0.5, out HTuple row, out HTuple col, out HTuple angle, out HTuple score);
                X = col[0] * _matrix3D.Pitch;
                Y = row[0] * _matrix3D.Pitch;
                Angle = (angle[0].D > Math.PI ? 2 * Math.PI - angle[0].D : -angle[0].D) * 180 / Math.PI;
            }
            catch (Exception ex)
            {
                throw new Exception("模板匹配发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            if (_matrix3D == null) return;
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
