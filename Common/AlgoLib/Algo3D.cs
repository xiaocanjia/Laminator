using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HalconDotNet;
using BSLib;

namespace AlgoLib
{
    public enum EPointType
    {
        XMAX,
        XMIN,
        YMAX,
        YMIN,
        ZMAX,
        ZMIN,
        ZMEAN,
        ZMEDIAN,
        CENTER
    }

    public class Algo3D
    {
        public static int GetRegionPoint(HObjectModel3D object3D, EPointType type, out HTuple point)
        {
            if (object3D == null)
            {
                point = null;
                return -1;
            }

            HTuple coordX = object3D.GetObjectModel3dParams("point_coord_x");
            HTuple coordY = object3D.GetObjectModel3dParams("point_coord_y");
            HTuple coordZ = object3D.GetObjectModel3dParams("point_coord_z");

            switch (type)
            {
                case EPointType.XMAX:
                    HTuple indexMaxX = coordX.TupleFindFirst(coordX.TupleMax());
                    point = new HTuple(coordX.TupleMax(), coordY[indexMaxX], coordZ[indexMaxX]);
                    return 0;
                case EPointType.XMIN:
                    HTuple indexMinX = coordX.TupleFindFirst(coordX.TupleMin());
                    point = new HTuple(coordX.TupleMin(), coordY[indexMinX], coordZ[indexMinX]);
                    return 0;
                case EPointType.YMAX:
                    HTuple indexMaxY = coordY.TupleFindFirst(coordY.TupleMax());
                    point = new HTuple(coordX[indexMaxY], coordY.TupleMax(), coordZ[indexMaxY]);
                    return 0;
                case EPointType.YMIN:
                    HTuple indexMinY = coordY.TupleFindFirst(coordY.TupleMin());
                    point = new HTuple(coordX[indexMinY], coordY.TupleMin(), coordZ[indexMinY]);
                    return 0;
                case EPointType.ZMAX:
                    HTuple indexMaxZ = coordZ.TupleFindFirst(coordZ.TupleMax());
                    point = new HTuple(coordX[indexMaxZ], coordY[indexMaxZ], coordZ.TupleMax());
                    return 0;
                case EPointType.ZMIN:
                    HTuple indexMinZ = coordZ.TupleFindFirst(coordZ.TupleMin());
                    point = new HTuple(coordX[indexMinZ], coordY[indexMinZ], coordZ.TupleMin());
                    return 0;
                case EPointType.ZMEAN:
                    point = object3D.GetObjectModel3dParams("center");
                    point[2] = coordZ.TupleMean();
                    return 0;
                case EPointType.ZMEDIAN:
                    point = object3D.GetObjectModel3dParams("center");
                    point[2] = coordZ.TupleMedian();
                    return 0;
                case EPointType.CENTER:
                    point = object3D.GetObjectModel3dParams("center");
                    return 0;
                default:
                    point = null;
                    return -1;
            }
        }

        public static int GetFitPlane(float[] xArr, float[] yArr, float[] zArr, out double[] planeParam)
        {
            if (xArr.Length == 0 || yArr.Length == 0 || zArr.Length == 0)
            {
                planeParam = null;
                return -1;
            }
            HObjectModel3D object3D = new HObjectModel3D(new HTuple(xArr), new HTuple(yArr), new HTuple(zArr));
            HTuple genParamName = new HTuple(new object[2] { "primitive_type", "fitting_algorithm" });
            HTuple genParamValue = new HTuple(new object[2] { "plane", "least_squares_tukey" });
            HObjectModel3D plane = object3D.FitPrimitivesObjectModel3d(genParamName, genParamValue);
            planeParam = plane.GetObjectModel3dParams("primitive_parameter").ToDArr();
            //始终让平面法向量朝上
            if (planeParam[2] < 0)
            {
                planeParam[0] = -planeParam[0];
                planeParam[1] = -planeParam[1];
                planeParam[2] = -planeParam[2];
            }
            else
            {
                planeParam[3] = -planeParam[3];
            }
            return 0;
        }

        /// <summary>
        /// 拟合直线
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="lineParam"></param>
        /// <param name="filterRatio">过滤离第一次得到的直线较远的点的比例</param>
        /// <returns>直线度</returns>
        public static double GetFitLine(double[] xArr, double[] yArr, out double[] lineParam, out double[] newX, out double[] newY, double filterRatio = 0)
        {
            lineParam = null;
            newX = null;
            newY = null;
            if (xArr.Length < 2 || yArr.Length < 2)
                return 0;
            HXLDCont contour = new HXLDCont(new HTuple(xArr), new HTuple(yArr));
            contour.FitLineContourXld("gauss", -1, 0, 5, 2, out double xBegin, out double yBegin, out double xEnd, out double yEnd, out double a, out double b, out double c);
            List<double> xList = new List<double>();
            List<double> yList = new List<double>();
            List<double> distList = new List<double>();
            for (int i = 0; i < xArr.Length; i++)
            {
                double dist = Math.Abs(a * xArr[i] + b * yArr[i] - c) / Math.Sqrt(a * a + b * b);
                distList.Add(dist);
            }
            distList.Sort();
            double maxDist = distList[(int)(distList.Count * (1 - filterRatio) - 1)];
            for (int i = 0; i < xArr.Length; i++)
            {
                double dist = Math.Abs(a * xArr[i] + b * yArr[i] - c) / Math.Sqrt(a * a + b * b);
                distList.Add(Math.Abs(a * xArr[i] + b * yArr[i] - c) / Math.Sqrt(a * a + b * b));
                if (dist <= maxDist)
                {
                    xList.Add(xArr[i]);
                    yList.Add(yArr[i]);
                }
            }
            if (xList.Count < 2 || yList.Count < 2)
                return 0;
            newX = xList.ToArray();
            newY = yList.ToArray();
            contour = new HXLDCont(new HTuple(newX), new HTuple(newY));
            contour.FitLineContourXld("gauss", -1, 0, 5, 2, out xBegin, out yBegin, out xEnd, out yEnd, out a, out b, out c);
            lineParam = new double[3] { a, b, -c };
            List<double> dists = new List<double>();
            for (int i = 0; i < xArr.Length; i++)
                dists.Add(GetPointToLineDist(xArr[i], yArr[i], lineParam));
            return dists.Max() - dists.Min();
        }

        public static int GetPointsToPlaneDists(float[] xList, float[] yList, float[] zList, double[] planeParam, out List<float> dists)
        {
            dists = new List<float>();
            if (xList == null || yList == null || zList == null)
                return -1;
            if (planeParam == null)
            {
                dists = new List<float>(zList);
                return 0;
            }
            HTuple coordX = new HTuple(xList);
            HTuple coordY = new HTuple(yList);
            HTuple coordZ = new HTuple(zList);
            int num = coordZ.Length;
            HTuple row = HTuple.TupleGenSequence(0, num - 1, 1);
            HTuple col0 = HTuple.TupleGenConst(num, 0);
            HTuple col1 = HTuple.TupleGenConst(num, 1);
            HTuple col2 = HTuple.TupleGenConst(num, 2);
            HTuple col3 = HTuple.TupleGenConst(num, 3);
            HMatrix coordMatrix = new HMatrix(num, 4, 0.0);
            coordMatrix.SetValueMatrix(row, col0, coordX);
            coordMatrix.SetValueMatrix(row, col1, coordY);
            coordMatrix.SetValueMatrix(row, col2, coordZ);
            coordMatrix.SetValueMatrix(row, col3, col1);
            HMatrix planeMatrix = new HMatrix(4, 1, new HTuple(planeParam));
            double fraction = 1.0 / Math.Sqrt(planeParam[0] * planeParam[0] + planeParam[1] * planeParam[1] + planeParam[2] * planeParam[2]);
            HMatrix distMatrix = coordMatrix.MultMatrix(planeMatrix, "AB");
            distMatrix = distMatrix.ScaleMatrix(fraction);
            dists.AddRange(distMatrix.GetFullMatrix().ToFArr());
            return 0;
        }

