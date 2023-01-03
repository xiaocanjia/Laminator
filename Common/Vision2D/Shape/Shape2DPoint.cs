using HalconDotNet;

namespace Vision2D
{
    public class Shape2DPoint : Shape2DBase
    {
        public bool IsAutoSize { get; set; }

        public double Row { get; set; }

        public double Col { get; set; }

        public Shape2DPoint()
        {
            _handlesNum = 1; // 4 corner points + midpoint
            _activeHandleIdx = 0;
            Type = EShape2DType.POINT;
            Color = "blue";
            IsEditable = false;
            IsVisible = true;
            IsAutoSize = true;
        }

        public Shape2DPoint(double row, double col) : this()
        {
            Row = row;
            Col = col;
        }

        public void SetShape(double row, double col)
        {
            Row = row;
            Col = col;
        }

        public override void Paint(HWindow window)
        {
            if (!IsVisible) return;
            window.SetDraw("fill");
            window.SetColor(Color);
            int size = IsAutoSize ? 2 : (int)OSize / 2;
            window.DispCircle(Row, Col, size);
        }

        /// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		public override double DistToClosestHandle(double x, double y)
        {
            return HMisc.DistancePp(y, x, Row, Col);
        }

        /// <summary> 
		/// Recalculates the shape of the ROI. Translation is 
		/// performed at the active handle of the ROI object 
		/// for the image coordinate (x,y)
		/// </summary>
		public override void MoveOrZoom(double newX, double newY)
        {
            if (!IsEditable) return;

            Row = newY;
            Col = newX;
        }
    }
}
