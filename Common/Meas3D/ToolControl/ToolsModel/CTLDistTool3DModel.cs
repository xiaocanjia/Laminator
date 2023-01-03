using System;
using AlgoLib;
using MeasResult;

namespace Meas3D.Tool
{
    public class CTLDistTool3DModel : Tool3DBaseModel
    {
        public FitCircleTool3DModel Circle;

        public FitLineTool3DModel Line;

        public CTLDistTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.CTLDIST;
            IsCombined = true;
        }

        public override void InitShape()
        {
            if (Circle != null) Circle = OnGetToolsList().Find(t => (t.Name == Circle.Name)) as FitCircleTool3DModel;
            if (Line != null) Line = OnGetToolsList().Find(t => (t.Name == Line.Name)) as FitLineTool3DModel;
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
                if (Circle == null || Line == null || Circle.Parameter == null || Line.Parameter == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                Results[0].Value = Math.Abs(Algo3D.GetPointToLineDist(Circle.Parameter[0], Circle.Parameter[1], Line.Parameter));
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds + 1;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("圆线距离算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new CTLDistTool3DView(this);
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
            if (Circle == null || Line == null)
                return false;
            if (tool.Name == Circle.Name || tool.Name == Line.Name)
                return true;
            return false;
        }
    }
}
