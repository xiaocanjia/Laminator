using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace AlgoLib
{
    public class Algo2D
    {
        public static double[] FitCircle(HImage image, HRegion region, double minGray, double maxGray, double minArea, double maxArea)
        {
            try
            {
                HImage imageReduced = image.ReduceDomain(region);
                HRegion regionThreshold = imageReduced.Threshold(minGray, maxGray);
                HRegion regionConnection = regionThreshold.Connection();
                HRegion regionSelected = regionConnection.SelectShape("area", "and", minArea, maxArea);
                HRegion regionClosing = regionSelected.ClosingCircle(4.0);
                HXLDCont cont = regionClosing.GenContourRegionXld("border_holes");
                cont = cont.SelectShapeXld("circularity", "or", 0.8, 1.0);
                if (cont.CountObj() < 1) return null;
                cont.FitCircleContourXld("algebraic", -1, 0, 0, 3, 2, out double row, out double col, out double radius, out double startPhi, out double endPhi, out string PointOrder);
                return new double[3] { row, col, radius };
            }
            catch
            {
                return null;
            }
        }

        public static void GetLineContour(HImage image, int startCol, int startRow, int endCol, int endRow, double minGray, double maxGray, int dir, bool isRising, out int[] contRow, out int[] contCol)
        {
            List<int> xList = new List<int>();
            List<int> yList = new List<int>();
            startCol = startCol < 0 ? 0 : startCol;
            startRow = startRow < 0 ? 0 : startRow;
            endCol = endCol < 0 ? 0 : endCol;
            endRow = endRow < 0 ? 0 : endRow;
            IntPtr p = image.GetImagePointer1(out string type, out int col, out int row);
            byte[] data = new byte[col * row];
            Marshal.Copy(p, data, 0, col * row);
            switch (dir)
            {
                case 0:
                    if (isRising)
                    {
                        for (int indexRow = startRow; indexRow < endRow; indexRow++)
                        {
                            for (int indexCol = startCol; indexCol < endCol; indexCol++)
                            {
                                if (data[indexRow * col + indexCol] < minGray && data[indexRow * col + (indexCol + 2)] > minGray)
                                {
                                    xList.Add(indexCol + 1);
                                    yList.Add(indexRow);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int indexRow = startRow; indexRow < endRow; indexRow++)
                        {
                            for (int indexCol = startCol; indexCol < endCol; indexCol++)
                            {
                                if (data[indexRow * col + indexCol] > minGray && data[indexRow * col + indexCol] < maxGray && data[indexRow * col + (indexCol + 2)] < minGray)
                                {
                                    xList.Add(indexCol + 1);
                                    yList.Add(indexRow);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    if (isRising)
                    {
                        for (int indexRow = startRow; indexRow < endRow; indexRow++)
                        {
                            for (int indexCol = endCol; indexCol > startCol; indexCol++)
                            {
                                if (data[indexRow * col + indexCol] > minGray && data[indexRow * col + indexCol] < maxGray && data[indexRow * col + (indexCol - 2)] < minGray)
                                {
                                    xList.Add(indexCol - 1);
                                    yList.Add(indexRow);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int indexRow = startRow; indexRow < endRow; indexRow++)
                        {
                            for (int indexCol = endCol; indexCol > startCol; indexCol++)
                            {
                                if (data[indexRow * col + indexCol] > minGray && data[indexRow * col + indexCol] < maxGray && data[indexRow * col + (indexCol + 2)] < minGray)
                                {
                                    xList.Add(indexCol - 1);
                                    yList.Add(indexRow);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    if (isRising)
                    {
                        for (int indexCol = startCol; indexCol < endCol; indexCol++)
                        {
                            for (int indexRow = startRow; indexRow < endRow; indexRow++)
                            {
                                if (data[indexRow * col + indexCol] < minGray && data[(indexRow + 2) * col + indexCol] > minGray)
                                {
                                    xList.Add(indexCol);
                                    yList.Add(indexRow - 1);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int indexCol = startCol; indexCol < endCol; indexCol++)
                        {
                            for (int indexRow = startRow; indexRow < endRow; indexRow++)
                            {
                                if (data[indexRow * col + indexCol] > minGray && data[indexRow * col + indexCol] < maxGray && data[(indexRow + 2) * col + indexCol] < minGray)
                                {
                                    xList.Add(indexCol);
                                    yList.Add(indexRow + 1);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    if (isRising)
                    {
                        for (int indexCol = startCol; indexCol < endCol; indexCol++)
                        {
                            for (int indexRow = endRow; indexRow > startRow; indexRow--)
                            {
                                if (data[indexRow * col + indexCol] > minGray && data[indexRow * col + indexCol] < maxGray && data[(indexRow + 2) * col + indexCol] < minGray)
                                {
                                    xList.Add(indexCol);
                                    yList.Add(indexRow + 1);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int indexCol = startCol; indexCol < endCol; indexCol++)
                        {
                            for (int indexRow = endRow; indexRow > startRow; indexRow--)
                            {
                                if (data[indexRow * col + indexCol] > minGray && data[indexRow * col + indexCol] < maxGray && data[(indexRow - 2) * col + indexCol] < minGray)
                                {
                                    xList.Add(indexCol);
                                    yList.Add(indexRow - 1);
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
            contCol = xList.ToArray();
            contRow = yList.ToArray();
        }

        public static double[] FitLine(int[] xArr, int[] yArr)
        {
            if (xArr.Length < 2 || yArr.Length < 2)
                return null;
            HXLDCont contour = new HXLDCont(new HTuple(xArr), new HTuple(yArr));
            contour.FitLineContourXld("gauss", -1, 0, 5, 2, out double xBegin, out double yBegin, out double xEnd, out double yEnd, out double a, out double b, out double c);
            return new double[3] { a, b, -c };
        }
    }
}
