using System;
using AlgoLib;
using MeasResult;

namespace Meas3D.Tool
{
    public class LinesDistTool3DModel : Tool3DBaseModel
    {
        public FitLineTool3DModel Line1;

        public FitLineTool3DModel Line2;

        public LinesDistTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.CIRCLESDIST;
            IsCombined = true;
        }

        public override void InitShape()
        {
            if (Line1 != null) Line1 = OnGetToolsList().Find(t => (t.Name == Line1.Name)) as FitLineTool3DModel;
            if (Line2 != null) Line2 = OnGetToolsList().Find(t => (t.Name == Line2.Name)) as FitLineTool3DModel;
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
                if (Line1 == null || Line2 == null || Line1.Parameter == null || Line2.Parameter == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                Results[0].Value = Algo3D.GetPointToLineDist(Line1.Center[0], Line1.Center[1], Line2.Parameter);
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("线线距离算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new LinesDistTool3DView(this);
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
            if (Line1 == null || Line2 == null)
                return false;
            if (tool.Name == Line1.Name || tool.Name == Line2.Name)
                return true;
            return false;
        }
    }
}

