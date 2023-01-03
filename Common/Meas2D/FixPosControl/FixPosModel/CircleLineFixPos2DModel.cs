using System;
using System.Linq;
using System.Collections.Generic;
using AlgoLib;
using Vision2D;

namespace Meas2D.FixPos
{
    public class CircleLineFixPos2DModel : FixPos2DBaseModel
    {
        public Shape2DRect ROI1 = null;

        Shape2DCircle _shapeCircle = null;

        public double MinGray1 = 200;

        public double MaxGray1 = 255;

        public double MinArea = 0;

        public double MaxArea = 999999;

        private double[] _circle;

        public List<Shape2DRect> _ROIs2 = new List<Shape2DRect>();

        Shape2DLine _shapeLine = null;

        public double MinGray2 = 80;

        public double MaxGray2 = 255;

        public double StartAngle2 = 0;

        public double EndAngle2 = 360;

        public bool IsRising2 = false;

        public bool IsDispLoc2 = false;

        public int Direction2 = 0;

        private List<double[]> _edgePoints2 = new List<double[]>();

        private double[] _line;

        public double RotateAngle = 15.599;

        public CircleLineFixPos2DModel()
        {
            ROI1 = new Shape2DRect() { Color = "blue" };
            _shapeCircle = new Shape2DCircle() { Color = "red", IsEditable = false };
            _shapeLine = new Shape2DLine() { Color = "green", IsEditable = false };
        }

        public override void InitShape()
        {
            OnAddShape?.Invoke(ROI1);
            ROI1.OnMoved += UpdatePos;
            ROI1.OnMoved += UpdateShape;
            OnAddShape?.Invoke(_shapeCircle);
            foreach (var ROI in _ROIs2)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved += UpdatePos;
                ROI.OnMoved += UpdateShape;
            }
            OnAddShape?.Invoke(_shapeLine);
            OnRepaint?.Invoke();
        }

        public void AddROI2()
        {
            if (IsEnable) return;
            Shape2DRect ROI = new Shape2DRect() { Color = "blue" };
            _ROIs2.Add(ROI);
            OnAddShape(ROI);
            ROI.OnMoved += UpdatePos;
            ROI.OnMoved += UpdateShape;
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void RemoveROI2()
        {
            if (IsEnable) return;
            Shape2DRect ROI = _ROIs2.Last();
            _ROIs2.Remove(ROI);
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
                _circle = Algo2D.FitCircle(_image, ROI1.GetRegion(), MinGray1, MaxGray1, MinArea, MaxArea);
                List<int> xList2 = new List<int>();
                List<int> yList2 = new List<int>();
                foreach (var ROI in _ROIs2)
                {
                    Algo2D.GetLineContour(_image, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinGray2, MaxGray2, Direction2, IsRising2, out int[] Rows, out int[] Cols);
                    xList2.AddRange(Cols);
                    yList2.AddRange(Rows);
                }
                _edgePoints2.Clear();
                _line = Algo2D.FitLine(xList2.ToArray(), yList2.ToArray());
                if (_circle == null || _line == null)
                    return;
                Row = _circle[0];
                Column = _circle[1];
                Angle = Math.Atan(-(_line[0] / _line[1])) * 180 / Math.PI;
                Angle = Angle > 0 ? Angle : 180 + Angle;
                XAxis = new double[3] { 0, 0, 0 };
                XAxis[0] = -_line[1];
                XAxis[1] = _line[0];
                XAxis[2] = _circle[0] * _line[1] - _circle[1] * _line[0];
                YAxis = new double[3] { 0, 0, 0 };
                YAxis[0] = _line[0];
                YAxis[1] = _line[1];
                YAxis[2] = -(_circle[0] * _line[0] + _circle[1] * _line[1]);
            }
            catch (Exception ex)
            {
                throw new Exception("圆线定位发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            if (_image == null) return;
            if (_circle == null)
                _shapeCircle.IsVisible = false;
            else
            {
                _shapeCircle.IsVisible = true;
                _shapeCircle.SetShape(_circle[0], _circle[1], _circle[2]);
            }
            if (_line == null)
                _shapeLine.IsVisible = false;
            else
            {
                _shapeLine.IsVisible = true;
                double startY = 0;
                double startX = (-(_line[1] * startY) - _line[2]) / _line[0];
                _image.GetImageSize(out int width, out int height);
                double endY = height;
                double endX = (-(_line[1] * endY) - _line[2]) / _line[0];
                _shapeLine.SetShape(startY, startX, endY, endX);
            }
            OnRepaint?.Invoke();
        }

        public override void OpenSetupView()
        {
            SetupView = new CircleLineFixPos2DView(this);
            base.OpenSetupView();
        }

        public override void DeleteFixPos()
        {
            OnRemoveShape?.Invoke(ROI1);
            foreach (var ROI in _ROIs2)
                OnRemoveShape?.Invoke(ROI);
            OnRemoveShape?.Invoke(_shapeCircle);
            OnRemoveShape?.Invoke(_shapeLine);
            OnRepaint?.Invoke();
            base.DeleteFixPos();
        }

        public override void EnableFixPos()
        {
            ROI1.IsEditable = false;
            foreach (var ROI in _ROIs2)
                ROI.IsEditable = false;
            base.EnableFixPos();
            OnRepaint?.Invoke();
        }

        public override void DisableFixPos()
        {
            ROI1.IsEditable = true;
            foreach (var ROI in _ROIs2)
                ROI.IsEditable = true;
            base.DisableFixPos();
            OnRepaint?.Invoke();
        }
    }
}
