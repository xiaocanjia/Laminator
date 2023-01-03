using BSLib;
using HalconDotNet;

namespace Vision3D
{
    public class Shape3DPoint : Shape3DBase
    {
        public bool IsAutoSize { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Row { get; set; }

        public double Col { get; set; }

        public Shape3DPoint()
        {
            _handlesNum = 1; // 4 corner points + midpoint
            _activeHandleIdx = 0;
            Type = EShape3DType.POINT;
            Color = "blue";
            IsEditable = false;
            IsVisible = true;
            IsAutoSize = true;
        }

        public Shape3DPoint(double row, double col) : this()
        {
            Row = row;
            Col = col;
        }

        public override void UpdateData(JMatrix3D matrix3D, HWindow window)
        {
            if (matrix3D == null) return;
            _matrix3D = matrix3D;
            SetShape(X, Y);
        }

        public void SetShape(double x, double y)
        {
            if (x == 0 && y == 0)
            {
                x = Col * _matrix3D.Pitch;
                y = Row * _matrix3D.Pitch;
            }
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
