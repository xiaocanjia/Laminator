using System;
using AlgoLib;
using MeasResult;

namespace Meas3D.Tool
{
    public class PlaneToPlaneAngleTool3DModel : Tool3DBaseModel
    {
        public FitPlaneTool3DModel Plane1;

        public FitPlaneTool3DModel Plane2;

        public PlaneToPlaneAngleTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.PLANETOPLANEANGLE;
            IsCombined = true;
        }

        public override void InitShape()
        {
            if (Plane1 != null) Plane1 = OnGetToolsList().Find(t => (t.Name == Plane1.Name)) as FitPlaneTool3DModel;
            if (Plane2 != null) Plane2 = OnGetToolsList().Find(t => (t.Name == Plane2.Name)) as FitPlaneTool3DModel;
            if (Results != null) return;
            Results = new MesResult[1];
            Results[0] = new MesResult(Name, "角度", "°");
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Value = double.NaN;
                Results[0].SpanTime = 0;
                if (Plane1 == null || Plane2 == null || Plane1.Parameter == null || Plane2.Parameter == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                Results[0].Value = Math.Abs(Algo3D.GetPlaneToPlaneAngle(Plane1.Parameter, Plane2.Parameter));
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds + 1;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("面面角度算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new PlaneToPlaneAngleTool3DView(this);
            OnRepaint();
            base.OpenSetupView();
        }

        public override void CloseSetupView()
        {
            OnRepaint?.Invoke();
            base.CloseSetupView();
        }

        public override void DeleteTool()
        {
            OnRepaint();
            base.DeleteTool();
        }

        public override bool ContainTool(Tool3DBaseModel tool)
        {
            if (Plane1 == null || Plane2 == null)
                return false;
            if (tool.Name == Plane1.Name || tool.Name == Plane2.Name)
                return true;
            return false;
        }
    }
}
