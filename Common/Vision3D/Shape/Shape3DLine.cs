using System;
using HalconDotNet;
using BSLib;

namespace Vision3D
{
    public class Shape3DLine : Shape3DBase
    {
        public double Row1 { get; set; }

        public double Col1 { get; set; }

        public double Row2 { get; set; }

        public double Col2 { get; set; }

        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }
        
        public double Length
        {
            get
            {
                return Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));
            }
        }

        private double _midR;

        private double _midC;

        private HXLDCont _arrow;

        public Shape3DLine()
        {
            _handlesNum = 3;
            _activeHandleIdx = 2;
            _arrow = new HXLDCont();
            Type = EShape3DType.LINE;
            Color = "yellow";
            IsEditable = true;
            IsVisible = true;
        }

        public Shape3DLine(double row1, double col1, double row2, double col2) : this()
        {
            SetShape(row1, col1, row2, col2);
        }

        public override void UpdateData(JMatrix3D matrix3D, HWindow window)
        {
            if (matrix3D == null) return;
            _matrix3D = matrix3D;

            if (X1 == 0 && Y1 == 0 && X2 == 0 && Y2 == 0)
            {
                if (window == null)
                {
                    X1 = _matrix3D.Column * _matrix3D.Pitch / 3;
                    Y1 = _matrix3D.Row * _matrix3D.Pitch / 3;
                    X2 = _matrix3D.Column * _matrix3D.Pitch / 2;
                    Y2 = _matrix3D.Row * _matrix3D.Pitch / 2;
                }
                else
                {
                    window.GetPart(out int row1, out int col1, out int row2, out int col2);
                    X1 = (col1 + (col2 - col1) / 2.5) * _matrix3D.Pitch;
                    Y1 = (row1 + (row2 - row1) / 2.5) * _matrix3D.Pitch;
                    X2 = (col2 - (col2 - col1) / 2.5) * _matrix3D.Pitch;
                    Y2 = (row2 - (row2 - row1) / 2.5) * _matrix3D.Pitch;
                }
            }
            SetShape(X1, Y1, X2, Y2);
        }

        public void SetShape(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            if (_matrix3D == null) return;
            Row1 = y1 / _matrix3D.Pitch;
            Col1 = x1 / _matrix3D.Pitch;
            Row2 = y2 / _matrix3D.Pitch;
            Col2 = x2 / _matrix3D.Pitch;
            _midR = (Row1 + Row2) / 2.0;
            _midC = (Col1 + Col2) / 2.0;
            _arrow = ShapeHelper.GenLineArrow(Row1, Col1, Row2, Col2, OSize * 5);
        }

        public override void Paint(HWindow window)
        {
            if (!IsVisible) return;
            window.SetDraw("margin");
            window.SetLineWidth(1.2);
            window.SetColor(Color);
            window.DispLine(Row1, Col1, Row2, Col2);

            if (!IsEditable) return;
            _arrow = ShapeHelper.GenLineArrow(Row1, Col1, Row2, Col2, OSize * 5);
            window.DispObj(_arrow);
            window.DispRectangle2(Row1, Col1, 0, OSize, OSize);
            //window.DispCross(Row1, Col1, OSize, 0);
            window.DispRectangle2(_midR, _midC, 0, OSize, OSize);
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

            val[0] = HMisc.DistancePp(y, x, Row1, Col1); // upper left 
            val[1] = HMisc.DistancePp(y, x, Row2, Col2); // upper right 
            val[2] = HMisc.DistancePp(y, x, _midR, _midC); // midpoint 

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
            double lenR, lenC;

            switch (_activeHandleIdx)
            {
                case 0: // first end point
                    Row1 = newY;
                    Col1 = newX;

                    _midR = (Row1 + Row2) / 2;
                    _midC = (Col1 + Col2) / 2;
                    break;
                case 1: // last end point
                    Row2 = newY;
                    Col2 = newX;

                    _midR = (Row1 + Row2) / 2;
                    _midC = (Col1 + Col2) / 2;
                    break;
                case 2: // midpoint 
                    lenR = Row1 - _midR;
                    lenC = Col1 - _midC;

                    _midR = newY;
                    _midC = newX;

                    Row1 = _midR + lenR;
                    Col1 = _midC + lenC;
                    Row2 = _midR - lenR;
                    Col2 = _midC - lenC;
                    break;
            }
            _arrow = ShapeHelper.GenLineArrow(Row1, Col1, Row2, Col2, OSize * 5);
            Y1 = Row1 * _matrix3D.Pitch;
            X1 = Col1 * _matrix3D.Pitch;
            Y2 = Row2 * _matrix3D.Pitch;
            X2 = Col2 * _matrix3D.Pitch;
        }
        
        public override HRegion GetRegion()
        {
            HRegion region = new HRegion();
            region.GenRegionLine(Row1, Col1, Row2, Col2);
            return region;
        }
    }
}