        public static int AdjustPlane(JMatrix3D srcMat, float[] planeParam)
        {
            if (srcMat == null || planeParam == null)
                return -1;
            HImage imageX = new HImage();
            imageX.GenImageSurfaceFirstOrder("real", 0, srcMat.Pitch, 0, 0, 0, srcMat.Column, srcMat.Row);
            IntPtr p = imageX.GetImagePointer1(out string t, out int w, out int h);
            float[] xArr = new float[w * h];
            Marshal.Copy(p, xArr, 0, w * h);
            HImage imageY = new HImage();
            imageY.GenImageSurfaceFirstOrder("real", srcMat.Pitch, 0, 0, 0, 0, srcMat.Column, srcMat.Row);
            p = imageY.GetImagePointer1(out t, out w, out h);
            float[] yArr = new float[w * h];
            Marshal.Copy(p, yArr, 0, w * h);

            HTuple coordX = new HTuple(xArr);
            HTuple coordY = new HTuple(yArr);
            HTuple coordZ = new HTuple(srcMat.HeightData);
            DateTime start = DateTime.Now;
            int taskCount = 5;
            Task[] tasks = new Task[taskCount];
            HTuple[] distList = new HTuple[taskCount];
            int singleNum = coordZ.Length / taskCount;
            for (int i = 0; i < taskCount - 1; i++)
            {
                tasks[i] = new Task(new Action<object>((index) =>
                {
                    distList[(int)index] = GetSingleDists(coordX, coordY, coordZ, singleNum * (int)index, singleNum, planeParam);
                }), i);
                tasks[i].Start();
            }
            tasks[taskCount - 1] = new Task(() =>
            {
                int num = coordZ.Length - singleNum * (taskCount - 1);
                distList[taskCount - 1] = GetSingleDists(coordX, coordY, coordZ, singleNum * (taskCount - 1), num, planeParam);
            });
            tasks[taskCount - 1].Start();
            Task.WaitAll(tasks);
            HTuple dists = new HTuple();
            for (int i = 0; i < taskCount; i++)
                dists.Append(distList[i]);
            srcMat.HeightData = dists.ToFArr();
            DateTime end = DateTime.Now;
            double span = (end - start).TotalMilliseconds;
            return 0;
        }

        private static HTuple GetSingleDists(HTuple coordX, HTuple coordY, HTuple coordZ, HTuple start, HTuple length, float[] planeParam)
        {
            HTuple coordX1 = coordX.TupleSelectRange(start, start + length - 1);
            HTuple coordY1 = coordY.TupleSelectRange(start, start + length - 1);
            HTuple coordZ1 = coordZ.TupleSelectRange(start, start + length - 1);
            HTuple row = HTuple.TupleGenSequence(0, length - 1, 1);
            HTuple col0 = HTuple.TupleGenConst(length, 0);
            HTuple col1 = HTuple.TupleGenConst(length, 1);
            HTuple col2 = HTuple.TupleGenConst(length, 2);
            HTuple col3 = HTuple.TupleGenConst(length, 3);
            HMatrix coordMatrix = new HMatrix(length, 4, 0.0);
            coordMatrix.SetValueMatrix(row, col0, coordX1);
            coordMatrix.SetValueMatrix(row, col1, coordY1);
            coordMatrix.SetValueMatrix(row, col2, coordZ1);
            coordMatrix.SetValueMatrix(row, col3, col1);
            double fraction = 1 / Math.Sqrt(planeParam[0] * planeParam[0] + planeParam[1] * planeParam[1] + planeParam[2] * planeParam[2]);
            HMatrix planeMatrix = new HMatrix(4, 1, new HTuple(planeParam));
            HMatrix distMatrix = coordMatrix.MultMatrix(planeMatrix, "AB").ScaleMatrix(fraction);
            coordMatrix.Dispose();
            return distMatrix.GetFullMatrix();
        }

        public static int GetProfileData(HObjectModel3D object3D, HTuple startIndex, HTuple endIndex, out HTuple profileData)
        {
            if (object3D == null || startIndex == null || endIndex == null)
            {
                profileData = null;
                return -1;
            }

            int profile_num = 0;
            bool isDirtX = false;
            if ((endIndex[0] - startIndex[0]).TupleAbs() >= (endIndex[1] - startIndex[1]).TupleAbs())
            {
                profile_num = (endIndex[0] - startIndex[0]).TupleAbs() + 1;
                isDirtX = true;
            }
            else
            {
                profile_num = (endIndex[1] - startIndex[1]).TupleAbs() + 1;
                isDirtX = false;
            }

            int begin_i = (isDirtX) ? (startIndex[0] < endIndex[0]) ? startIndex[1] : endIndex[1] :
                (startIndex[1] < endIndex[1]) ? startIndex[1] : endIndex[1];
            int begin_j = (isDirtX) ? (startIndex[0] < endIndex[0]) ? startIndex[0] : endIndex[0] :
                (startIndex[1] < endIndex[1]) ? startIndex[0] : endIndex[0];
            int end_i = (isDirtX) ? (startIndex[0] < endIndex[0]) ? endIndex[1] : startIndex[1] :
                  (startIndex[1] < endIndex[1]) ? endIndex[1] : startIndex[1];
            int end_j = (isDirtX) ? (startIndex[0] < endIndex[0]) ? endIndex[0] : startIndex[0] :
                (startIndex[1] < endIndex[1]) ? endIndex[0] : startIndex[0];

            HTuple coordZ = object3D.GetObjectModel3dParams("point_coord_z");
            HTuple size = object3D.GetObjectModel3dParams("mapping_size");
            HTuple row = size[1];
            HTuple col = size[0];
            profileData = new HTuple();
            if (begin_i == end_i)
            {
                int count = end_j - begin_j + 1;
                HTuple j = HTuple.TupleGenSequence(begin_j, end_j, 1);
                HMatrix matrixJ = new HMatrix(count, 1, j);
                HMatrix matrixC = new HMatrix(count, 1, begin_i * col);
                HMatrix matrixIdx = matrixJ.AddMatrix(matrixC);
                HTuple index = matrixIdx.GetFullMatrix();
                profileData = coordZ[index.TupleRound()];
                return 0;
            }

            double line_k = isDirtX ? (end_j - begin_j) / (double)((end_i - begin_i)) :
                (end_j - begin_j) / (double)(end_i - begin_i);
            double line_b = isDirtX ? (begin_j - (line_k * begin_i)) :
                (begin_j - (line_k * begin_i));
            if (isDirtX == false)
            {
                if (begin_i >= row)
                {
                    profileData = null;
                    return -1;
                }
                if (end_i >= row)
                    end_i = row - 1;
                int count = end_i - begin_i + 1;
                HTuple i = HTuple.TupleGenSequence(begin_i, end_i, 1);
                HMatrix matrixI = new HMatrix(count, 1, i);
                HMatrix matrixB = new HMatrix(count, 1, line_b);
                HMatrix matrixJ = matrixI.ScaleMatrix(line_k).AddMatrix(matrixB);
                HMatrix matrixIdx = matrixI.ScaleMatrix(col).AddMatrix(matrixJ);
                HTuple index = matrixIdx.GetFullMatrix();
                profileData = coordZ[index.TupleRound()];
                return 0;
            }
            else
            {
                if (begin_j >= col)
                {
                    profileData = null;
                    return -1;
                }
                if (end_j >= col)
                    end_j = col - 1;
                int count = end_j - begin_j + 1;
                HTuple j = HTuple.TupleGenSequence(begin_j, end_j, 1);
                HMatrix matrixJ = new HMatrix(count, 1, j);
                HMatrix matrixIB = new HMatrix(count, 1, -line_b);
                HMatrix matrixI = matrixJ.AddMatrix(matrixIB).ScaleMatrix(1 / line_k);
                HMatrix matrixIdx = matrixI.ScaleMatrix(col).AddMatrix(matrixJ);
                HTuple index = matrixIdx.GetFullMatrix();
                profileData = coordZ[index.TupleRound()];
                float[] a = profileData.ToFArr();
                return 0;
            }
        }

