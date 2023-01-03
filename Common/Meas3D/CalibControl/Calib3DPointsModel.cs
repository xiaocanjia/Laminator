using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using HalconDotNet;
using Vision3D;
using BSLib;
using System.Linq;

namespace Meas3D.Calib
{
    public class Calib3DPointsModel
    {
        private JMatrix3D _matrix3D;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public MinimizedView NormalView;

        [XmlIgnore]
        public HHomMat3D HomMat;

        public double[] RawData;

        private List<float> _xList = new List<float>();

        private List<float> _yList = new List<float>();

        private List<float> _zList = new List<float>();

        public List<Step3DModel> Steps;

        [XmlIgnore]
        public Action<Step3DModel> OnOpenStepPanel;

        [XmlIgnore]
        public Action<Step3DModel> OnCloseView;

        public Calib3DPointsModel()
        {
            Steps = new List<Step3DModel>();
            NormalView = new MinimizedView(this);
        }

        public void InitShape()
        {
            HomMat = new HHomMat3D(new HTuple(RawData));
            foreach (Step3DModel step in Steps)
            {
                step.OnCloseView = OnCloseView;
                step.OnAddShape = OnAddShape;
                step.OnRemoveShape = OnRemoveShape;
                step.OnRepaint = OnRepaint;
                step.InitShape();
            }
        }

        public void Clear()
        {
            _xList.Clear();
            _yList.Clear();
            _zList.Clear();
        }

        public void AddStep()
        {
            Step3DModel step = new Step3DModel();
            step.OnAddShape = OnAddShape;
            step.OnRemoveShape = OnRemoveShape;
            step.OnRepaint = OnRepaint;
            step.OnCloseView = OnCloseView;
            Steps.Add(step);
        }

        public void RemoveStep()
        {
            Step3DModel step = Steps.Last();
            step.RemoveROIs();
            Steps.Remove(step);
        }

        public void AddData(float x, float y, float z)
        {
            _xList.Add(x);
            _yList.Add(y);
            _zList.Add(z);
        }

        public HObjectModel3D AffineTrans(HObjectModel3D srcObject3D)
        {
            return srcObject3D.AffineTransObjectModel3d(HomMat);
        }

        public void GetData(out float[] xArr, out float[] yArr, out float[] zArr)
        {
            HTuple tupleX = HomMat.AffineTransPoint3d(new HTuple(_xList.ToArray()), new HTuple(_yList.ToArray()), new HTuple(_zList.ToArray()), out HTuple tupleY, out HTuple tupleZ);
            xArr = tupleX.ToFArr();
            yArr = tupleY.ToFArr();
            zArr = tupleZ.ToFArr();
        }

        public void OpenStepPanel(int idx)
        {
            OnOpenStepPanel?.Invoke(Steps[idx]);
            Steps[idx].OpenSetupPanel();
        }

        public void UpdateMatrix3D(JMatrix3D matrix3D)
        {
            _matrix3D = matrix3D;
        }

        public void EnableCalib()
        {
            if (_matrix3D == null)
                return;
            HTuple px = new HTuple();
            HTuple py = new HTuple();
            HTuple pz = new HTuple();
            HTuple qx = new HTuple();
            HTuple qy = new HTuple();
            HTuple qz = new HTuple();
            foreach (Step3DModel step in Steps)
            {
                float[][] measPoints = step.CalcPointsLoc(_matrix3D);
                float[][] refPoints = step.RefPoints;
                for (int i = 0; i < 8; i++)
                {
                    px.Append(measPoints[i][0]);
                    py.Append(measPoints[i][1]);
                    pz.Append(measPoints[i][2]);
                    qx.Append(refPoints[i][0]);
                    qy.Append(refPoints[i][1]);
                    qz.Append(refPoints[i][2]);
                }
            }
            HomMat = new HHomMat3D();
            HomMat.HomMat3dIdentity();
            HomMat.VectorToHomMat3d("affine", px, py, pz, qx, qy, qz);
            RawData = HomMat.RawData.ToDArr();
        }

        public void RemoveSteps()
        {
            foreach (Step3DModel step in Steps)
                step.RemoveROIs();
            OnRepaint?.Invoke();
        }
    }
}
