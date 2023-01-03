using System;
using System.Collections.Generic;
using HalconDotNet;
using AlgoLib;
using Vision3D;
using MeasResult;

namespace Meas3D.Tool
{
    public class FitCircleTool3DModel : Tool3DBaseModel
    {
        public Shape3DCircle ROI = null;

        public double MaxHeight = 10;

        public double MinHeight = 0;

        public double MaxLuminace = 255;

        public double MinLuminace = 0;

        public double MinDiameter = 0.6;

        public double MaxDiameter = 3.0;

        public double StartAngle = 0;

        public double EndAngle = 360;

        public bool IsRising = false;

        private Shape3DCircle Shape3DCircle = null;

        private List<HTuple> _edgePoints = new List<HTuple>();

        private List<Shape3DPoint> _shapePoints = new List<Shape3DPoint>();

        public bool IsDispLoc { get; set; }

        public double[] Parameter;

        public bool IsFilterAgain = false;

        public int Dir = 0;

        public FitCircleTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.FITCIRCLE;
            ROI = new Shape3DCircle() { Color = "blue" };
            Shape3DCircle = new Shape3DCircle() { IsEditable = false };
        }

        public override void InitShape()
        {
            ROI.IsEditable = false;
            OnAddShape?.Invoke(ROI);
            ROI.OnMoved += UpdateResult;
            ROI.OnMoved += UpdateShape;
            ROI.OnMoved += UpdateCombinedTool;
            OnRepaint?.Invoke();
            if (Results != null) return;
            Results = new MesResult[3];
            Results[0] = new MesResult(Name, "X", "mm");
            Results[1] = new MesResult(Name, "Y", "mm");
            Results[2] = new MesResult(Name, "直径", "mm");
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Value = double.NaN;
                Results[1].Value = double.NaN;
                Results[2].Value = double.NaN;
                Results[0].SpanTime = 0;
                Results[1].SpanTime = 0;
                Results[2].SpanTime = 0;
                Parameter = null;
                _edgePoints.Clear();
                if (_matrix3D == null)
                    return;
                DateTime start = DateTime.Now;
                Parameter = Algo3D.FitCircle(_matrix3D, (int)ROI.Col, (int)ROI.Row, (int)ROI.Radius, MinDiameter, MaxDiameter, StartAngle, 
                                              EndAngle, 0.5, Dir, IsRising, IsFilterAgain, MinLuminace, MaxLuminace, MinHeight, MaxHeight, out float[] newX, out float[] newY);
                if (Parameter == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                for (int i = 0; i < newX.Length; i++)
                    _edgePoints.Add(new HTuple(newX[i], newY[i]));
                Results[0].Value = Algo3D.GetPointToLineDist(Parameter[0], Parameter[1], _yAxisParam);
                Results[1].Value = Algo3D.GetPointToLineDist(Parameter[0], Parameter[1], _xAxisParam);
                Results[2].Value = Parameter[2] * 2;
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                Results[1].SpanTime = (end - start).TotalMilliseconds;
                Results[2].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("拟合圆算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            try
            {
                if (_matrix3D == null) return;
                if (_shapePoints.Count != 0)
                {
                    foreach (Shape3DPoint point in _shapePoints)
                    {
                        OnRemoveShape?.Invoke(point);
                    }
                    _shapePoints.Clear();
                }
                if (IsDispLoc)
                {
                    foreach (HTuple point in _edgePoints)
                    {
                        Shape3DPoint Shape3DPoint = new Shape3DPoint();
                        _shapePoints.Add(Shape3DPoint);
                        OnAddShape?.Invoke(Shape3DPoint);
                        Shape3DPoint.SetShape(point[0], point[1]);
                    }
                }
                if (Shape3DCircle != null)
                    OnRemoveShape?.Invoke(Shape3DCircle);
                if (Parameter != null)
                {
                    OnAddShape?.Invoke(Shape3DCircle);
                    Shape3DCircle.SetShape(Parameter[0], Parameter[1], Parameter[2]);
                }
                OnRepaint();
            }
            catch (Exception ex)
            {
                throw new Exception("拟合圆算子发生异常" + ex.Message);
            }
        }

        public override void OpenSetupView()
        {
            SetupView = new FitCircleTool3DView(this);
            ROI.IsEditable = true;
            OnRepaint();
            base.OpenSetupView();
        }

        public override void CloseSetupView()
        {
            ROI.IsEditable = false;
            OnRepaint?.Invoke();
            base.CloseSetupView();
        }

        public override void DeleteTool()
        {
            OnRemoveShape?.Invoke(ROI);
            OnRemoveShape?.Invoke(Shape3DCircle);
            if (_shapePoints.Count != 0)
            {
                foreach (Shape3DPoint point in _shapePoints)
                {
                    OnRemoveShape?.Invoke(point);
                }
                _shapePoints.Clear();
            }
            OnRepaint();
            base.DeleteTool();
        }
    }
}