        /// <summary>
        /// 降采样
        /// </summary>
        /// <param name="object3D"></param>
        /// <param name="pointsCount"></param>
        /// <returns></returns>
        public static HObjectModel3D SampleObject3D(HObjectModel3D object3D, int pointsCount = 100000)
        {
            if (object3D == null)
                return null;

            HOperatorSet.ObjectModel3dToXyz(out HObject X, out HObject Y, out HObject Z, object3D, "from_xyz_map", new HCamPar(), new HPose());
            HImage imageX = new HImage(X);
            HImage imageY = new HImage(Y);
            HImage imageZ = new HImage(Z);
            IntPtr p = imageX.GetImagePointer1(out HTuple t, out HTuple w, out HTuple h);
            imageX.Dispose();
            int len = w * h;
            float[] x = new float[len];
            Marshal.Copy(p, x, 0, len);
            p = imageY.GetImagePointer1(out t, out w, out h);
            imageY.Dispose();
            float[] y = new float[len];
            Marshal.Copy(p, y, 0, len);
            p = imageZ.GetImagePointer1(out t, out w, out h);
            imageZ.Dispose();
            float[] z = new float[len];
            Marshal.Copy(p, z, 0, len);
            int row = h.I;
            int col = w.I;
            if (len < pointsCount)
                return null;
            int times = (int)Math.Round(Math.Sqrt(row * col / pointsCount));
            int intervalX = 0;
            int intervalY = 0;
            //判断小数位是不是大于0.5，大于0.5就不管，小于0.5则Y方向的interval加1，这样可以更接近降采样要达到的点数
            if (times < Math.Sqrt(row * col / pointsCount))
            {
                intervalX = times;
                intervalY = times + 1;
            }
            else
            {
                intervalX = times;
                intervalY = times;
            }
            int newRow = row / intervalY;
            int newCol = col / intervalX;
            bool hasLuminace = Convert.ToBoolean(object3D.GetObjectModel3dParams("has_extended_attribute").S);
            float[] luminace = new float[len];
            int index = 0;
            if (hasLuminace)
            {
                float[] _luminace = object3D.GetObjectModel3dParams("&intensity").ToFArr();
                for (int i = 0; i < len; i++)
                {
                    if (z[i] == 0)
                        luminace[i] = 0;
                    else
                        luminace[i] = _luminace[index++];
                }
            }
            else
            {
                luminace = null;
            }

            float[] newX = new float[newRow * newCol];
            float[] newY = new float[newRow * newCol];
            float[] newZ = new float[newRow * newCol];
            List<float> luminaceArray = new List<float>();
            DateTime start = DateTime.Now;
            for (int i = 0; i < newRow; i++)
            {
                for (int j = 0; j < newCol; j++)
                {
                    newX[i * newCol + j] = x[i * intervalY * col + j * intervalX];
                    newY[i * newCol + j] = y[i * intervalY * col + j * intervalX];
                    if (z[i * intervalY * col + j * intervalX] != 0)
                    {
                        newZ[i * newCol + j] = z[i * intervalY * col + j * intervalX];
                        if (hasLuminace)
                            luminaceArray.Add(luminace[i * intervalY * col + j * intervalX]);
                    }
                    else
                    {
                        newZ[i * newCol + j] = float.NaN;
                    }
                }
            }
            DateTime end = DateTime.Now;
            double span = (end - start).TotalMilliseconds;
            HImage newImageX = new HImage();
            HImage newImageY = new HImage();
            HImage newImageZ = new HImage();
            unsafe
            {
                fixed (float* xp = &newX[0], yp = &newY[0], zp = &newZ[0])
                {
                    newImageX.GenImage1("real", newCol, newRow, new IntPtr(xp));
                    newImageY.GenImage1("real", newCol, newRow, new IntPtr(yp));
                    newImageZ.GenImage1("real", newCol, newRow, new IntPtr(zp));
                }
            }
            HObjectModel3D newObject3D = new HObjectModel3D();
            newObject3D.XyzToObjectModel3d(newImageX, newImageY, newImageZ);
            newImageX.Dispose();
            newImageY.Dispose();
            newImageZ.Dispose();
            int count = newObject3D.GetObjectModel3dParams("num_points");
            if (hasLuminace)
                newObject3D.SetObjectModel3dAttribMod((HTuple)"&intensity", "points", new HTuple(luminaceArray.ToArray()));
            return newObject3D;
        }

