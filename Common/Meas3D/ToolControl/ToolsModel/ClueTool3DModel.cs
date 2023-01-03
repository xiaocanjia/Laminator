using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Vision3D;
using MeasResult;

namespace Meas3D.Tool
{
    public class ClueTool3DModel : Tool3DBaseModel
    {
        private Shape3DLine[] _ROIs;

        private Shape3DLine[] Profiles;

        private List<ShapeCross> _shapeCross = new List<ShapeCross>();

        public List<Shape3DPoint> ShapePoints = new List<Shape3DPoint>();

        public int Density = 10;

        private bool _isFinished = false;

        public double Interval = 1.0;

        public double LineWidth = 3;

        public double MaxHeight = 5;

        public double MinHeight = 0.1;

        public byte MaxLuminace = 255;

        public byte MinLuminace = 0;

        private List<Shape3DPoint> _pointsDeleted = new List<Shape3DPoint>();

        public ClueTool3DModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool3DType.CLUE;
            IsCombined = true;
        }

        public override void InitShape()
        {
            //if (ShapePoints != null)
            //{
            //    foreach (Shape3DPoint point in ShapePoints)
            //        OnAddShape?.Invoke(point);
            //}
            //ClearShapes(_ROIs?.Cast<Shape3DBase>().ToList());
            //ClearShapes(Profiles?.Cast<Shape3DBase>().ToList());
            //if (ShapePoints == null || ShapePoints.Count <= 1)
            //    return;
            //double totalLength = 0;
            //_ROIs = new Shape3DLine[ShapePoints.Count - 1];
            //for (int i = 0; i < ShapePoints.Count - 1; i++)
            //{
            //    _ROIs[i] = new Shape3DLine();
            //    _ROIs[i].Color = "blue";
            //    _ROIs[i].IsEditable = false;
            //    _ROIs[i].SetShape(ShapePoints[i].Col * _Matrix3D.Pitch, ShapePoints[i].Row * _Matrix3D.Pitch, ShapePoints[i + 1].Col * _Matrix3D.Pitch, ShapePoints[i + 1].Row * _Matrix3D.Pitch);
            //    OnAddShape?.Invoke(_ROIs[i]);
            //    totalLength += _ROIs[i].Length;
            //}
            //Interval = totalLength / (Density - 1);
            //Profiles = new Shape3DLine[Density];
            //int ROIIdx = 0;
            //double currLength = _ROIs[0].Length;
            //for (int i = 0; i < Density; i++)
            //{
            //    while (i * Interval - currLength > 1e-9)
            //    {
            //        ROIIdx++;
            //        currLength += _ROIs[ROIIdx].Length;
            //    }
            //    if (ROIIdx >= _ROIs.Length)
            //        break;
            //    Shape3DLine ROI = _ROIs[ROIIdx];
            //    double angle = 1.57;
            //    if (ROI.X2 != ROI.X1)
            //        angle = Math.Atan((ROI.Y2 - ROI.Y1) / (ROI.X2 - ROI.X1));
            //    double diffX = LineWidth / 2 * Math.Sin(angle);
            //    double diffY = LineWidth / 2 * Math.Cos(angle);
            //    PointF point = new PointF();
            //    if (ROI.X1 < ROI.X2)
            //    {
            //        point.X = (float)(ROI.X1 + (i * Interval - (currLength - ROI.Length)) * Math.Cos(angle));
            //        point.Y = (float)(ROI.Y1 + (i * Interval - (currLength - ROI.Length)) * Math.Sin(angle));
            //    }
            //    else
            //    {
            //        point.X = (float)(ROI.X1 - (i * Interval - (currLength - ROI.Length)) * Math.Cos(angle));
            //        point.Y = (float)(ROI.Y1 - (i * Interval - (currLength - ROI.Length)) * Math.Sin(angle));
            //        if (ROI.X1 == ROI.X2 && ROI.Y1 < ROI.Y2)
            //            point.Y = (float)(ROI.Y1 + (i * Interval - (currLength - ROI.Length)) * Math.Sin(angle));
            //    }
            //    Profiles[i] = new Shape3DLine(point.X + diffX, point.Y - diffY, point.X - diffX, point.Y + diffY);
            //    Profiles[i].IsEditable = false;
            //    Profiles[i].Color = "coral";
            //    OnAddShape?.Invoke(Profiles[i]);
            //}
            //ResetResults();
        }

        public void ResetResults()
        {
            Results = null;
            if (ShapePoints == null || ShapePoints.Count == 0)
                return;
            Results = new MesResult[Density * 2];
            for (int i = 0; i < Density; i++)
            {
                Results[i * 2] = new MesResult(Name, $"胶高{i + 1}", "mm");
                Results[i * 2 + 1] = new MesResult(Name, $"胶宽{i + 1}", "mm");
            }
        }

