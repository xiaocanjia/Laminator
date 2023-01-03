using HalconDotNet;

namespace Vision2D
{
    class ShapeHelper
    {
        public static HXLDCont GenLineArrow(double row1, double col1, double row2, double col2, double oSize)
        {
            HXLDCont arrow = new HXLDCont();
            double length, dr, dc, halfHW;
            double rRow1, cCol1, rowP1, colP1, rowP2, colP2;

            double headLength = oSize;
            double headWidth = oSize;
            
            arrow.Dispose();
            arrow.GenEmptyObj();

            rRow1 = row1 + (row2 - row1) * 0.9;
            cCol1 = col1 + (col2 - col1) * 0.9;

            length = HMisc.DistancePp(rRow1, cCol1, row2, col2);
            if (length == 0)
                length = -1;

            dr = (row2 - rRow1) / length;
            dc = (col2 - cCol1) / length;

            halfHW = headWidth / 2.0;
            rowP1 = rRow1 + (length - headLength) * dr + halfHW * dc;
            rowP2 = rRow1 + (length - headLength) * dr - halfHW * dc;
            colP1 = cCol1 + (length - headLength) * dc - halfHW * dr;
            colP2 = cCol1 + (length - headLength) * dc + halfHW * dr;

            if (length == -1)
                arrow.GenContourPolygonXld(rRow1, cCol1);
            else
                arrow.GenContourPolygonXld(new HTuple(new double[] { rowP1, row2, rowP2, row2 }), 
                                           new HTuple(new double[] { colP1, col2, colP2, col2 }));

            return arrow;
        }
    }
}