        /// <summary>
        /// 降采样
        /// </summary>
        /// <param name="object3D"></param>
        /// <param name="pointsCount"></param>
        /// <returns></returns>
        public static HObjectModel3D SampleObject3D(HObjectModel3D object3D, double ratio = 0.01)
        {
            if (object3D == null)
                return null;

            HOperatorSet.ObjectModel3dToXyz(out HObject X, out HObject Y, out HObject Z, object3D, "from_xyz_map", new HCamPar(), new HPose());
            HImage imageX = new HImage(X);
            HImage imageY = new HImage(Y);
            HImage imageZ = new HImage(Z);
            IntPtr p = imageX.GetImagePointer1(out HTuple t, out HTuple w, out HTuple h);
            imageX.Dispose();
            int len = w * h;
            float[] x = new float[len];
            Marshal.Copy(p, x, 0, len);
            p = imageY.GetImagePointer1(out t, out w, out h);
            imageY.Dispose();
            float[] y = new float[len];
            Marshal.Copy(p, y, 0, len);
            p = imageZ.GetImagePointer1(out t, out w, out h);
            imageZ.Dispose();
            float[] z = new float[len];
            Marshal.Copy(p, z, 0, len);
            int row = h.I;
            int col = w.I;
            int newRow = (int)(row * Math.Sqrt(ratio));
            int newCol = (int)(col * Math.Sqrt(ratio));
            int intervalX = row / newRow;
            int intervalY = col / newCol;
            bool hasLuminace = Convert.ToBoolean(object3D.GetObjectModel3dParams("has_extended_attribute").S);
            float[] luminace = new float[len];
            int index = 0;
            if (hasLuminace)
            {
                float[] _luminace = object3D.GetObjectModel3dParams("&intensity").ToFArr();
                for (int i = 0; i < len; i++)
                {
                    if (z[i] == 0)
                        luminace[i] = 0;
                    else
                        luminace[i] = _luminace[index++];
                }
            }
            else
            {
                luminace = null;
            }

            float[] newX = new float[newRow * newCol];
            float[] newY = new float[newRow * newCol];
            float[] newZ = new float[newRow * newCol];
            List<float> luminaceArray = new List<float>();
            DateTime start = DateTime.Now;
            for (int i = 0; i < newRow; i++)
            {
                for (int j = 0; j < newCol; j++)
                {
                    newX[i * newCol + j] = x[i * intervalY * col + j * intervalX];
                    newY[i * newCol + j] = y[i * intervalY * col + j * intervalX];
                    if (z[i * intervalY * col + j * intervalX] != 0)
                    {
                        newZ[i * newCol + j] = z[i * intervalY * col + j * intervalX];
                        if (hasLuminace)
                            luminaceArray.Add(luminace[i * intervalY * col + j * intervalX]);
                    }
                    else
                    {
                        newZ[i * newCol + j] = float.NaN;
                    }
                }
            }
            DateTime end = DateTime.Now;
            double span = (end - start).TotalMilliseconds;
            HImage newImageX = new HImage();
            HImage newImageY = new HImage();
            HImage newImageZ = new HImage();
            unsafe
            {
                fixed (float* xp = &newX[0], yp = &newY[0], zp = &newZ[0])
                {
                    newImageX.GenImage1("real", newCol, newRow, new IntPtr(xp));
                    newImageY.GenImage1("real", newCol, newRow, new IntPtr(yp));
                    newImageZ.GenImage1("real", newCol, newRow, new IntPtr(zp));
                }
            }
            HObjectModel3D newObject3D = new HObjectModel3D();
            newObject3D.XyzToObjectModel3d(newImageX, newImageY, newImageZ);
            newImageX.Dispose();
            newImageY.Dispose();
            newImageZ.Dispose();
            int count = newObject3D.GetObjectModel3dParams("num_points");
            if (hasLuminace)
                newObject3D.SetObjectModel3dAttribMod((HTuple)"&intensity", "points", new HTuple(luminaceArray.ToArray()));
            return newObject3D;
        }

        public static float[] GetAreaCenter(JMatrix3D srcMatrix3D, HRegion ROI, double minHeight, double maxHeight, byte minLuminace, byte maxLuminace)
        {
            HImage imageZ = srcMatrix3D.GetImageZ();
            HImage imageL = srcMatrix3D.GetImageL();
            HRegion regionL = imageL.Threshold((double)minLuminace, maxLuminace);
            imageZ = imageZ.ReduceDomain(ROI);
            imageZ = imageZ.ReduceDomain(regionL);
            HRegion regionH = imageZ.Threshold(minHeight, maxHeight);
            HRegion regions = regionH.Connection();
            HTuple area = regions.AreaCenter(out HTuple r, out HTuple c);
            if (area.Length == 0 || area[0].D == 0)
                return null;
            float[] loc = new float[2];
            for (int i = 0; i < area.Length; i++)
            {
                if (area[i] == area.TupleMax().D)
                {
                    loc[0] = c[i].F * srcMatrix3D.Pitch;
                    loc[1] = r[i].F * srcMatrix3D.Pitch;
                }
            }
            return loc;
        }

        public static double[] FitCircle(double[] X, double[] Y, double minD, double maxD, double startAngle, double endAngle, out double[] newX, out double[] newY)
        {
            if (X.Length < 3 || Y.Length < 3)
            {
                newX = null;
                newY = null;
                return null;
            }
            double[] parameter = new double[3];
            newX = X;
            newY = Y;
            HXLDCont contour = new HXLDCont(new HTuple(Y), new HTuple(X));
            contour.FitCircleContourXld("geohuber", -1, 0, 0, 3, 2, out double row, out double col, out double radius, out double startPhi, out double endPhi, out string pointOrder);
            //List<double> listX = new List<double>();
            //List<double> listY = new List<double>();
            //double minR = minD / 2.0;
            //double maxR = maxD / 2.0;
            ////double angle = 60.0 / 180.0 * Math.PI;
            //double startX = col + radius * Math.Cos(startAngle / 180.0 * Math.PI);
            //double startY = row + radius * Math.Sin(startAngle / 180.0 * Math.PI);
            //double endX = col + radius * Math.Cos(endAngle / 180.0 * Math.PI);
            //double endY = row + radius * Math.Sin(endAngle / 180.0 * Math.PI);
            //double minX = Math.Min(startX, endX);
            //double maxX = Math.Max(startX, endX);
            //double minY = Math.Min(startY, endY);
            //double maxY = Math.Max(startY, endY);
            //for (int i = 0; i < X.Length; i++)
            //{
            //    if (startX != endX || startY != endY)
            //    {
            //        if (startY < endY)
            //        {
            //            if (startX < endX)
            //            {
            //                if (X[i] > startX && Y[i] < endY)
            //                    continue;
            //            }
            //            else
            //            {
            //                if (X[i] > endX && Y[i] > startY)
            //                    continue;
            //            }
            //        }
            //        else if (startY > endY)
            //        {
            //            if (startX < endX)
            //            {
            //                if (X[i] < endX && Y[i] < startY)
            //                    continue;
            //            }
            //            else
            //            {
            //                if (X[i] < startX && Y[i] > endY)
            //                    continue;
            //            }
            //        }
            //        else
            //        {
            //            if (Y[i] > endY)
            //                continue;
            //        }
            //    }
            //    double dist = Math.Sqrt((X[i] - col) * (X[i] - col) + (Y[i] - row) * (Y[i] - row));
            //    if (dist > radius - 0.08 && dist < radius + 0.08)
            //    {
            //        listX.Add(X[i]);
            //        listY.Add(Y[i]);
            //    }
            //}
            //newX = listX.ToArray();
            //newY = listY.ToArray();
            //if (newX.Length < 3 || newY.Length < 3)
            //{
            //    newX = null;
            //    newY = null;
            //    return null;
            //}
            //contour = new HXLDCont(new HTuple(newY), new HTuple(newX));
            //contour.FitCircleContourXld("algebraic", -1, 0, 0, 3, 2, out row, out col, out radius, out startPhi, out endPhi, out pointOrder);
            parameter[0] = col;
            parameter[1] = row;
            parameter[2] = radius;
            return parameter;
        }

