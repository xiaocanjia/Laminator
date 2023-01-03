using System;
using System.Collections.Generic;
using AlgoLib;
using Vision3D;
using System.Linq;

namespace Meas3D.FixPos
{
    public class LinesFixPos3DModel : FixPos3DBaseModel
    {
        public List<Shape3DRect> ROIs1 = new List<Shape3DRect>();

        Shape3DLine _shapeLine1 = null;

        public double MaxHeight1 = 5;

        public double MinHeight1 = 3;

        public double MaxLuminace1 = 255;

        public double MinLuminace1 = 0;

        public int Direction1 = 2;

        public double StartAngle1 = 0;

        public double EndAngle1 = 360;

        public bool IsRising1 = false;

        public bool IsFilterAgain1 = false;

        public bool IsDispLoc1 = false;

        private List<double[]> _edgePoints1 = new List<double[]>();

        private List<Shape3DPoint> _shapePoints1 = new List<Shape3DPoint>();

        private double[] _line1;

        public List<Shape3DRect> ROIs2 = new List<Shape3DRect>();

        Shape3DLine _shapeLine2 = null;

        public double MaxHeight2 = 5;

        public double MinHeight2 = 3;

        public double MaxLuminace2 = 255;

        public double MinLuminace2 = 0;

        public int Direction2 = 0;

        public double StartAngle2 = 0;

        public double EndAngle2 = 360;

        public bool IsRising2 = false;

        public bool IsFilterAgain2 = false;

        public bool IsDispLoc2 = false;

        private List<double[]> _edgePoints2 = new List<double[]>();

        private List<Shape3DPoint> _shapePoints2 = new List<Shape3DPoint>();

        private double[] _line2;

        public double RotateAngle = 15.599;

        public LinesFixPos3DModel()
        {
            _shapeLine1 = new Shape3DLine() { IsEditable = false };
            _shapeLine2 = new Shape3DLine() { IsEditable = false };
            SetupView = new LinesFixPos3DView(this);
        }

        public override void InitShape()
        {
            foreach (Shape3DRect ROI in ROIs1)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved += UpdatePos;
                ROI.OnMoved += UpdateShape;
            }
            foreach (Shape3DRect ROI in ROIs2)
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
            Shape3DRect ROI = new Shape3DRect() { Color = "blue" };
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
            Shape3DRect ROI = ROIs1.Last();
            ROIs1.Remove(ROI);
            OnRemoveShape(ROI);
            UpdatePos();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public void AddROI2()
        {
            Shape3DRect ROI = new Shape3DRect() { Color = "blue" };
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
            Shape3DRect ROI = ROIs2.Last();
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
                if (_matrix3D == null) return;
                List<double> xList1 = new List<double>();
                List<double> yList1 = new List<double>();
                foreach (var ROI in ROIs1)
                {
                    Algo3D.GetLineContour(_matrix3D, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinLuminace1, MaxLuminace1, MinHeight1, MaxHeight1, Direction1, IsRising1, out double[] X1, out double[] Y1);
                    xList1.AddRange(X1);
                    yList1.AddRange(Y1);
                }
                _edgePoints1.Clear();
                for (int i = 0; i < xList1.Count; i++)
                    _edgePoints1.Add(new double[2] { xList1[i], yList1[i] });
                Algo3D.GetFitLine(xList1.ToArray(), yList1.ToArray(), out _line1, out double[] newX, out double[] newY);
                List<double> xList2 = new List<double>();
                List<double> yList2 = new List<double>();
                foreach (var ROI in ROIs2)
                {
                    Algo3D.GetLineContour(_matrix3D, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinLuminace2, MaxLuminace2, MinHeight2, MaxHeight2, Direction2, IsRising2, out double[] X2, out double[] Y2);
                    xList2.AddRange(X2);
                    yList2.AddRange(Y2);
                }
                _edgePoints2.Clear();
                for (int i = 0; i < xList2.Count; i++)
                    _edgePoints2.Add(new double[2] { xList2[i], yList2[i] });
                Algo3D.GetFitLine(xList2.ToArray(), yList2.ToArray(), out _line2, out newX, out newY);
                if (_line1 == null || _line2 == null)
                    return;
                X = (_line1[1] * _line2[2] - _line2[1] * _line1[2]) / (_line1[0] * _line2[1] - _line2[0] * _line1[1]);
                Y = (_line2[0] * _line1[2] - _line1[0] * _line2[2]) / (_line1[0] * _line2[1] - _line2[0] * _line1[1]);
                Angle = Math.Atan(_line2[1]) * 180 / Math.PI;
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
            if (_line1 == null)
                _shapeLine1.IsVisible = false;
            else
            {
                _shapeLine1.IsVisible = true;
                double startX = 0;
                double startY = (-(_line1[0] * startX) - _line1[2]) / _line1[1];
                double endX = _matrix3D.Column * _matrix3D.Pitch;
                double endY = (-(_line1[0] * endX) - _line1[2]) / _line1[1];
                _shapeLine1.SetShape(startX, startY, endX, endY);
            }
            if (_line2 == null)
                _shapeLine2.IsVisible = false;
            else
            {
                _shapeLine2.IsVisible = true;
                double startY = 0;
                double startX = (-(_line2[1] * startY) - _line2[2]) / _line2[0];
                double endY = _matrix3D.Row * _matrix3D.Pitch;
                double endX = (-(_line2[1] * endY) - _line2[2]) / _line2[0];
                _shapeLine2.SetShape(startX, startY, endX, endY);
            }
            OnRepaint?.Invoke();
        }

        public override void OpenSetupView()
        {
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
