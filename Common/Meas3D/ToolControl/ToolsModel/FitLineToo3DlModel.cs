using System;
using System.Collections.Generic;
using HalconDotNet;
using AlgoLib;
using Vision3D;
using System.Linq;
using MeasResult;

namespace Meas3D.Tool
{
    public class FitLineTool3DModel : Tool3DBaseModel
    {
        private Shape3DLine _line = null;

        private List<HTuple> _edgePoints = new List<HTuple>();

        private List<Shape3DPoint> _shapePoints = new List<Shape3DPoint>();

        public List<Shape3DRect> ROIs = new List<Shape3DRect>();

        public double[] Parameter;

        public double MaxHeight = 10;

        public double MinHeight = 0;

        public double MaxLuminace = 255;

        public double MinLuminace = 0;

        public double[] Center;

        public bool IsDispLoc { get; set; }

        public int Direction = 0;

        public bool IsRising = false;

        public double FilterRatio = 0.0;

        public FitLineTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.FITLINE;
            _line = new Shape3DLine() { IsEditable = false };
        }

        public override void InitShape()
        {
            foreach (Shape3DRect ROI in ROIs)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved += UpdateResult;
                ROI.OnMoved += UpdateShape;
                ROI.OnMoved += UpdateCombinedTool;
            }
            OnRepaint?.Invoke();
            if (Results != null) return;
            Results = new MesResult[1];
            Results[0] = new MesResult(Name, "直线度", "mm");
        }

        public void AddROI()
        {
            Shape3DRect ROI = new Shape3DRect() { Color = "blue" };
            ROIs.Add(ROI);
            OnAddShape(ROI);
            ROI.OnMoved += UpdateResult;
            ROI.OnMoved += UpdateShape;
            ROI.OnMoved += UpdateCombinedTool;
            UpdateResult();
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
            UpdateResult();
            UpdateShape();
            OnRepaint?.Invoke();
        }

        public override void UpdateResult()
        {
            try
            {
                if (_matrix3D == null) return;
                DateTime start = DateTime.Now;
                List<double> xList = new List<double>();
                List<double> yList = new List<double>();
                foreach (Shape3DRect ROI in ROIs)
                {
                    Algo3D.GetLineContour(_matrix3D, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, MinLuminace, MaxLuminace, MinHeight, MaxHeight, Direction, IsRising, out double[] X, out double[] Y);
                    xList.AddRange(X);
                    yList.AddRange(Y);
                }
                double straightness = Algo3D.GetFitLine(xList.ToArray(), yList.ToArray(), out Parameter, out double[] newX, out double[] newY, FilterRatio);
                _edgePoints.Clear();
                if (newX == null || newY == null)
                    return;
                for (int i = 0; i < newX.Length; i++)
                    _edgePoints.Add(new HTuple(newX[i], newY[i]));
                OnRemoveShape(_line);
                if (Parameter == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                double startX = 0;
                double startY = 0;
                double endX = 0;
                double endY = 0;
                if (Math.Abs(Parameter[0] / Parameter[1]) < 1)
                {
                    startX = 0;
                    startY = (-(Parameter[0] * startX) - Parameter[2]) / Parameter[1];
                    endX = _matrix3D.Column * _matrix3D.Pitch;
                    endY = (-(Parameter[0] * endX) - Parameter[2]) / Parameter[1];
                }
                else
                {
                    startY = 0;
                    startX = (-(Parameter[1] * startY) - Parameter[2]) / Parameter[0];
                    endY = _matrix3D.Row * _matrix3D.Pitch;
                    endX = (-(Parameter[1] * endY) - Parameter[2]) / Parameter[0];
                }
                Center = new double[2];
                Center[0] = (startX + endX) / 2;
                Center[1] = (startY + endY) / 2;
                OnAddShape(_line);
                _line.SetShape(startX, startY, endX, endY);
                Results[0].Value = straightness;
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("拟合线算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
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
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new FitLineTool3DView(this);
            foreach (var ROI in ROIs)
                ROI.IsEditable = true;
            OnRepaint();
            base.OpenSetupView();
        }

        public override void CloseSetupView()
        {
            foreach (var ROI in ROIs)
                ROI.IsEditable = false;
            OnRepaint?.Invoke();
            base.CloseSetupView();
        }

        public override void DeleteTool()
        {
            foreach (var ROI in ROIs)
                OnRemoveShape?.Invoke(ROI);
            OnRemoveShape?.Invoke(_line);
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
