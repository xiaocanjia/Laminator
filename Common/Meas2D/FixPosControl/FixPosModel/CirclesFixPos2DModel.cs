using System;
using System.Collections.Generic;
using AlgoLib;
using Vision2D;

namespace Meas2D.FixPos
{
    public class CirclesFixPos2DModel : FixPos2DBaseModel
    {
        public Shape2DRect ROI1 = null;

        Shape2DCircle _shapeCircle1 = null;

        public double MaxGray1 = 255;

        public double MinGray1 = 200;

        public double MaxArea1 = 999999;

        public double MinArea1 = 0;

        public double MinDiameter1 = 0.6;

        public double MaxDiameter1 = 2.0;

        public double StartAngle1 = 0;

        public double EndAngle1 = 360;

        public bool IsRising1 = false;

        public int Dir1 = 0;

        public bool IsFilterAgain1 = false;

        public bool IsDispLoc1 = false;

        private List<double[]> _edgePoints1 = new List<double[]>();

        private List<Shape2DPoint> _shapePoints1 = new List<Shape2DPoint>();

        private double[] _circle1;

        public Shape2DRect ROI2 = null;

        Shape2DCircle _shapeCircle2 = null;

        public double MaxGray2 = 255;

        public double MinGray2 = 200;

        public double MaxArea2 = 999999;

        public double MinArea2 = 0;

        public double StartAngle2 = 0;

        public double EndAngle2 = 360;

        public bool IsRising2 = false;

        public int Dir2 = 0;

        public bool IsFilterAgain2 = false;

        public bool IsDispLoc2 = false;

        private List<double[]> _edgePoints2 = new List<double[]>();

        private List<Shape2DPoint> _shapePoints2 = new List<Shape2DPoint>();

        private double[] _circle2;

        public double RotateAngle = 0;

        public CirclesFixPos2DModel()
        {
            ROI1 = new Shape2DRect() { Color = "blue" };
            _shapeCircle1 = new Shape2DCircle() { IsEditable = false };
            ROI2 = new Shape2DRect() { Color = "blue" };
            _shapeCircle2 = new Shape2DCircle() { IsEditable = false };
            SetupView = new CirclesFixPos2DView(this);
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
                if (_image == null) return;
                _circle1 = Algo2D.FitCircle(_image, ROI1.GetRegion(), MinGray1, MaxGray1, MinArea1, MaxArea1);
                _circle2 = Algo2D.FitCircle(_image, ROI2.GetRegion(), MinGray2, MaxGray2, MinArea2, MaxArea2);
                if (_circle1 == null || _circle2 == null)
                    return;
                Row = _circle1[0];
                Column = _circle1[1];
                Angle = Math.Atan((_circle2[0] - _circle1[0]) / (_circle2[1] - _circle1[1])) * 180 / Math.PI;
                Angle = Angle > 0 ? Angle : 180 + Angle;
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
            if (_image == null) return;
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
