using System;
using System.Collections.Generic;
using AlgoLib;
using Vision2D;
using System.Linq;

namespace Meas2D.FixPos
{
    public class LinesFixPos2DModel : FixPos2DBaseModel
    {
        public List<Shape2DRect> ROIs1 = new List<Shape2DRect>();

        Shape2DLine _shapeLine1 = null;

        public double MaxGray1 = 255;

        public double MinGray1 = 150;

        public int Direction1 = 2;

        public bool IsRising1 = false;

        public bool IsFilterAgain1 = false;

        public bool IsDispLoc1 = false;

        private List<double[]> _edgePoints1 = new List<double[]>();

        private double[] _line1;

        public List<Shape2DRect> ROIs2 = new List<Shape2DRect>();

        Shape2DLine _shapeLine2 = null;

        public double MaxGray2 = 255;

        public double MinGray2 = 150;

        public int Direction2 = 0;

        public bool IsRising2 = false;

        public bool IsFilterAgain2 = false;

        public bool IsDispLoc2 = false;

        private List<double[]> _edgePoints2 = new List<double[]>();

        private double[] _line2;

        public double RotateAngle = 15.599;

        public LinesFixPos2DModel()
        {
            _shapeLine1 = new Shape2DLine() { IsEditable = false };
            _shapeLine2 = new Shape2DLine() { IsEditable = false };
            SetupView = new LinesFixPos2DView(this);
        }

        public override void InitShape()
        {
            foreach (Shape2DRect ROI in ROIs1)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved += UpdatePos;
                ROI.OnMoved += UpdateShape;
            }
            foreach (Shape2DRect ROI in ROIs2)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved += UpdatePos;
                ROI.OnMoved += UpdateShape;
            }
            OnAddShape?.Invoke(_shapeLine1);
            OnAddShape?.Invoke(_shapeLine2);
            OnRepaint?.Invoke();
        }

        public void AddROI1()
        {
            Shape2DRect ROI = new Shape2DRect() { Color = "blue" };
            ROIs1.Add(ROI);
            OnAddShape(ROI);
            ROI.OnMoved += UpdatePos;
            ROI.OnMoved += UpdateShape;
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void RemoveROI1()
        {
            Shape2DRect ROI = ROIs1.Last();
            ROIs1.Remove(ROI);
            OnRemoveShape(ROI);
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void AddROI2()
        {
            Shape2DRect ROI = new Shape2DRect() { Color = "blue" };
            ROIs2.Add(ROI);
            OnAddShape(ROI);
            ROI.OnMoved += UpdatePos;
            ROI.OnMoved += UpdateShape;
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void RemoveROI2()
        {
            Shape2DRect ROI = ROIs2.Last();
            ROIs2.Remove(ROI);
            OnRemoveShape(ROI);
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public override void UpdatePos()
        {
            try
            {
                if (_image == null) return;
                List<int> xList1 = new List<int>();
                List<int> yList1 = new List<int>();
                foreach (var ROI in ROIs1)
                {
                    Algo2D.GetLineContour(_image, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinGray1, MaxGray1, Direction1, IsRising1, out int[] Rows1, out int[] Cols1);
                    xList1.AddRange(Cols1);
                    yList1.AddRange(Rows1);
                }
                _line1 = Algo2D.FitLine(xList1.ToArray(), yList1.ToArray());
                List<int> xList2 = new List<int>();
                List<int> yList2 = new List<int>();
                foreach (var ROI in ROIs2)
                {
                    Algo2D.GetLineContour(_image, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinGray2, MaxGray2, Direction2, IsRising2, out int[] Rows2, out int[] Cols2);
                    xList2.AddRange(Cols2);
                    yList2.AddRange(Rows2);
                }
                _line2 = Algo2D.FitLine(xList2.ToArray(), yList2.ToArray());
                if (_line1 == null || _line2 == null)
                    return;
                Column = (_line1[1] * _line2[2] - _line2[1] * _line1[2]) / (_line1[0] * _line2[1] - _line2[0] * _line1[1]);
                Row = (_line2[0] * _line1[2] - _line1[0] * _line2[2]) / (_line1[0] * _line2[1] - _line2[0] * _line1[1]);
                Angle = Math.Atan(-_line2[0] / _line2[1]) * 180 / Math.PI;
                Angle = Angle > 0 ? Angle : 180 + Angle;
                XAxis = _line1;
                YAxis = _line2;
            }
            catch (Exception ex)
            {
                throw new Exception("线线定位发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            if (_image == null) return;
            _image.GetImageSize(out int width, out int height);
            if (_line1 == null)
                _shapeLine1.IsVisible = false;
            else
            {
                _shapeLine1.IsVisible = true;
                double startX = 0;
                double startY = (-(_line1[0] * startX) - _line1[2]) / _line1[1];
                double endX = width;
                double endY = (-(_line1[0] * endX) - _line1[2]) / _line1[1];
                _shapeLine1.SetShape(startY, startX, endY, endX);
            }
            if (_line2 == null)
                _shapeLine2.IsVisible = false;
            else
            {
                _shapeLine2.IsVisible = true;
                double startY = 0;
                double startX = (-(_line2[1] * startY) - _line2[2]) / _line2[0];
                double endY = height;
                double endX = (-(_line2[1] * endY) - _line2[2]) / _line2[0];
                _shapeLine2.SetShape(startY, startX, endY, endX);
            }
            OnRepaint?.Invoke();
        }

        public override void OpenSetupView()
        {
            base.OpenSetupView();
        }

        public override void DeleteFixPos()
        {
            foreach (var ROI in ROIs1)
                OnRemoveShape?.Invoke(ROI);
            foreach (var ROI in ROIs2)
                OnRemoveShape?.Invoke(ROI);
            OnRemoveShape?.Invoke(_shapeLine1);
            OnRemoveShape?.Invoke(_shapeLine2);
            OnRepaint?.Invoke();
            base.DeleteFixPos();
        }

        public override void EnableFixPos()
        {
            foreach (var ROI in ROIs1)
                ROI.IsEditable = false;
            foreach (var ROI in ROIs2)
                ROI.IsEditable = false;
            base.EnableFixPos();
            OnRepaint?.Invoke();
        }

        public override void DisableFixPos()
        {
            foreach (var ROI in ROIs1)
                ROI.IsEditable = true;
            foreach (var ROI in ROIs2)
                ROI.IsEditable = true;
            base.DisableFixPos();
            OnRepaint?.Invoke();
        }
    }
}
