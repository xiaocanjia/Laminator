using MeasResult;
using System;

namespace Meas3D.Tool
{
    public class PointsDistTool3DModel : Tool3DBaseModel
    {
        public PointToolModel Point1;

        public PointToolModel Point2;

        public PointsDistTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.CIRCLESDIST;
            IsCombined = true;
        }

        public override void InitShape()
        {
            if (Point1 != null) Point1 = OnGetToolsList().Find(t => (t.Name == Point1.Name)) as PointToolModel;
            if (Point2 != null) Point2 = OnGetToolsList().Find(t => (t.Name == Point2.Name)) as PointToolModel;
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
                if (Point1 == null || Point2 == null)
                {
                    OnUpdateValue?.Invoke();
                    return;
                }
                DateTime start = DateTime.Now;
                Results[0].Value = Math.Sqrt(Math.Pow(Point1.X - Point2.X, 2) + Math.Pow(Point1.Y - Point2.Y, 2) + Math.Pow(Point1.Z - Point2.Z, 2));
                DateTime end = DateTime.Now;
                Results[0].SpanTime = (end - start).TotalMilliseconds;
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("点点距离算子发生异常" + ex.Message);
            }
        }

        public override void UpdateShape()
        {
            OnRepaint();
        }

        public override void OpenSetupView()
        {
            SetupView = new PointsDistTool3DView(this);
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
            if (Point1 == null || Point2 == null)
                return false;
            if (tool.Name == Point1.Name || tool.Name == Point2.Name)
                return true;
            return false;
        }
    }
}
