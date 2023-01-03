using System;
using AlgoLib;
using MeasResult;

namespace Meas3D.Tool
{
    public class PlanesIntersectionTool3DModel : PointToolModel
    {
        public FitPlaneTool3DModel Plane1;

        public FitPlaneTool3DModel Plane2;

        public FitPlaneTool3DModel Plane3;

        public float[] Intersection;

        public PlanesIntersectionTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.PLANESINTERSECTION;
            IsCombined = true;
        }

        public override void InitShape()
        {
            if (Plane1 != null) Plane1 = OnGetToolsList().Find(t => (t.Name == Plane1.Name)) as FitPlaneTool3DModel;
            if (Plane2 != null) Plane2 = OnGetToolsList().Find(t => (t.Name == Plane2.Name)) as FitPlaneTool3DModel;
            if (Plane3 != null) Plane3 = OnGetToolsList().Find(t => (t.Name == Plane3.Name)) as FitPlaneTool3DModel;
            if (Results != null) return;
            Results = new MesResult[3];
            Results[0] = new MesResult(Name, "X", "mm");
            Results[1] = new MesResult(Name, "Y", "mm");
            Results[2] = new MesResult(Name, "Z", "mm");
        }

        public override void UpdateResult()
        {
            try
            {
                //Results[0].Value = double.NaN;
                //Results[0].SpanTime = 0;
                //if (Plane1 == null || Plane1.Parameter == null || 
                //    Plane2 == null || Plane2.Parameter == null ||
                //    Plane3 == null || Plane3.Parameter == null)
                //{
                //    OnUpdateValue?.Invoke();
                //    return;
                //}
                //DateTime start = DateTime.Now;
                //Intersection = Algo3D.GetPlanesIntersection(Plane1.Parameter, Plane2.Parameter, Plane3.Parameter);
                //X = Intersection[0];
                //Y = Intersection[1];
                //Z = Intersection[2];
                //DateTime end = DateTime.Now;
                //double span = (end - start).TotalMilliseconds + 1;
                //Results[0].SetResult(X, span);
                //Results[1].SetResult(Y, span);
                //Results[2].SetResult(Z, span);
                //OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("面面交点算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new PlanesIntersectionTool3DView(this);
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
            if (Plane1 == null || Plane2 == null || Plane3 == null)
                return false;
            if (tool.Name == Plane1.Name || tool.Name == Plane2.Name || tool.Name == Plane3.Name)
                return true;
            return false;
        }
    }
}
