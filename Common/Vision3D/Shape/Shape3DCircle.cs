using System;
using HalconDotNet;
using BSLib;

namespace Vision3D
{
    public class Shape3DCircle : Shape3DBase
    {
        public double Row { get; set; }

        public double Col { get; set; }

        public double RadiusPix { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; }

        private double _row;

        private double _col;

        public Shape3DCircle()
        {
            _handlesNum = 2; // 1 corner points + midpoint
            _activeHandleIdx = 2;
            Type = EShape3DType.CIRCLE;
            Color = "yellow";
            IsEditable = true;
            IsVisible = true;
        }

        //public Shape3DCircle(double row, double col, double radiusPix) : this()
        //{
        //    SetShape(row, col, radiusPix);
        //}

        public override void UpdateData(JMatrix3D matrix3D, HWindow window)
        {
            if (matrix3D == null) return;
            _matrix3D = matrix3D;
            if (X == 0 && Y == 0 && Radius == 0)
            {
                if (window == null)
                {
                    X = _matrix3D.Column * _matrix3D.Pitch / 2;
                    Y = _matrix3D.Row * _matrix3D.Pitch / 2;
                    Radius = _matrix3D.Column * _matrix3D.Pitch / 8;
                }
                else
                {
                    window.GetPart(out int row1, out int col1, out int row2, out int col2);
                    X = (col1 + (col2 - col1) / 2) * _matrix3D.Pitch;
                    Y = (row1 + (row2 - row1) / 2) * _matrix3D.Pitch;
                    Radius = (row2 - row1) * _matrix3D.Pitch / 8;
                }
            }
            SetShape(X, Y, Radius);
        }

        public void SetShape(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            Row = y / _matrix3D.Pitch;
            Col = x / _matrix3D.Pitch;
            RadiusPix = radius / _matrix3D.Pitch;
            _row = Row;
            _col = Col + RadiusPix;
        }

        public override void Paint(HWindow window)
        {
            if (!IsVisible) return;
            window.SetDraw("margin");
            window.SetLineWidth(1);
            window.SetColor(Color);
            window.DispCircle(Row, Col, RadiusPix);

            if (!IsEditable) return;
            window.DispRectangle2(_row, _col, 0, OSize, OSize);
            window.DispRectangle2(Row, Col, 0, OSize, OSize);
        }

        /// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		/// <param name="x">x (=column) coordinate</param>
		/// <param name="y">y (=row) coordinate</param>
		/// <returns> 
		/// Distance of the closest ROI handle.
		/// </returns>
		public override double DistToClosestHandle(double x, double y)
        {
            double max = 10000;
            double[] val = new double[_handlesNum];

            val[0] = HMisc.DistancePp(y, x, Row, Col); // upper left 
            val[1] = HMisc.DistancePp(y, x, _row, _col); // midpoint 

            for (int i = 0; i < _handlesNum; i++)
            {
                if (val[i] < max)
                {
                    max = val[i];
                    _activeHandleIdx = i;
                }
            }

            return val[_activeHandleIdx];
        }

        /// <summary> 
		/// Recalculates the shape of the ROI instance. Translation is 
		/// performed at the active handle of the ROI object 
		/// for the image coordinate (x,y)
		/// </summary>
		/// <param name="newX">x mouse coordinate</param>
		/// <param name="newY">y mouse coordinate</param>
		public override void MoveOrZoom(double newX, double newY)
        {
            if (!IsEditable) return;

            double len1, len2;

            switch (_activeHandleIdx)
            {
                case 0:
                    len1 = Row - newY;
                    len2 = Col - newX;

                    Row = newY;
                    Col = newX;

                    _row -= len1;
                    _col -= len2;
                    break;
                case 1:
                    _row = newY;
                    _col = newX;
                    RadiusPix = Math.Sqrt((Row - _row) * (Row - _row) + (Col - _col) * (Col - _col));
                    break;
            }
            X = Col * _matrix3D.Pitch;
            Y = Row * _matrix3D.Pitch;
            Radius = RadiusPix * _matrix3D.Pitch;
        }

        public override HRegion GetRegion()
        {
            HOperatorSet.SetSystem("clip_region", "false");
            HRegion region = new HRegion();
            region.GenCircle(Row, Col, RadiusPix);
            return region;
        }
    }
}
