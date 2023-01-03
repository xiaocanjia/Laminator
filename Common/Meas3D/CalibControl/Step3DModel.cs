using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Vision3D;
using BSLib;
using AlgoLib;

namespace Meas3D.Calib
{
    /// <summary>
    /// 每个台阶的数据
    /// </summary>
    public class Step3DModel
    {
        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        public float[][] RefPoints;

        public List<List<Shape3DRect>> ROIList;

        [XmlIgnore]
        public Step3DView StepView { get; set; }

        [XmlIgnore]
        public Action<Step3DModel> OnCloseView;

        public Step3DModel()
        {
            RefPoints = new float[8][];
            for (int i = 0; i < 8; i++)
                RefPoints[i] = new float[3];
            ROIList = new List<List<Shape3DRect>>();
        }

        public void InitShape()
        {
            foreach (List<Shape3DRect> ROIs in ROIList)
            {
                foreach (Shape3DRect ROI in ROIs)
                    OnAddShape?.Invoke(ROI);
            }
            OnRepaint?.Invoke();
        }

        public void AddROI(int idx)
        {
            Shape3DRect ROI = new Shape3DRect();
            ROIList[idx].Add(ROI);
            OnAddShape?.Invoke(ROI);
            OnRepaint?.Invoke();
        }

        public void RemoveROI(int idx)
        {
            if (ROIList[idx].Count == 0)
                return;
            OnRemoveShape?.Invoke(ROIList[idx][ROIList[idx].Count - 1]);
            ROIList[idx].RemoveAt(ROIList[idx].Count - 1);
            OnRepaint?.Invoke();
        }

        public void RemoveROIs()
        {
            foreach (List<Shape3DRect> ROIs in ROIList)
            {
                foreach (Shape3DRect ROI in ROIs)
                {
                    OnRemoveShape?.Invoke(ROI);
                }
            }
        }

        public void SetupROI(int idx, bool isEditable)
        {
            if (ROIList.Count == 0)
            {
                for (int i = 0; i < 6; i++)
                    ROIList.Add(new List<Shape3DRect>());
            }
            for (int i = 0; i < ROIList[idx].Count; i++)
                ROIList[idx][i].IsEditable = isEditable;
            OnRepaint?.Invoke();
        }

        public void OpenSetupPanel()
        {
            foreach (List<Shape3DRect> ROIs in ROIList)
            {
                foreach (Shape3DRect ROI in ROIs)
                    ROI.IsVisible = true;
            }
            OnRepaint?.Invoke();
        }

        public void CloseSetupPanel()
        {
            OnCloseView?.Invoke(this);
            foreach (List<Shape3DRect> ROIs in ROIList)
            {
                foreach (Shape3DRect ROI in ROIs)
                {
                    ROI.IsVisible = false;
                    ROI.IsEditable = false;
                }
            }
            OnRepaint?.Invoke();
        }

        public float[][] CalcPointsLoc(JMatrix3D matrix3D)
        {
            double[][] Parameter = new double[6][];
            for (int i = 0; i < 6; i++)
            {
                List<float> xList = new List<float>();
                List<float> yList = new List<float>();
                List<float> zList = new List<float>();
                foreach (Shape3DRect ROI in ROIList[i])
                {
                    Algo3D.GetRectROIPoints(matrix3D, (int)ROI.Col1, (int)ROI.Row1, (int)ROI.Col2, (int)ROI.Row2, 0, 256, out List<float> _xList, out List<float> _yList, out List<float> _zList);
                    xList.AddRange(_xList);
                    yList.AddRange(_yList);
                    zList.AddRange(_zList);
                }
                Algo3D.GetFitPlane(xList.ToArray(), yList.ToArray(), zList.ToArray(), out Parameter[i]);
            }
            float[][] measPoints = new float[8][];
            for (int i = 0; i < 8; i++)
                measPoints[i] = new float[3];
            measPoints[0] = Algo3D.GetPlanesIntersection(Parameter[0], Parameter[2], Parameter[5]);
            measPoints[1] = Algo3D.GetPlanesIntersection(Parameter[0], Parameter[3], Parameter[5]);
            measPoints[2] = Algo3D.GetPlanesIntersection(Parameter[1], Parameter[3], Parameter[5]);
            measPoints[3] = Algo3D.GetPlanesIntersection(Parameter[1], Parameter[2], Parameter[5]);
            measPoints[4] = Algo3D.GetPlanesIntersection(Parameter[0], Parameter[2], Parameter[4]);
            measPoints[5] = Algo3D.GetPlanesIntersection(Parameter[0], Parameter[3], Parameter[4]);
            measPoints[6] = Algo3D.GetPlanesIntersection(Parameter[1], Parameter[3], Parameter[4]);
            measPoints[7] = Algo3D.GetPlanesIntersection(Parameter[1], Parameter[2], Parameter[4]);
            return measPoints;
        }
    }
}
