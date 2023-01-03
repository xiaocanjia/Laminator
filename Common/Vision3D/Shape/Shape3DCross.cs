using BSLib;
using HalconDotNet;

namespace Vision3D
{
    public class ShapeCross : Shape3DBase
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Row { get; set; }

        public double Col { get; set; }

        public ShapeCross()
        {
            _handlesNum = 1; // 4 corner points + midpoint
            _activeHandleIdx = 0;
            Type = EShape3DType.CROSS;
            Color = "blue";
            IsEditable = false;
            IsVisible = true;
        }

        public ShapeCross(double row, double col) : this()
        {
            SetShape(row, col);
        }

        public override void UpdateData(JMatrix3D matrix3D, HWindow window)
        {
            if (matrix3D == null) return;
            _matrix3D = matrix3D;
            SetShape(X, Y);
        }

        public void SetShape(double x, double y)
        {
            X = x;
            Y = y;
            Row = y / _matrix3D.Pitch;
            Col = x / _matrix3D.Pitch;
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