        public static double[] FitCircle(JMatrix3D matrix3D, int col, int row, int radius, double minD, double maxD, double startAngle, double endAngle, double angleRes, int dir, bool isRising,
                                        bool isFilterAgain, double minLuminace, double maxLuminace, double minHeight, double maxHeight, out float[] contourX, out float[] contourY)
        {
            byte[] luminace = (byte[])matrix3D.LuminaceData.Clone();
            float[] z = (float[])matrix3D.HeightData.Clone();
            int minIndex = Convert.ToInt32(minD / 2.0 / matrix3D.Pitch);
            int maxIndex = Convert.ToInt32(maxD / 2.0 / matrix3D.Pitch);
            List<float> xList = new List<float>();
            List<float> yList = new List<float>();

            int startCol = col - radius < 0 ? 0 : col - radius;
            int startRow = row - radius < 0 ? 0 : row - radius;
            int endCol = col + radius > matrix3D.Column ? matrix3D.Column : col + radius;
            int endRow = row + radius > matrix3D.Row ? matrix3D.Row : row + radius;
            double sum = 0;
            int index1 = 0;
            for (int indexRow = startRow; indexRow < endRow; indexRow++)
            {
                for (int indexCol = startCol; indexCol < endCol; indexCol++)
                {
                    if (float.IsNaN(z[indexRow * matrix3D.Column + indexCol])) continue;
                    if (z[indexRow * matrix3D.Column + indexCol] > minHeight && luminace[indexRow * matrix3D.Column + indexCol] > minLuminace &&
                        z[indexRow * matrix3D.Column + indexCol] < maxHeight && luminace[indexRow * matrix3D.Column + indexCol] < maxLuminace)
                    {
                        sum += z[indexRow * matrix3D.Column + indexCol];
                        index1++;
                    }
                }
            }
            double avg = sum / index1;
            minHeight = isFilterAgain ? avg - 0.02 : minHeight;
            for (int indexRow = startRow; indexRow < endRow; indexRow++)
            {
                for (int indexCol = startCol; indexCol < endCol; indexCol++)
                {
                    if (z[indexRow * matrix3D.Column + indexCol] < minHeight || luminace[indexRow * matrix3D.Column + indexCol] < minLuminace ||
                        z[indexRow * matrix3D.Column + indexCol] > maxHeight || luminace[indexRow * matrix3D.Column + indexCol] > maxLuminace ||
                        float.IsNaN(z[indexRow * matrix3D.Column + indexCol]))
                    {
                        z[indexRow * matrix3D.Column + indexCol] = 0;
                        luminace[indexRow * matrix3D.Column + indexCol] = 0;
                    }
                }
            }
            int startIndex = Convert.ToInt32(startAngle / angleRes);
            int endIndex = Convert.ToInt32(endAngle / angleRes);
            if (dir == 0)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    for (int j = minIndex; j < maxIndex; j++)
                    {
                        double rad = i * angleRes / 180.0 * Math.PI;
                        int rowIndex = Convert.ToInt32(row + j * Math.Sin(rad));
                        int colIndex = Convert.ToInt32(col + j * Math.Cos(rad));
                        int lastRowIndex = Convert.ToInt32(row + (j - 1) * Math.Sin(rad));
                        int lastColIndex = Convert.ToInt32(col + (j - 1) * Math.Cos(rad));
                        if (isRising)
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] != 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                        else
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] == 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                    }
                }
            }
            else if (dir == 1)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    for (int j = maxIndex; j > minIndex; j--)
                    {
                        double rad = i * angleRes / 180.0 * Math.PI;
                        int rowIndex = Convert.ToInt32(row + j * Math.Sin(rad));
                        int colIndex = Convert.ToInt32(col + j * Math.Cos(rad));
                        int lastRowIndex = Convert.ToInt32(row + (j - 1) * Math.Sin(rad));
                        int lastColIndex = Convert.ToInt32(col + (j - 1) * Math.Cos(rad));
                        if (isRising)
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] != 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                        else
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] == 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                    }
                }
            }
            contourX = xList.ToArray();
            contourY = yList.ToArray();
            if (xList.Count == 0)
                return null;
            HXLDCont contour = new HXLDCont(new HTuple(contourY), new HTuple(contourX));
            double[] parameter = new double[3];
            contour.FitCircleContourXld("geohuber", -1, 0, 0, 5, 2, out parameter[1], out parameter[0], out parameter[2], out double startPhi, out double endPhi, out string pointOrder);
            if (parameter[0] + parameter[2] > matrix3D.Column * matrix3D.Pitch || parameter[1] + parameter[2] > matrix3D.Row * matrix3D.Pitch)
                return null;
            minIndex = Convert.ToInt32((parameter[2] - 0.2) / matrix3D.Pitch);
            maxIndex = Convert.ToInt32((parameter[2] + 0.2) / matrix3D.Pitch);
            xList.Clear();
            yList.Clear();
            if (dir == 0)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    for (int j = minIndex; j < maxIndex; j++)
                    {
                        double rad = i * angleRes / 180.0 * Math.PI;
                        int rowIndex = Convert.ToInt32(parameter[1] + j * Math.Sin(rad));
                        int colIndex = Convert.ToInt32(parameter[0] + j * Math.Cos(rad));
                        int lastRowIndex = Convert.ToInt32(parameter[1] + (j - 1) * Math.Sin(rad));
                        int lastColIndex = Convert.ToInt32(parameter[0] + (j - 1) * Math.Cos(rad));
                        if (isRising)
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] != 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                        else
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] == 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                    }
                }
            }
            else if (dir == 1)
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    for (int j = maxIndex; j > minIndex; j--)
                    {
                        double rad = i * angleRes / 180.0 * Math.PI;
                        int rowIndex = Convert.ToInt32(parameter[1] + j * Math.Sin(rad));
                        int colIndex = Convert.ToInt32(parameter[0] + j * Math.Cos(rad));
                        int lastRowIndex = Convert.ToInt32(parameter[1] + (j - 1) * Math.Sin(rad));
                        int lastColIndex = Convert.ToInt32(parameter[0] + (j - 1) * Math.Cos(rad));
                        if (isRising)
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] != 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                        else
                        {
                            if (z[rowIndex * matrix3D.Column + colIndex] == 0)
                            {
                                xList.Add(colIndex * matrix3D.Pitch);
                                yList.Add(rowIndex * matrix3D.Pitch);
                                break;
                            }
                        }
                    }
                }
            }
            contourX = xList.ToArray();
            contourY = yList.ToArray();
            if (xList.Count < 3)
                return null;
            contour = new HXLDCont(new HTuple(contourY), new HTuple(contourX));
            parameter = new double[3];
            contour = contour.SmoothContoursXld(7);
            contour.FitCircleContourXld("geohuber", -1, 0, 0, 5, 2, out parameter[1], out parameter[0], out parameter[2], out startPhi, out endPhi, out pointOrder);
            return parameter;
        }

        public static void GetContour(JMatrix3D matrix3D, double X, double Y, double Width, double Length, double minLuminace, double maxLuminace, double minHeight, double maxHeight, out double[] contourX, out double[] contourY, out double[] contourZ)
        {
            float pitch = matrix3D.Pitch;
            int row = matrix3D.Row;
            int col = matrix3D.Column;
            byte[] luminace = (byte[])matrix3D.LuminaceData.Clone();
            float[] z = (float[])matrix3D.HeightData.Clone();

            List<double> xList = new List<double>();
            List<double> yList = new List<double>();
            List<double> zList = new List<double>();

            int startCol = (int)(X / pitch) < 0 ? 0 : (int)(X / pitch);
            int startRow = (int)(Y / pitch) < 0 ? 0 : (int)(Y / pitch);
            int endCol = (int)((X + Width) / pitch) > col ? col : (int)((X + Width) / pitch);
            int endRow = (int)((Y + Length) / pitch) > row ? row : (int)((Y + Length) / pitch);
            for (int indexRow = startRow; indexRow < endRow; indexRow++)
            {
                for (int indexCol = startCol; indexCol < endCol; indexCol++)
                {
                    if (z[indexRow * col + indexCol] < minHeight || luminace[indexRow * col + indexCol] < minLuminace || z[indexRow * col + indexCol] > maxHeight || luminace[indexRow * col + indexCol] > maxLuminace)
                    {
                        z[indexRow * col + indexCol] = 0;
                        luminace[indexRow * col + indexCol] = 0;
                    }
                }
            }

            for (int indexRow = startRow + 3; indexRow < endRow - 3; indexRow++)
            {
                for (int indexCol = startCol + 3; indexCol < endCol - 3; indexCol++)
                {
                    if ((luminace[indexRow * col + indexCol - 1] == 0 && luminace[indexRow * col + indexCol - 2] == 0 && luminace[indexRow * col + indexCol - 3] == 0) ||
                        (luminace[indexRow * col + indexCol + 1] == 0 && luminace[indexRow * col + indexCol + 2] == 0 && luminace[indexRow * col + indexCol + 3] == 0) ||
                        (luminace[(indexRow - 1) * col + indexCol] == 0 && luminace[(indexRow - 2) * col + indexCol] == 0 && luminace[(indexRow - 3) * col + indexCol] == 0) ||
                        (luminace[(indexRow + 1) * col + indexCol] == 0 && luminace[(indexRow + 2) * col + indexCol] == 0 && luminace[(indexRow + 3) * col + indexCol] == 0))
                    {
                        if (z[indexRow * col + indexCol] != 0)
                        {
                            xList.Add((indexCol) * pitch);
                            yList.Add(indexRow * pitch);
                            zList.Add(z[indexRow * col + indexCol]);
                        }
                    }
                }
            }
            contourX = xList.ToArray();
            contourY = yList.ToArray();
            contourZ = zList.ToArray();
        }

        public static void GetContour(JMatrix3D matrix3D, double X, double Y, double Radius, double minLuminace, double maxLuminace, double minHeight, double maxHeight, out double[] contourX, out double[] contourY, out double[] contourZ)
        {
            float pitch = matrix3D.Pitch;
            int row = matrix3D.Row;
            int col = matrix3D.Column;
            float[] luminace = (float[])matrix3D.LuminaceData.Clone();
            float[] z = (float[])matrix3D.HeightData.Clone();

            List<double> xList = new List<double>();
            List<double> yList = new List<double>();
            List<double> zList = new List<double>();

            int startCol = (int)((X - Radius) / pitch) < 0 ? 0 : (int)((X - Radius) / pitch);
            int startRow = (int)((Y - Radius) / pitch) < 0 ? 0 : (int)((Y - Radius) / pitch);
            int endCol = (int)((X + Radius) / pitch) > col ? col : (int)((X + Radius) / pitch);
            int endRow = (int)((Y + Radius) / pitch) > row ? row : (int)((Y + Radius) / pitch);
            for (int indexRow = startRow; indexRow < endRow; indexRow++)
            {
                for (int indexCol = startCol; indexCol < endCol; indexCol++)
                {
                    if (z[indexRow * col + indexCol] < minHeight || luminace[indexRow * col + indexCol] < minLuminace ||
                        z[indexRow * col + indexCol] > maxHeight || luminace[indexRow * col + indexCol] > maxLuminace)
                    {
                        z[indexRow * col + indexCol] = 0;
                        luminace[indexRow * col + indexCol] = 0;
                    }
                }
            }

            for (int indexRow = startRow + 3; indexRow < endRow - 3; indexRow++)
            {
                for (int indexCol = startCol + 3; indexCol < endCol - 3; indexCol++)
                {
                    if (((luminace[indexRow * col + indexCol - 1] == 0 && luminace[indexRow * col + indexCol - 2] == 0 && luminace[indexRow * col + indexCol - 3] == 0) ||
                        (luminace[indexRow * col + indexCol + 1] == 0 && luminace[indexRow * col + indexCol + 2] == 0 && luminace[indexRow * col + indexCol + 3] == 0) ||
                        (luminace[(indexRow - 1) * col + indexCol] == 0 && luminace[(indexRow - 2) * col + indexCol] == 0 && luminace[(indexRow - 3) * col + indexCol] == 0) ||
                        (luminace[(indexRow + 1) * col + indexCol] == 0 && luminace[(indexRow + 2) * col + indexCol] == 0 && luminace[(indexRow + 3) * col + indexCol] == 0)) &&
                        Math.Sqrt(Math.Pow(indexCol * pitch - X, 2) + Math.Pow(indexRow * pitch - Y, 2)) < Radius)
                    {
                        if (z[indexRow * col + indexCol] != 0)
                        {
                            xList.Add((indexCol) * pitch);
                            yList.Add(indexRow * pitch);
                            zList.Add(z[indexRow * col + indexCol]);
                        }
                    }
                }
            }
            contourX = xList.ToArray();
            contourY = yList.ToArray();
            contourZ = zList.ToArray();
        }

        public static void GetLineContour(JMatrix3D matrix3D, int startCol, int startRow, int endCol, int endRow, double minLuminace, double maxLuminace,
                                            double minHeight, double maxHeight, int dir, bool isRising, out double[] contourX, out double[] contourY)
        {
            double pitch = matrix3D.Pitch;
            int col = matrix3D.Column;
            int row = matrix3D.Row;
            List<double> xList = new List<double>();
            List<double> yList = new List<double>();
            startCol = startCol < 0 ? 0 : startCol;
            startRow = startRow < 0 ? 0 : startRow;
            endCol = endCol < 0 ? 0 : endCol;
            endRow = endRow < 0 ? 0 : endRow;
            switch (dir)
            {
                case 0:
                    if (isRising)
                    {
                        for (int indexRow = startRow; indexRow < endRow; indexRow++)
                        {
                            for (int indexCol = startCol; indexCol < endCol; indexCol++)
                            {
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[indexRow * col + (indexCol - 2)]) || matrix3D.HeightData[indexRow * col + (indexCol - 2)] < minHeight || matrix3D.LuminaceData[indexRow * col + (indexCol - 2)] < minLuminace))
                                {
                                    xList.Add((indexCol - 1) * pitch);
                                    yList.Add(indexRow * pitch);
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
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[indexRow * col + (indexCol + 2)]) || matrix3D.HeightData[indexRow * col + (indexCol + 2)] < minHeight || matrix3D.LuminaceData[indexRow * col + (indexCol + 2)] < minLuminace))
                                {
                                    xList.Add((indexCol + 1) * pitch);
                                    yList.Add(indexRow * pitch);
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
                            for (int indexCol = endCol; indexCol > startCol; indexCol--)
                            {
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[indexRow * col + (indexCol + 2)]) || matrix3D.HeightData[indexRow * col + (indexCol + 2)] < minHeight || matrix3D.LuminaceData[indexRow * col + (indexCol + 2)] < minLuminace))
                                {
                                    xList.Add((indexCol + 1) * pitch);
                                    yList.Add(indexRow * pitch);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int indexRow = startRow; indexRow < endRow; indexRow++)
                        {
                            for (int indexCol = endCol; indexCol > startCol; indexCol--)
                            {
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[indexRow * col + (indexCol - 2)]) || matrix3D.HeightData[indexRow * col + (indexCol - 2)] < minHeight || matrix3D.LuminaceData[indexRow * col + (indexCol - 2)] < minLuminace))
                                {
                                    xList.Add((indexCol - 1) * pitch);
                                    yList.Add(indexRow * pitch);
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
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[(indexRow - 2) * col + indexCol]) || matrix3D.HeightData[(indexRow - 2) * col + indexCol] < minHeight || matrix3D.LuminaceData[(indexRow - 2) * col + indexCol] < minLuminace))
                                {
                                    xList.Add(indexCol * pitch);
                                    yList.Add((indexRow - 1) * pitch);
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
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[(indexRow + 2) * col + indexCol]) || matrix3D.HeightData[(indexRow + 2) * col + indexCol] < minHeight || matrix3D.LuminaceData[(indexRow + 2) * col + indexCol] < minLuminace))
                                {
                                    xList.Add(indexCol * pitch);
                                    yList.Add((indexRow + 1) * pitch);
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
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[indexRow * col + (indexCol + 2)]) || matrix3D.HeightData[(indexRow + 2) * col + indexCol] < minHeight || matrix3D.LuminaceData[(indexRow + 2) * col + indexCol] < minLuminace))
                                {
                                    xList.Add(indexCol * pitch);
                                    yList.Add((indexRow + 1) * pitch);
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
                                if (matrix3D.HeightData[indexRow * col + indexCol] > minHeight && matrix3D.HeightData[indexRow * col + indexCol] < maxHeight &&
                                    matrix3D.LuminaceData[indexRow * col + indexCol] > minLuminace && matrix3D.LuminaceData[indexRow * col + indexCol] <= maxLuminace &&
                                    (float.IsNaN(matrix3D.HeightData[indexRow * col + (indexCol - 2)]) || matrix3D.HeightData[(indexRow - 2) * col + indexCol] < minHeight || matrix3D.LuminaceData[(indexRow - 2) * col + indexCol] < minLuminace))
                                {
                                    xList.Add(indexCol * pitch);
                                    yList.Add((indexRow - 1) * pitch);
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
            contourX = xList.ToArray();
            contourY = yList.ToArray();
        }

        public static void GetRectROIPoints(JMatrix3D matrix3D, int startCol, int startRow, int endCol, int endRow, float minLuminace, float maxLuminace, out List<float> xList, out List<float> yList, out List<float> zList)
        {
            xList = new List<float>();
            yList = new List<float>();
            zList = new List<float>();
            float pitch = matrix3D.Pitch;
            int col = matrix3D.Column;
            int row = matrix3D.Row;
            startCol = startCol < 0 ? 0 : startCol;
            startRow = startRow < 0 ? 0 : startRow;
            endCol = endCol > col ? col : endCol;
            endRow = endRow > row ? row : endRow;
            for (int indexCol = startCol; indexCol < endCol; indexCol++)
            {
                for (int indexRow = startRow; indexRow < endRow; indexRow++)
                {
                    if (float.IsNaN(matrix3D.HeightData[indexRow * col + indexCol]) ||
                        matrix3D.LuminaceData[indexRow * col + indexCol] < minLuminace || matrix3D.LuminaceData[indexRow * col + indexCol] > maxLuminace)
                        continue;
                    xList.Add(indexCol * pitch);
                    yList.Add(indexRow * pitch);
                    zList.Add(matrix3D.HeightData[indexRow * col + indexCol]);
                }
            }
        }

        public static void GetROIPoints(JMatrix3D matrix3D, HRegion ROI, float minLuminace, float maxLuminace, out float[] xList, out float[] yList, out float[] zList)
        {
            HImage imageH = new HImage();
            HImage imageL = new HImage();
            unsafe
            {
                fixed (float* hp = &matrix3D.HeightData[0])
                    imageH.GenImage1("real", matrix3D.Column, matrix3D.Row, new IntPtr(hp));
                fixed (byte* lp = &matrix3D.LuminaceData[0])
                    imageL.GenImage1("byte", matrix3D.Column, matrix3D.Row, new IntPtr(lp));
            }

            imageH = imageH.ReduceDomain(ROI);
            imageH = imageH.CropDomain();
            IntPtr pL = imageH.GetImagePointer1(out string tl, out int wl, out int hl);
            zList = new float[wl * hl];
            Marshal.Copy(pL, zList, 0, wl * hl);

            HImage imageX = new HImage();
            imageX.GenImageSurfaceFirstOrder("real", 0, matrix3D.Pitch, 0, 0, 0, matrix3D.Column, matrix3D.Row);
            imageX = imageX.ReduceDomain(ROI);
            imageX = imageX.CropDomain();
            IntPtr pX = imageX.GetImagePointer1(out tl, out wl, out hl);
            xList = new float[wl * hl];
            Marshal.Copy(pX, xList, 0, wl * hl);

            HImage imageY = new HImage();
            imageY.GenImageSurfaceFirstOrder("real", matrix3D.Pitch, 0, 0, 0, 0, matrix3D.Column, matrix3D.Row);
            imageY = imageY.ReduceDomain(ROI);
            imageY = imageY.CropDomain();
            IntPtr pY = imageY.GetImagePointer1(out tl, out wl, out hl);
            yList = new float[wl * hl];
            Marshal.Copy(pY, yList, 0, wl * hl);

        }

        public static void GetCircleROIPoints(JMatrix3D matrix3D, int col, int row, int radius, float minLuminace, float maxLuminace, out List<float> xList, out List<float> yList, out List<float> zList)
        {
            xList = new List<float>();
            yList = new List<float>();
            zList = new List<float>();
            int startCol = col - radius < 0 ? 0 : col - radius;
            int startRow = row - radius < 0 ? 0 : row - radius;
            int endCol = col + radius > matrix3D.Column ? matrix3D.Column : col + radius;
            int endRow = row + radius > matrix3D.Row ? matrix3D.Row : row + radius;
            for (int indexCol = startCol; indexCol < endCol; indexCol++)
            {
                for (int indexRow = startRow; indexRow < endRow; indexRow++)
                {
                    if (matrix3D.HeightData[indexRow * matrix3D.Column + indexCol] == 0 || float.IsNaN(matrix3D.HeightData[indexRow * matrix3D.Column + indexCol]) ||
                        matrix3D.LuminaceData[indexRow * matrix3D.Column + indexCol] < minLuminace || matrix3D.LuminaceData[indexRow * matrix3D.Column + indexCol] > maxLuminace)
                        continue;
                    if (Math.Sqrt((indexCol - col) * (indexCol - col) + (indexRow - row) * (indexRow - row)) > radius)
                        continue;
                    xList.Add(indexCol * matrix3D.Pitch);
                    yList.Add(indexRow * matrix3D.Pitch);
                    zList.Add(matrix3D.HeightData[indexRow * matrix3D.Column + indexCol]);
                }
            }
        }

        public static JMatrix3D Threshold(JMatrix3D srcMatrix3D, byte minLuminace, byte maxLuminace, double minArea, double maxArea)
        {
            if (srcMatrix3D == null) return null;
            JMatrix3D matrix3D = srcMatrix3D.Clone();
            HImage imageL = new HImage();
            unsafe
            {
                fixed (byte* lp = &matrix3D.LuminaceData[0])
                    imageL.GenImage1("byte", matrix3D.Column, srcMatrix3D.Row, new IntPtr(lp));
            }
            HRegion totalRegion = imageL.Threshold((double)minLuminace, maxLuminace);
            HRegion regions = totalRegion.Connection();
            double minAreaPix = minArea / srcMatrix3D.Pitch / srcMatrix3D.Pitch;
            double maxAreaPix = maxArea / srcMatrix3D.Pitch / srcMatrix3D.Pitch;
            HRegion regionClue = regions.SelectShape("area", "and", minAreaPix, maxAreaPix);
            if (regionClue.CountObj() == 0) return matrix3D;
            regionClue = regionClue.DilationRectangle1(40, 40);
            regionClue = regionClue.ErosionRectangle1(60, 60);
            int[] rows = { 0, 0, matrix3D.Row - 1, matrix3D.Row - 1 };
            int[] cols = { 0, matrix3D.Column - 1, 0, matrix3D.Column - 1 };
            HRegion region = new HRegion();
            region.GenRegionPoints(new HTuple(rows), new HTuple(cols));
            region = region.Union2(regionClue);
            imageL = imageL.ReduceDomain(region);
            imageL = imageL.CropDomain();
            IntPtr pL = imageL.GetImagePointer1(out HTuple tl, out HTuple wl, out HTuple hl);
            Marshal.Copy(pL, matrix3D.LuminaceData, 0, matrix3D.Row * matrix3D.Column);
            return matrix3D;
        }

        public static int GetLineROIPoints(JMatrix3D matrix3D, int startCol, double startRow, double endCol, double endRow, byte minLuminace, byte maxLuminace, out List<float> xList, out List<float> yList, out List<float> zList, out List<byte> lList)
        {
            xList = new List<float>();
            yList = new List<float>();
            zList = new List<float>();
            lList = new List<byte>();
            startCol = startCol < 0 ? 0 : startCol;
            startRow = startRow < 0 ? 0 : startRow;
            endCol = endCol < 0 ? 0 : endCol;
            endRow = endRow < 0 ? 0 : endRow;
            bool isDirtX = false;

            if (Math.Abs(endCol - startCol) >= Math.Abs(endRow - startRow))
                isDirtX = true;
            else
                isDirtX = false;
            int begin_i = (int)((isDirtX) ? (startCol < endCol) ? startRow : endRow : (startRow < endRow) ? startRow : endRow);
            int begin_j = (int)((isDirtX) ? (startCol < endCol) ? startCol : endCol : (startRow < endRow) ? startCol : endCol);
            int end_i = (int)((isDirtX) ? (startCol < endCol) ? endRow : startRow : (startRow < endRow) ? endRow : startRow);
            int end_j = (int)((isDirtX) ? (startCol < endCol) ? endCol : startCol : (startRow < endRow) ? endCol : startCol);

            if (begin_i == end_i)
            {
                for (int j = begin_j; j <= end_j; j++)
                {
                    if (matrix3D.HeightData[begin_i * matrix3D.Column + j] == 0 || float.IsNaN(matrix3D.HeightData[begin_i * matrix3D.Column + j]) ||
                        matrix3D.LuminaceData[begin_i * matrix3D.Column + j] < minLuminace || matrix3D.LuminaceData[begin_i * matrix3D.Column + j] > maxLuminace)
                        continue;
                    xList.Add(j * matrix3D.Pitch);
                    yList.Add(begin_i * matrix3D.Pitch);
                    zList.Add(matrix3D.HeightData[begin_i * matrix3D.Column + j]);
                    lList.Add(matrix3D.LuminaceData[begin_i * matrix3D.Column + j]);
                }
                return 0;
            }

            double line_k = (end_j - begin_j) / (double)(end_i - begin_i);
            double line_b = begin_j - line_k * begin_i;
            if (isDirtX == false)
            {
                if (begin_i >= matrix3D.Row)
                {
                    return -1;
                }
                if (end_i >= matrix3D.Row)
                    end_i = matrix3D.Row - 1;
                for (int i = begin_i; i <= end_i; i++)
                {
                    int j = 0;
                    if (line_k >= 1)
                        j = (int)Math.Floor(line_k * i + line_b);
                    else
                        j = (int)Math.Ceiling(line_k * i + line_b);
                    if (matrix3D.HeightData[i * matrix3D.Column + j] == 0 || float.IsNaN(matrix3D.HeightData[i * matrix3D.Column + j]) ||
                        matrix3D.LuminaceData[i * matrix3D.Column + j] < minLuminace || matrix3D.LuminaceData[i * matrix3D.Column + j] > maxLuminace)
                        continue;
                    xList.Add(j * matrix3D.Pitch);
                    yList.Add(i * matrix3D.Pitch);
                    zList.Add(matrix3D.HeightData[i * matrix3D.Column + j]);
                    lList.Add(matrix3D.LuminaceData[i * matrix3D.Column + j]);
                }
            }
            else
            {
                if (begin_j >= matrix3D.Column)
                {
                    return -1;
                }
                if (end_j >= matrix3D.Column)
                    end_j = matrix3D.Column - 1;
                for (int j = begin_j; j <= end_j; j++)
                {
                    int i = 0;
                    if (line_k >= 1)
                        i = (int)Math.Ceiling((j - line_b) / line_k);
                    else
                        i = (int)Math.Floor(((j - line_b) / line_k));
                    if (matrix3D.HeightData[i * matrix3D.Column + j] == 0 || float.IsNaN(matrix3D.HeightData[i * matrix3D.Column + j]) ||
                        matrix3D.LuminaceData[i * matrix3D.Column + j] < minLuminace || matrix3D.LuminaceData[i * matrix3D.Column + j] > maxLuminace)
                        continue;
                    xList.Add(j * matrix3D.Pitch);
                    yList.Add(i * matrix3D.Pitch);
                    zList.Add(matrix3D.HeightData[i * matrix3D.Column + j]);
                    lList.Add(matrix3D.LuminaceData[i * matrix3D.Column + j]);
                }
            }
            return 0;
        }

        public static double GetPointToLineDist(double x, double y, double[] lineParam)
        {
            return (lineParam[0] * x + lineParam[1] * y + lineParam[2]) / Math.Sqrt(lineParam[0] * lineParam[0] + lineParam[1] * lineParam[1]);
        }

        public static double GetPlaneToPlaneAngle(double[] Plane1Param, double[] Plane2Param)
        {
            return 180 - Math.Acos(Plane1Param[0] * Plane2Param[0] + Plane1Param[1] * Plane2Param[1] + Plane1Param[2] * Plane2Param[2]) / (Math.Sqrt(Plane1Param[0] * Plane1Param[0] + Plane1Param[1] * Plane1Param[1] + Plane1Param[2] * Plane1Param[2]) * Math.Sqrt(Plane2Param[0] * Plane2Param[0] + Plane2Param[1] * Plane2Param[1] + Plane2Param[2] * Plane2Param[2])) * 180 / Math.PI;
        }

        public static float[] GetPlanesIntersection(double[] plane1, double[] plane2, double[] plane3)
        {
            HTuple paramA = new HTuple();
            paramA.Append(plane1[0]);
            paramA.Append(plane1[1]);
            paramA.Append(plane1[2]);
            paramA.Append(plane2[0]);
            paramA.Append(plane2[1]);
            paramA.Append(plane2[2]);
            paramA.Append(plane3[0]);
            paramA.Append(plane3[1]);
            paramA.Append(plane3[2]);
            HMatrix planeMatrixA = new HMatrix(3, 3, paramA);
            HTuple paramB = new HTuple();
            paramB.Append(-plane1[3]);
            paramB.Append(-plane2[3]);
            paramB.Append(-plane3[3]);
            HMatrix planeMatrixB = new HMatrix(3, 1, paramB);
            HMatrix intersectionMatrix = planeMatrixA.InvertMatrix("general", 0.0).MultMatrix(planeMatrixB, "AB");
            return intersectionMatrix.GetFullMatrix().ToFArr();
        }

        public static double GetPointToPlaneDist(double x, double y, double z, double[] planeParam)
        {
            if (planeParam == null || planeParam.Length < 4)
                return z;
            return (planeParam[0] * x + planeParam[1] * y + planeParam[2] * z + planeParam[3]) / Math.Sqrt(planeParam[0] * planeParam[0] + planeParam[1] * planeParam[1] + planeParam[2] * planeParam[2]);
        }
    }
}
