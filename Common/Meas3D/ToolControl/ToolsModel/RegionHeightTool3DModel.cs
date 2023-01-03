using System;
using System.Linq;
using System.Collections.Generic;
using AlgoLib;
using Vision3D;
using MeasResult;

namespace Meas3D.Tool
{
    public class RegionHeightTool3DModel : Tool3DBaseModel
    {
        public Shape3DBase ROI;

        public int PointsType;

        public FitPlaneTool3DModel Plane;

        public EShape3DType ShapeType;
        
        public byte MaxLuminace = 255;

        public byte MinLuminace = 0;

        public RegionHeightTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.REGIONHEIGHT;
            PointsType = 2;
            ShapeType = EShape3DType.RECT;
            IsCombined = true;
            ROI = new Shape3DRect() { Color = "yellow" };
        }

        public override void InitShape()
        {
            if (Plane != null) Plane = OnGetToolsList().Find(t => (t.Name == Plane.Name)) as FitPlaneTool3DModel;
            ROI.IsEditable = false;
            OnAddShape?.Invoke(ROI);
            ROI.OnMoved += UpdateResult;
            ROI.OnMoved += UpdateShape;
            OnRepaint?.Invoke();
            if (Results != null) return;
            Results = new MesResult[1];
            Results[0] = new MesResult(Name, "距离", "mm");
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
            OnRepaint?.Invoke();
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Value = double.NaN;
                Results[0].SpanTime = 0;
                if (_matrix3D == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                List<float> xList = new List<float>();
                List<float> yList = new List<float>();
                List<float> zList = new List<float>();
                double centerX = 0;
                double centerY = 0;
                switch (ShapeType)
                {
                    case EShape3DType.RECT:
                        Shape3DRect ROIRect = ROI as Shape3DRect;
                        Algo3D.GetRectROIPoints(_matrix3D, (int)ROIRect.Col1, (int)ROIRect.Row1, (int)ROIRect.Col2, (int)ROIRect.Row2, MinLuminace, MaxLuminace, out xList, out yList, out zList);
                        centerX = (ROIRect.Col1 + ROIRect.Col2) / 2;
                        centerY = (ROIRect.Row1 + ROIRect.Row2) / 2;
                        break;
                    case EShape3DType.CIRCLE:
                        Shape3DCircle ROICircle = ROI as Shape3DCircle;
                        Algo3D.GetCircleROIPoints(_matrix3D, (int)ROICircle.Col, (int)ROICircle.Row, (int)ROICircle.Radius, MinLuminace, MaxLuminace, out xList, out yList, out zList);
                        centerX = ROICircle.Col * _matrix3D.Pitch;
                        centerY = ROICircle.Row * _matrix3D.Pitch;
                        break;
                    case EShape3DType.LINE:
                        Shape3DLine ROILine = ROI as Shape3DLine;
                        Algo3D.GetLineROIPoints(_matrix3D, (int)ROILine.Col1, (int)ROILine.Row1, (int)ROILine.Col2, (int)ROILine.Row2, MinLuminace, MaxLuminace, out xList, out yList, out zList, out List<byte> lList);
                        centerX = (ROILine.Col1 + ROILine.Col2) / 2;
                        centerY = (ROILine.Row1 + ROILine.Row2) / 2;
                        break;
                    default:
                        break; 
                }
                if (zList.Count == 0)
                {
                    Results[0].Value = float.NaN;
                    Results[0].SpanTime = (DateTime.Now - start).TotalMilliseconds;
                    return;
                }
                OnAffineTrans(xList.ToArray(), yList.ToArray(), zList.ToArray(), out float[] xArr, out float[] yArr, out float[] zArr);
                xList = new List<float>(xArr);
                yList = new List<float>(yArr);
                zList = new List<float>(zArr);
                //Algo3D.GetPointsToPlaneDists(xArr, yArr, zArr, Plane?.Parameter, out zList);
                switch (PointsType)
                {
                    case 0:
                        Results[0].Value = zList.Max();
                        break;
                    case 1:
                        Results[0].Value = zList.Min();
                        break;
                    case 2:
                        Results[0].Value = zList.Average();
                        break;
                    case 3:
                        Results[0].Value = zList.Max() - Plane.Average;
                        break;
                    case 4:
                        Results[0].Value = zList.Min() - Plane.Average;
                        break;
                    case 5:
                        Results[0].Value = zList.Average() - Plane.Average;
                        break;
                }
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("高度测量算子发生异常" + ex.Message);
            }
        }

        public override void OpenSetupView()
        {
            SetupView = new RegionHeightTool3DView(this);
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
