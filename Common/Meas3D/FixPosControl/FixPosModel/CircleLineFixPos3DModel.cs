using System;
using System.Linq;
using System.Collections.Generic;
using AlgoLib;
using Vision3D;

namespace Meas3D.FixPos
{
    public class CircleLineFixPos3DModel : FixPos3DBaseModel
    {
        public Shape3DCircle ROI1 = null;

        Shape3DCircle _shapeCircle = null;

        public double MaxHeight1 = 5;

        public double MinHeight1 = 3;

        public double MaxLuminace1 = 255;

        public double MinLuminace1 = 0;

        public double MinDiameter1 = 0.6;

        public double MaxDiameter1 = 2.0;

        public double StartAngle1 = 0;

        public double EndAngle1 = 360;

        public bool IsRising1 = false;

        public bool IsFilterAgain1 = false;

        public bool IsDispLoc1 = false;

        public int Direction1 = 0;

        private List<double[]> _edgePoints1 = new List<double[]>();

        private List<Shape3DPoint> _shapePoints1 = new List<Shape3DPoint>();

        private double[] _circle;

        public List<Shape3DRect> _ROIs2 = new List<Shape3DRect>();

        Shape3DLine _shapeLine = null;

        public double MaxHeight2 = 5;

        public double MinHeight2 = 3;

        public double MaxLuminace2 = 255;

        public double MinLuminace2 = 0;

        public double MinDiameter2 = 0.6;

        public double MaxDiameter2 = 2.0;

        public double StartAngle2 = 0;

        public double EndAngle2 = 360;

        public bool IsRising2 = false;

        public bool IsDispLoc2 = false;

        public int Direction2 = 0;

        private List<double[]> _edgePoints2 = new List<double[]>();

        private List<Shape3DPoint> _shapePoints2 = new List<Shape3DPoint>();

        private double[] _line;

        public double RotateAngle = 15.599;

        public CircleLineFixPos3DModel()
        {
            ROI1 = new Shape3DCircle() { Color = "blue" };
            _shapeCircle = new Shape3DCircle() { IsEditable = false };
            _shapeLine = new Shape3DLine() { IsEditable = false };
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
            Shape3DRect ROI = new Shape3DRect() { Color = "blue" };
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
            Shape3DRect ROI = _ROIs2.Last();
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
                if (_matrix3D == null) return;
                _circle = Algo3D.FitCircle(_matrix3D, (int)ROI1.Col, (int)ROI1.Row, (int)ROI1.Radius, MinDiameter1, MaxDiameter1, StartAngle1, EndAngle1, 0.5, Direction1, IsRising1,
                                                   IsFilterAgain1, MinLuminace1, MaxLuminace1, MinHeight1, MaxHeight1, out float[] newX1, out float[] newY1);
                _edgePoints1.Clear();
                for (int i = 0; i < newX1.Length; i++)
                    _edgePoints1.Add(new double[2] { newX1[i], newY1[i] });

                List<double> xList2 = new List<double>();
                List<double> yList2 = new List<double>();
                foreach (var ROI in _ROIs2)
                {
                    Algo3D.GetLineContour(_matrix3D, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinLuminace2, MaxLuminace2, MinHeight2, MaxHeight2, Direction2, IsRising2, out double[] X2, out double[] Y2);
                    xList2.AddRange(X2);
                    yList2.AddRange(Y2);
                }
                _edgePoints2.Clear();
                Algo3D.GetFitLine(xList2.ToArray(), yList2.ToArray(), out _line, out double[] newX, out double[] newY, 0.01);
                if (newX == null || newY == null)
                    return;
                for (int i = 0; i < newX.Length; i++)
                    _edgePoints2.Add(new double[2] { newX[i], newY[i] });
                if (_circle == null || _line == null)
                    return;
                X = _circle[0];
                Y = _circle[1];
                Angle = Math.Atan(-(_line[0] / _line[1])) * 180 / Math.PI;
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
            if (_matrix3D == null) return;
            if (_shapePoints1.Count != 0)
            {
                foreach (Shape3DPoint point in _shapePoints1)
                {
                    OnRemoveShape?.Invoke(point);
                }
                _shapePoints1.Clear();
            }
            if (IsDispLoc1)
            {
                foreach (double[] point in _edgePoints1)
                {
                    Shape3DPoint Shape3DPoint = new Shape3DPoint();
                    _shapePoints1.Add(Shape3DPoint);
                    OnAddShape?.Invoke(Shape3DPoint);
                    Shape3DPoint.SetShape(point[0], point[1]);
                }
            }
            if (_shapePoints2.Count != 0)
            {
                foreach (Shape3DPoint point in _shapePoints2)
                {
                    OnRemoveShape?.Invoke(point);
                }
                _shapePoints2.Clear();
            }
            if (IsDispLoc2)
            {
                foreach (double[] point in _edgePoints2)
                {
                    Shape3DPoint Shape3DPoint = new Shape3DPoint();
                    _shapePoints2.Add(Shape3DPoint);
                    OnAddShape?.Invoke(Shape3DPoint);
                    Shape3DPoint.SetShape(point[0], point[1]);
                }
            }
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
                double endY = _matrix3D.Row * _matrix3D.Pitch;
                double endX = (-(_line[1] * endY) - _line[2]) / _line[0];
                _shapeLine.SetShape(startX, startY, endX, endY);
            }
            OnRepaint?.Invoke();
        }

        public override void OpenSetupView()
        {
            SetupView = new CircleLineFixPos3DView(this);
            base.OpenSetupView();
        }

        public override void DeleteFixPos()
        {
            if (_shapePoints1.Count != 0)
            {
                foreach (Shape3DPoint point in _shapePoints1)
                    OnRemoveShape?.Invoke(point);
                _shapePoints1.Clear();
            }
            if (_shapePoints2.Count != 0)
            {
                foreach (Shape3DPoint point in _shapePoints2)
                    OnRemoveShape?.Invoke(point);
                _shapePoints2.Clear();
            }
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
