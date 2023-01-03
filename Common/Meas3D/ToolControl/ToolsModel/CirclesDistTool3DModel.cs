using System;
using AlgoLib;
using MeasResult;

namespace Meas3D.Tool
{
    public class CirclesDistTool3DModel : Tool3DBaseModel
    {
        public FitCircleTool3DModel Circle1;

        public FitCircleTool3DModel Circle2;

        public int DistType;

        public CirclesDistTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.CIRCLESDIST;
            DistType = 0;
            IsCombined = true;
        }

        public override void InitShape()
        {
            if (Circle1 != null) Circle1 = OnGetToolsList().Find(t => (t.Name == Circle1.Name)) as FitCircleTool3DModel;
            if (Circle2 != null) Circle2 = OnGetToolsList().Find(t => (t.Name == Circle2.Name)) as FitCircleTool3DModel;
            if (Results != null) return;
            Results = new MesResult[1];
            Results[0] = new MesResult(Name, "距离", "mm");
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Value = double.NaN;
                Results[0].SpanTime = 0;
                if (Circle1 == null || Circle2 == null || Circle1.Parameter == null || Circle2.Parameter == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                switch (DistType)
                {
                    case 0:
                        Results[0].Value = Math.Sqrt(Math.Pow(Circle1.Parameter[0] - Circle2.Parameter[0], 2) + Math.Pow(Circle1.Parameter[1] - Circle2.Parameter[1], 2));
                        break;
                    case 1:
                        double dist1 = Algo3D.GetPointToLineDist(Circle1.Parameter[0], Circle1.Parameter[1], _yAxisParam);
                        double dist2 = Algo3D.GetPointToLineDist(Circle2.Parameter[0], Circle2.Parameter[1], _yAxisParam);
                        Results[0].Value = Math.Abs(Algo3D.GetPointToLineDist(Circle1.Parameter[0], Circle1.Parameter[1], _yAxisParam) - 
                                                    Algo3D.GetPointToLineDist(Circle2.Parameter[0], Circle2.Parameter[1], _yAxisParam));
                        break;
                    case 2:
                        Results[0].Value = Math.Abs(Algo3D.GetPointToLineDist(Circle1.Parameter[0], Circle1.Parameter[1], _xAxisParam) - 
                                                    Algo3D.GetPointToLineDist(Circle2.Parameter[0], Circle2.Parameter[1], _xAxisParam));
                        break;
                }
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("圆圆距离算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new CirclesDistTool3DView(this);
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
            if (Circle1 == null || Circle2 == null)
                return false;
            if (tool.Name == Circle1.Name || tool.Name == Circle2.Name)
                return true;
            return false;
        }
    }
}
