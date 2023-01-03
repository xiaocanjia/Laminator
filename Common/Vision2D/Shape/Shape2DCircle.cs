using System;
using HalconDotNet;

namespace Vision2D
{
    public class Shape2DCircle : Shape2DBase
    {
        public double Row { get; set; }

        public double Col { get; set; }

        public double Radius { get; set; }

        private double _row;

        private double _col;

        public Shape2DCircle()
        {
            _handlesNum = 2; // 1 corner points + midpoint
            _activeHandleIdx = 2;
            Type = EShape2DType.CIRCLE;
            Color = "yellow";
            IsEditable = true;
            IsVisible = true;
        }

        public Shape2DCircle(double row, double col, double radiusPix) : this()
        {
            SetShape(row, col, radiusPix);
        }

        public override void Init(HWindow window, HImage image)
        {
            if (Row == 0 && Col == 0 && Radius == 0)
            {
                if (window == null)
                {
                    if (image == null)
                    {
                        Row = 100;
                        Col = 100;
                        Radius = 100;
                    }
                    else
                    {
                        image.GetImageSize(out int width, out int height);
                        Row = height / 2;
                        Col = width / 2;
                        Radius = width / 8;
                    }
                }
                else
                {
                    window.GetPart(out int row1, out int col1, out int row2, out int col2);
                    Col = col1 + (col2 - col1) / 2;
                    Row = row1 + (row2 - row1) / 2;
                    Radius = (row2 - row1) / 8;
                }
            }
            SetShape(Row, Col, Radius);
        }

        public void SetShape(double row, double col, double radiusPix)
        {
            Row = row;
            Col = col;
            Radius = radiusPix;
            _row = Row;
            _col = Col + radiusPix;
        }

        public override void Paint(HWindow window)
        {
            if (!IsVisible) return;
            window.SetDraw("margin");
            window.SetLineWidth(1);
            window.SetColor(Color);
            window.DispCircle(Row, Col, Radius);

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
                    Radius = Math.Sqrt((Row - _row) * (Row - _row) + (Col - _col) * (Col - _col));
                    break;
            }
        }

        public override HRegion GetRegion()
        {
            HRegion region = new HRegion();
            region.GenCircle(Row, Col, Radius);
            return region;
        }
    }
}
