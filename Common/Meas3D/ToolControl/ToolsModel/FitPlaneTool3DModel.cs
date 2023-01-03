using System;
using System.Linq;
using System.Collections.Generic;
using AlgoLib;
using Vision3D;
using MeasResult;
using HalconDotNet;

namespace Meas3D.Tool
{
    public class FitPlaneTool3DModel : Tool3DBaseModel
    {
        public List<Shape3DRect> ROIs;

        public double[] Parameter;

        public double Average;

        public FitPlaneTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.FITPLANE;
            ROIs = new List<Shape3DRect>();
        }

        public override void InitShape()
        {
            foreach (Shape3DRect ROI in ROIs)
            {
                ROI.IsEditable = false;
                OnAddShape?.Invoke(ROI);
                ROI.OnMoved = UpdateResult;
                ROI.OnMoved += UpdateCombinedTool;
            }
            OnRepaint?.Invoke();
            if (Results != null) return;
            Results = new MesResult[1];
            Results[0] = new MesResult(Name, "平面度", "mm");
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Value = double.NaN;
                Results[0].SpanTime = 0;
                if (_matrix3D == null || ROIs.Count == 0)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                List<float> xList = new List<float>();
                List<float> yList = new List<float>();
                List<float> zList = new List<float>();
                foreach (Shape3DRect ROI in ROIs)
                {
                    Algo3D.GetRectROIPoints(_matrix3D, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, 0, 256, out List<float> _xList, out List<float> _yList, out List<float> _zList);
                    xList.AddRange(_xList);
                    yList.AddRange(_yList);
                    zList.AddRange(_zList);
                }

                if (zList.Count == 0)
                {
                    Results[0].Value = float.NaN;
                    DateTime end1 = DateTime.Now;
                    Results[0].SpanTime = (end1 - start).TotalMilliseconds;
                    OnUpdateValue?.Invoke();
                    return;
                }
                float[] xArr = xList.ToArray();
                float[] yArr = yList.ToArray();
                float[] zArr = zList.ToArray();

                OnAffineTrans(xArr, yArr, zArr, out xArr, out yArr, out zArr);
                Average = zArr.Average();
                Algo3D.GetFitPlane(xArr, yArr, zArr, out Parameter);
                Algo3D.GetPointsToPlaneDists(xArr, yArr, zArr, Parameter, out List<float> dists);
                dists.Sort();
                Results[0].Value = dists[(int)(dists.Count * 0.95)] - dists[(int)(dists.Count * 0.05)];
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("拟合平面算子发生异常" + ex.Message);
            }
        }

        public override void OpenSetupView()
        {
            SetupView = new FitPlaneTool3DView(this);
            foreach (Shape3DRect ROI in ROIs)
            {
                ROI.IsEditable = true;
            }
            OnRepaint?.Invoke();
            base.OpenSetupView();
        }

        public override void CloseSetupView()
        {
            foreach (Shape3DRect ROI in ROIs)
            {
                ROI.IsEditable = false;
            }
            OnRepaint?.Invoke();
            base.CloseSetupView();
        }

        public void AddROI()
        {
            Shape3DRect ROI = new Shape3DRect() { Color = "yellow" };
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

        public override void DeleteTool()
        {
            foreach (Shape3DRect roi in ROIs)
            {
                OnRemoveShape?.Invoke(roi);
            }
            OnRepaint?.Invoke();
            base.DeleteTool();
        }
    }
}
