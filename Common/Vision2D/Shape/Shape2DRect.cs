using HalconDotNet;

namespace Vision2D
{
    public class Shape2DRect : Shape2DBase
    {
        public double Row1 { get; set; }

        public double Col1 { get; set; }

        public double Row2 { get; set; }

        public double Col2 { get; set; }

        private double _midR;

        private double _midC;

        public Shape2DRect()
        {
            _handlesNum = 5; // 4 corner points + midpoint
            _activeHandleIdx = 4;
            Type = EShape2DType.RECT;
            Color = "yellow";
            IsEditable = true;
            IsVisible = true;
        }

        public Shape2DRect(double row1, double col1, double row2, double col2) : this()
        {
            SetShape(row1, col1, row2, col2);
        }

        public override void Init(HWindow window, HImage image)
        {
            if (Row1 == 0 && Col1 == 0 && Row2 == 0 && Col2 == 0)
            {
                if (window == null)
                {
                    if (image == null)
                    {
                        Col1 = 100;
                        Row1 = 100;
                        Col2 = 200;
                        Row2 = 200;
                    }
                    else
                    {
                        image.GetImageSize(out int width, out int height);
                        Col1 = width / 3;
                        Row1 = height / 3;
                        Col2 = width / 2;
                        Row2 = height / 2;
                    }
                }
                else
                {
                    window.GetPart(out int row1, out int col1, out int row2, out int col2);
                    Col1 = col1 + (col2 - col1) / 2.5;
                    Row1 = row1 + (row2 - row1) / 2.5;
                    Col2 = col2 - (col2 - col1) / 2.5;
                    Row2 = row2 - (row2 - row1) / 2.5;
                }
            }
            _midR = (Row1 + Row2) / 2.0;
            _midC = (Col1 + Col2) / 2.0;
        }

        public void SetShape(double row, double col, double width, double length)
        {
            Row1 = row;
            Col1 = col;
            Row2 = row + length;
            Col2 = col + width;
            _midR = (Row1 + Row2) / 2.0;
            _midC = (Col1 + Col2) / 2.0;
        }

        public override void Paint(HWindow window)
        {
            if (!IsVisible) return;
            window.SetDraw("margin");
            window.SetLineWidth(1);
            window.SetColor(Color);
            window.DispRectangle1(Row1, Col1, Row2, Col2);

            if (!IsEditable) return;
            window.DispRectangle2(Row1, Col1, 0, OSize, OSize);
            window.DispRectangle2(Row1, Col2, 0, OSize, OSize);
            window.DispRectangle2(Row2, Col2, 0, OSize, OSize);
            window.DispRectangle2(Row2, Col1, 0, OSize, OSize);
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

            _midR = ((Row2 - Row1) / 2) + Row1;
            _midC = ((Col2 - Col1) / 2) + Col1;

            val[0] = HMisc.DistancePp(y, x, Row1, Col1); // upper left 
            val[1] = HMisc.DistancePp(y, x, Row1, Col2); // upper right 
            val[2] = HMisc.DistancePp(y, x, Row2, Col2); // lower right 
            val[3] = HMisc.DistancePp(y, x, Row2, Col1); // lower left 
            val[4] = HMisc.DistancePp(y, x, _midR, _midC); // midpoint 

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
            double tmp;

            switch (_activeHandleIdx)
            {
                case 0: // upper left 
                    Row1 = newY;
                    Col1 = newX;
                    break;
                case 1: // upper right 
                    Row1 = newY;
                    Col2 = newX;
                    break;
                case 2: // lower right 
                    Row2 = newY;
                    Col2 = newX;
                    break;
                case 3: // lower left
                    Row2 = newY;
                    Col1 = newX;
                    break;
                case 4: // midpoint 
                    len1 = ((Row2 - Row1) / 2);
                    len2 = ((Col2 - Col1) / 2);

                    Row1 = newY - len1;
                    Row2 = newY + len1;

                    Col1 = newX - len2;
                    Col2 = newX + len2;

                    break;
            }

            if (Row2 <= Row1)
            {
                tmp = Row1;
                Row1 = Row2;
                Row2 = tmp;
            }

            if (Col2 <= Col1)
            {
                tmp = Col1;
                Col1 = Col2;
                Col2 = tmp;
            }

            _midR = ((Row2 - Row1) / 2) + Row1;
            _midC = ((Col2 - Col1) / 2) + Col1;
        }

        public override HRegion GetRegion()
        {
            HRegion region = new HRegion();
            region.GenRectangle1(Row1, Col1, Row2, Col2);
            return region;
        }
    }
}
