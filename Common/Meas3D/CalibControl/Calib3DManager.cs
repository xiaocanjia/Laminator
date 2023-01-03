using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using Vision3D;
using BSLib;
using HalconDotNet;

namespace Meas3D.Calib
{
    public class Calib3DManager
    {
        private JMatrix3D _matrix3D;

        public List<Calib3DPointsModel> ModelList;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnUpdateTools;

        [XmlIgnore]
        public Action<Step3DModel> OnOpenStepPanel;

        [XmlIgnore]
        public Action<Step3DModel> OnClseStepPanel;

        private double _validWidth;

        public bool IsCalib = false;

        public Calib3DManager()
        {
            ModelList = new List<Calib3DPointsModel>();
        }

        public void UpdateMatrix3D(JMatrix3D matrix3D)
        {
            _matrix3D = matrix3D;
            foreach (var model in ModelList)
                model.UpdateMatrix3D(_matrix3D);
        }

        public void SetValidWidth(double width)
        {
            _validWidth = width;
        }

        public void AddCliab(Calib3DPointsModel model)
        {
            ModelList.Add(model);
            model.UpdateMatrix3D(_matrix3D);
            InitCalib(model);
        }

        public void InitCalib(Calib3DPointsModel model)
        {
            model.OnAddShape = OnAddShape;
            model.OnRemoveShape = OnRemoveShape;
            model.OnRepaint = OnRepaint;
            model.OnOpenStepPanel = OnOpenStepPanel;
            model.OnCloseView = OnClseStepPanel;
            model.InitShape();
        }

        public void RemoveCliab()
        {
            Calib3DPointsModel model = ModelList.Last();
            model.RemoveSteps();
            ModelList.Remove(model);
            OnRepaint?.Invoke();
        }

        public void EnalbleCalib()
        {
            foreach (Calib3DPointsModel model in ModelList)
                model.EnableCalib();
            IsCalib = true;
            OnUpdateTools?.Invoke();
        }

        public void DisableCalib()
        {
            IsCalib = false;
            OnUpdateTools?.Invoke();
        }

        private void OpenStepPanel(Step3DModel step)
        {
            OnOpenStepPanel(step);
        }

        public void AffineTrans(float[] xArrSrc, float[] yArrSrc, float[] zArrSrc, out float[] xArrDst, out float[] yArrDst, out float[] zArrDst)
        {
            if (!IsCalib)
            {
                xArrDst = xArrSrc;
                yArrDst = yArrSrc;
                zArrDst = zArrSrc;
                return;
            }
            for (int j = 0; j < ModelList.Count; j++)
            {
                ModelList[j].Clear();
            }
            for (int i = 0; i < xArrSrc.Length; i++)
            {
                for (int j = 0; j < ModelList.Count; j++)
                {
                    if (xArrSrc[i] < (j + 1) * _validWidth)
                    {
                        ModelList[j].AddData(xArrSrc[i], yArrSrc[i], zArrSrc[i]);
                        break;
                    }
                }
            }
            List<float> xList = new List<float>();
            List<float> yList = new List<float>();
            List<float> zList = new List<float>();
            for (int j = 0; j < ModelList.Count; j++)
            {
                ModelList[j].GetData(out float[] xArr, out float[] yArr, out float[] zArr);
                xList.AddRange(xArr);
                yList.AddRange(yArr);
                zList.AddRange(zArr);
            }
            xArrDst = xList.ToArray();
            yArrDst = yList.ToArray();
            zArrDst = zList.ToArray();
        }

        public HObjectModel3D AffineTrans(HObjectModel3D srcObject3D)
        {
            if (!IsCalib) return srcObject3D;
            HObjectModel3D[] Object3DAffined = new HObjectModel3D[ModelList.Count];
            for (int i = 0; i < ModelList.Count; i++)
            {
                HObjectModel3D object3D = srcObject3D.SelectPointsObjectModel3d("point_coord_x", i * _validWidth, (i + 1) * _validWidth);
                Object3DAffined[i] = ModelList[i].AffineTrans(object3D);
            }
            return HObjectModel3D.UnionObjectModel3d(Object3DAffined, "'points_surface");
        }
    }
}
