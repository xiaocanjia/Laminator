using System;
using System.Collections.Generic;
using Vision3D;
using AlgoLib;

namespace Meas3D.FixPos
{
    public class CirclesFixPos3DModel : FixPos3DBaseModel
    {
        public Shape3DCircle ROI1 = null;

        Shape3DCircle _shapeCircle1 = null;

        public double MaxHeight1 = 5;

        public double MinHeight1 = 3;

        public double MaxLuminace1 = 255;

        public double MinLuminace1 = 0;

        public double MinDiameter1 = 0.6;

        public double MaxDiameter1 = 2.0;

        public double StartAngle1 = 0;

        public double EndAngle1 = 360;

        public bool IsRising1 = false;

        public int Dir1 = 0;

        public bool IsFilterAgain1 = false;

        public bool IsDispLoc1 = false;

        private List<double[]> _edgePoints1 = new List<double[]>();

        private List<Shape3DPoint> _shapePoints1 = new List<Shape3DPoint>();

        private double[] _circle1;

        public Shape3DCircle ROI2 = null;

        Shape3DCircle _shapeCircle2 = null;

        public double MaxHeight2 = 5;

        public double MinHeight2 = 3;

        public double MaxLuminace2 = 255;

        public double MinLuminace2 = 0;

        public double MinDiameter2 = 0.6;

        public double MaxDiameter2 = 2.0;

        public double StartAngle2 = 0;

        public double EndAngle2 = 360;

        public bool IsRising2 = false;

        public int Dir2 = 0;

        public bool IsFilterAgain2 = false;

        public bool IsDispLoc2 = false;

        private List<double[]> _edgePoints2 = new List<double[]>();

        private List<Shape3DPoint> _shapePoints2 = new List<Shape3DPoint>();

        private double[] _circle2;

        public double RotateAngle = 0;

        public CirclesFixPos3DModel()
        {
            ROI1 = new Shape3DCircle() { Color = "blue" };
            _shapeCircle1 = new Shape3DCircle() { IsEditable = false };
            ROI2 = new Shape3DCircle() { Color = "blue" };
            _shapeCircle2 = new Shape3DCircle() { IsEditable = false };
            SetupView = new CirclesFixPos3DView(this);
        }

        public override void InitShape()
        {
            OnAddShape?.Invoke(ROI1);
            ROI1.OnMoved += UpdatePos;
            ROI1.OnMoved += UpdateShape;
            OnAddShape?.Invoke(_shapeCircle1);
            OnAddShape?.Invoke(ROI2);
            ROI2.OnMoved += UpdatePos;
            ROI2.OnMoved += UpdateShape;
            OnAddShape?.Invoke(_shapeCircle2);
            OnRepaint?.Invoke();
        }

        public override void UpdatePos()
        {
            try
            {
                if (_matrix3D == null) return;
                _circle1 = Algo3D.FitCircle(_matrix3D, (int)ROI1.Col, (int)ROI1.Row, (int)ROI1.Radius, MinDiameter1, MaxDiameter1, StartAngle1, EndAngle1, 0.5, Dir1, IsRising1,
                                                   IsFilterAgain1, MinLuminace1, MaxLuminace1, MinHeight1, MaxHeight1, out float[] newX1, out float[] newY1);
                _edgePoints1.Clear();
                for (int i = 0; i < newX1.Length; i++)
                    _edgePoints1.Add(new double[2] { newX1[i], newY1[i] });
                _circle2 = Algo3D.FitCircle(_matrix3D, (int)ROI2.Col, (int)ROI2.Row, (int)ROI2.Radius, MinDiameter2, MaxDiameter2, StartAngle2, EndAngle2, 0.5, Dir2, IsRising2,
                                                   IsFilterAgain2, MinLuminace2, MaxLuminace2, MinHeight2, MaxHeight2, out float[] newX2, out float[] newY2);
                _edgePoints2.Clear();
                for (int i = 0; i < newX2.Length; i++)
                    _edgePoints2.Add(new double[2] { newX2[i], newY2[i] });
                if (_circle1 == null || _circle2 == null)
                    return;
                X = _circle1[0];
                Y = _circle1[1];
                Angle = Math.Atan((_circle2[1] - _circle1[1]) / (_circle2[0] - _circle1[0])) * 180 / Math.PI;
                double x = _circle2[0];
                double y = _circle2[1];
                double dx = _circle1[0];
                double dy = _circle1[1];
                //一个点(x,y)绕任意点(dx,dy)顺时针旋转a度后的坐标
                double x1 = (x - dx) * Math.Cos(RotateAngle * Math.PI / 180) - (y - dy) * Math.Sin(RotateAngle * Math.PI / 180) + dx;
                double y1 = (x - dx) * Math.Sin(RotateAngle * Math.PI / 180) + (y - dy) * Math.Cos(RotateAngle * Math.PI / 180) + dy;
                Algo3D.GetFitLine(new double[2] { x1, dx }, new double[2] { y1, dy }, out YAxis, out double[] newX, out double[] newY);
                double x2 = (x - dx) * Math.Cos((RotateAngle + 90) * Math.PI / 180) - (y - dy) * Math.Sin((RotateAngle + 90) * Math.PI / 180) + dx;
                double y2 = (x - dx) * Math.Sin((RotateAngle + 90) * Math.PI / 180) + (y - dy) * Math.Cos((RotateAngle + 90) * Math.PI / 180) + dy;
                Algo3D.GetFitLine(new double[2] { x2, dx }, new double[2] { y2, dy }, out XAxis, out newX, out newY);
            }
            catch (Exception ex)
            {
                throw new Exception("圆圆定位发生异常" + ex.Message);
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
            if (_circle1 == null)
                _shapeCircle1.IsVisible = false;
            else
            {
                _shapeCircle1.IsVisible = true;
                _shapeCircle1.SetShape(_circle1[0], _circle1[1], _circle1[2]);
            }
            if (_circle2 == null)
                _shapeCircle2.IsVisible = false;
            else
            {
                _shapeCircle2.IsVisible = true;
                _shapeCircle2.SetShape(_circle2[0], _circle2[1], _circle2[2]);
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
            OnRemoveShape?.Invoke(ROI1);
            OnRemoveShape?.Invoke(ROI2);
            OnRemoveShape?.Invoke(_shapeCircle1);
            OnRemoveShape?.Invoke(_shapeCircle2);
            OnRepaint?.Invoke();
            base.DeleteFixPos();
        }

        public override void EnableFixPos()
        {
            ROI1.IsEditable = false;
            ROI2.IsEditable = false;
            base.EnableFixPos();
            OnRepaint?.Invoke();
        }

        public override void DisableFixPos()
        {
            ROI1.IsEditable = true;
            ROI2.IsEditable = true;
            base.DisableFixPos();
            OnRepaint?.Invoke();
        }
    }
}