        public override void UpdateResult()
        {
            try
            {
                //if (_Matrix3D == null || ShapePoints == null || ShapePoints.Count == 0)
                //{
                //    Results = null;
                //    OnUpdateValue?.Invoke();
                //    return;
                //}
                //ClearShapes(_shapeCross?.Cast<Shape3DBase>().ToList());
                //_shapeCross?.Clear();
                //JMatrix3D Matrix3D = Algo3D.Threshold(_Matrix3D, MinLuminace, MaxLuminace, 600, 2000);
                //DateTime start = DateTime.Now;
                //for (int i = 0; i < Density; i++)
                //{
                //    Algo3D.GetLineROIPoints(Matrix3D, Profiles[i].X1, Profiles[i].Y1, Profiles[i].X2, Profiles[i].Y2,
                //            0, 255, out List<float> xList, out List<float> yList, out List<float> zList, out List<byte> lList);
                //    if (zList.Count == 0)
                //    {
                //        Results[i * 2].SetResult(double.NaN, 0);
                //        Results[i * 2 + 1].SetResult(double.NaN, 0);
                //        continue;
                //    }
                //    ShapeCross startCross = new ShapeCross();
                //    ShapeCross endCross = new ShapeCross();
                //    List<double> planeHeight = new List<double>();
                //    for (int j = 0; j < lList.Count; j++)
                //    {
                //        if (lList[j] != 0/*lList[j] > MinLuminace && lList[j] < MaxLuminace && lList[j - 3] > MaxLuminace*/)
                //        {
                //            startCross.X = xList[j];
                //            startCross.Y = yList[j];
                //            OnAddShape?.Invoke(startCross);
                //            _shapeCross.Add(startCross);
                //            break;
                //        }
                //        planeHeight.Add(zList[j]);
                //    }
                //    for (int j = lList.Count - 1; j > 0; j--)
                //    {
                //        if (lList[j] != 0/*lList[j] > MinLuminace && lList[j] < MaxLuminace && lList[j + 3] > MaxLuminace*/)
                //        {
                //            endCross.X = xList[j];
                //            endCross.Y = yList[j];
                //            OnAddShape?.Invoke(endCross);
                //            _shapeCross.Add(endCross);
                //            break;
                //        }
                //        planeHeight.Add(zList[j]);
                //    }
                //    DateTime end = DateTime.Now;
                //    Results[i * 2].Value = zList.Max() - planeHeight.Average();
                //    Results[i * 2].SpanTime = (end - start).TotalMilliseconds;
                //    Results[i * 2 + 1].Value = Math.Sqrt(Math.Pow((endCross.X - startCross.X), 2) + Math.Pow((endCross.Y - startCross.Y), 2));
                //    Results[i * 2 + 1].SpanTime = (end - start).TotalMilliseconds;
                //}
                //OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception("胶水检测算子发生异常" + ex.Message);
            }
        }

        public void AddPoints()
        {
            OnAddShapeByMouse?.Invoke(EShape3DType.POINT);
            _pointsDeleted = new List<Shape3DPoint>();
            Thread t = new Thread(GetShape);
            t.IsBackground = true;
            t.Start();
            _isFinished = false;
        }

        public void DeletePoint()
        {
            if (ShapePoints.Count == 0)
                return;
            _pointsDeleted.Add(ShapePoints.Last());
            OnRemoveShape?.Invoke(ShapePoints.Last());
            ShapePoints.Remove(ShapePoints.Last());
            OnRepaint?.Invoke();
        }

        public void AddFinished()
        {
            OnAddFinished?.Invoke();
            _isFinished = true;
            //OnResetResults?.Invoke();
            InitShape();
            UpdateResult();
            UpdateShape();
        }

        public void DeleteAllPoints()
        {
            if (ShapePoints.Count == 0)
                return;
            _pointsDeleted.Add(ShapePoints.Last());
            if (_ROIs != null)
            {
                foreach (Shape3DLine ROI in _ROIs)
                    OnRemoveShape?.Invoke(ROI);
            }
            if (ShapePoints != null)
            {
                foreach (Shape3DPoint point in ShapePoints)
                    OnRemoveShape?.Invoke(point);
            }
            ShapePoints = new List<Shape3DPoint>();
            if (Profiles != null)
            {
                foreach (Shape3DLine line in Profiles)
                    OnRemoveShape?.Invoke(line);
            }
            if (_shapeCross != null)
            {
                foreach (ShapeCross point in _shapeCross)
                    OnRemoveShape?.Invoke(point);
                _shapeCross.Clear();
            }
            InitShape();
            UpdateResult();
            UpdateShape();
        }

        public void GetShape()
        {
            while (true)
            {
                Shape3DPoint point = OnGetShape() as Shape3DPoint;
                if (point != null && !_pointsDeleted.Contains(point) && !ShapePoints.Contains(point))
                    ShapePoints.Add(point);
                if (_isFinished)
                    break;
            }
        }

        public override void UpdateShape()
        {
            OnRepaint?.Invoke();
        }

        public override void OpenSetupView()
        {
            SetupView = new ClueTool3DView(this);
            OnRepaint?.Invoke();
            base.OpenSetupView();
        }

        public override void CloseSetupView()
        {
            OnRepaint?.Invoke();
            base.CloseSetupView();
        }

        public override void DeleteTool()
        {
            ClearShapes(_ROIs?.Cast<Shape3DBase>().ToList());
            ClearShapes(Profiles?.Cast<Shape3DBase>().ToList());
            ClearShapes(_shapeCross?.Cast<Shape3DBase>().ToList());
            ClearShapes(ShapePoints?.Cast<Shape3DBase>().ToList());
            OnRepaint?.Invoke();
            base.DeleteTool();
        }
    }
}
