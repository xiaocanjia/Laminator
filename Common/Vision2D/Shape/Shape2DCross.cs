using HalconDotNet;

namespace Vision2D
{
    public class ShapeCross : Shape2DBase
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Row { get; set; }

        public double Col { get; set; }

        public ShapeCross()
        {
            _handlesNum = 1; // 4 corner points + midpoint
            _activeHandleIdx = 0;
            Type = EShape2DType.CROSS;
            Color = "blue";
            IsEditable = false;
            IsVisible = true;
        }

        public ShapeCross(double row, double col) : this()
        {
            SetShape(row, col);
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
            window.DispCross(Row, Col, OSize * 2, 0);
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
