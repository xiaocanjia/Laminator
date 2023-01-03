using System;
using System.Linq;
using System.Collections.Generic;
using AlgoLib;
using Vision3D;
using MeasResult;

namespace Meas3D.Tool
{
    public class VertexLocTool3DModel : PointToolModel
    {
        public Shape3DBase ROI;

        public FitPlaneTool3DModel Plane;

        private Shape3DPoint _vertex;

        public EShape3DType ShapeType;

        public int PointType;

        public byte MaxLuminace = 255;

        public byte MinLuminace = 0;

        public float MaxHeight = 10;

        public float MinHeight = 1;

        public VertexLocTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.VECTEXLOC;
            ShapeType = EShape3DType.RECT;
            IsCombined = true;
            ROI = new Shape3DRect() { Color = "yellow" };
            _vertex = new Shape3DPoint() { Color = "red" };
        }

        public override void InitShape()
        {
            if (Plane != null) Plane = OnGetToolsList().Find(t => (t.Name == Plane.Name)) as FitPlaneTool3DModel;
            ROI.IsEditable = false;
            OnAddShape?.Invoke(ROI);
            ROI.OnMoved += UpdateResult;
            ROI.OnMoved += UpdateShape;
            ROI.OnMoved += UpdateCombinedTool;
            OnAddShape?.Invoke(_vertex);
            OnRepaint?.Invoke();
            if (Results != null) return;
            Results = new MesResult[3];
            Results[0] = new MesResult(Name, "X", "mm");
            Results[1] = new MesResult(Name, "Y", "mm");
            Results[2] = new MesResult(Name, "Z", "mm");
        }

        public void ChangeShape()
        {
            OnRemoveShape?.Invoke(ROI);
            switch (ShapeType)
            {
                case EShape3DType.RECT:
                    ROI = new Shape3DRect();
                    break;
                case EShape3DType.CIRCLE:
                    ROI = new Shape3DCircle();
                    break;
                case EShape3DType.LINE:
                    ROI = new Shape3DLine();
                    break;
                default:
                    break;
            }
            ROI.Color = "yellow";
            OnAddShape(ROI);
            ROI.OnMoved += UpdateResult;
            ROI.OnMoved += UpdateShape;
            ROI.OnMoved += UpdateCombinedTool;
            OnRepaint?.Invoke();
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Value = float.NaN;
                Results[1].Value = float.NaN;
                Results[2].Value = float.NaN;
                Results[0].SpanTime = 0;
                Results[1].SpanTime = 0;
                Results[2].SpanTime = 0;
                _vertex.IsVisible = false;
                if (_matrix3D == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                List<float> xList = new List<float>();
                List<float> yList = new List<float>();
                List<float> zList = new List<float>();
                switch (ShapeType)
                {
                    case EShape3DType.RECT:
                        Shape3DRect ROIRect = ROI as Shape3DRect;
                        Algo3D.GetRectROIPoints(_matrix3D, (int)ROIRect.Col1, (int)ROIRect.Row1, (int)ROIRect.Col2, (int)ROIRect.Row2, MinLuminace, MaxLuminace, out xList, out yList, out zList);
                        break;
                    case EShape3DType.CIRCLE:
                        Shape3DCircle ROICircle = ROI as Shape3DCircle;
                        Algo3D.GetCircleROIPoints(_matrix3D, (int)ROICircle.Col, (int)ROICircle.Row, (int)ROICircle.Radius, MinLuminace, MaxLuminace, out xList, out yList, out zList);
                        break;
                    case EShape3DType.LINE:
                        Shape3DLine ROILine = ROI as Shape3DLine;
                        Algo3D.GetLineROIPoints(_matrix3D, (int)ROILine.Col1, (int)ROILine.Row1, (int)ROILine.Col2, (int)ROILine.Row2, MinLuminace, MaxLuminace, out xList, out yList, out zList, out List<byte> lList);
                        break;
                    default:
                        break;
                }
                if (zList.Count == 0)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                OnAffineTrans(xList.ToArray(), yList.ToArray(), zList.ToArray(), out float[] xArr, out float[] yArr, out float[] zArr);
                xList = new List<float>(xArr);
                yList = new List<float>(yArr);
                zList = new List<float>(zArr);
                Algo3D.GetPointsToPlaneDists(xArr, yArr, zArr, Plane?.Parameter, out zList);
                List<float> max = zList.FindAll(d => d > MinHeight && d < MaxHeight);
                switch (PointType)
                {
                    case 0:
                        {
                            if (max.Count == 0)
                            {
                                OnUpdateValue?.Invoke();
                                return;
                            }
                            Z = max.Max();
                            for (int i = 0; i < zList.Count; i++)
                            {
                                if (zList[i] == Z)
                                {
                                    X = xArr[i];
                                    Y = yArr[i];
                                    break;
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            max.Sort();
                            max = max.GetRange((int)(max.Count * 0.9), (int)(max.Count * 0.1));
                            if (max.Count == 0)
                            {
                                OnUpdateValue?.Invoke();
                                return;
                            }
                            Z = max.Average();
                            double pHeight = Plane == null ? 0 : Plane.Average;
                            float[] loc = Algo3D.GetAreaCenter(_matrix3D, ROI.GetRegion(), MinHeight + pHeight, MaxHeight + pHeight, MinLuminace, MaxLuminace);
                            X = loc == null ? float.NaN : loc[0];
                            Y = loc == null ? float.NaN : loc[1];
                        }
                        break;
                }
                _vertex.IsVisible = true;
                _vertex.SetShape(X, Y);
                Results[0].Value = Algo3D.GetPointToLineDist(X, Y, _yAxisParam);
                Results[1].Value = Algo3D.GetPointToLineDist(X, Y, _xAxisParam);
                Results[2].Value = Z;
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                Results[1].SpanTime = (end - start).TotalMilliseconds;
                Results[2].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("高度测量算子发生异常" + ex.Message);
            }
        }

        public override void OpenSetupView()
        {
            SetupView = new VertexLocTool3DView(this);
            ROI.IsEditable = true;
            OnRepaint?.Invoke();
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
            OnRemoveShape?.Invoke(_vertex);
            OnRepaint?.Invoke();
            base.DeleteTool();
        }

        public override bool ContainTool(Tool3DBaseModel tool)
        {
            if (Plane == null)
                return false;
            if (tool.Name == Plane.Name)
                return true;
            return false;
        }
    }
}
