using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using BSLib;
using Vision3D;
using AlgoLib;
using System.Runtime.InteropServices;
using HalconDotNet;

namespace Meas3D.FixPos
{
    public class FixPos3DManager
    {
        [XmlIgnore]
        public Dictionary<EFixPos3DType, string> FixPosName;

        private JMatrix3D _scrMatrix;

        public double[] Loc;

        public FixPos3DBaseModel CurrFixPos;

        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<FixPos3DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public Action<FixPos3DBaseModel> OnCloseSetupPanel;

        [XmlIgnore]
        public Action<JMatrix3D> OnUpdateVision;

        [XmlIgnore]
        public Action<JMatrix3D, double[], double[]> OnUpdateTools;

        public FixPos3DManager()
        {
            FixPosName = new Dictionary<EFixPos3DType, string>();
            FixPosName.Add(EFixPos3DType.CIRCLELINE, "圆线定位");
            FixPosName.Add(EFixPos3DType.CIRCLES, "圆圆定位");
            FixPosName.Add(EFixPos3DType.LINES, "线线定位");
            FixPosName.Add(EFixPos3DType.MODELMATCH, "模板匹配");
        }

        public void UpdateMatrix3D(JMatrix3D srcMatrix3D)
        {
            try
            {
                _scrMatrix = srcMatrix3D;
                CurrFixPos?.UpdateMatrix3D(srcMatrix3D);
                CurrFixPos?.UpdatePos();
                JMatrix3D matrix3D = srcMatrix3D;
                if (Loc != null)
                    matrix3D = srcMatrix3D.AffineTrans(Loc[0] - CurrFixPos.X, Loc[1] - CurrFixPos.Y, CurrFixPos.Angle - Loc[2], CurrFixPos.X, CurrFixPos.Y);
                OnUpdateVision?.Invoke(matrix3D);
                CurrFixPos?.UpdateMatrix3D(srcMatrix3D);
                CurrFixPos?.UpdatePos();
                CurrFixPos?.UpdateShape();
                OnUpdateTools?.Invoke(matrix3D, CurrFixPos?.XAxis, CurrFixPos?.YAxis);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddFixPos(EFixPos3DType type)
        {
            try
            {
                if (_scrMatrix == null) return;
                FixPos3DBaseModel fixPos = FixPos3DFactory.CreateFixPos(type);
                InitFixPos(fixPos);
                fixPos.UpdateMatrix3D(_scrMatrix);
                fixPos.UpdatePos();
                fixPos.UpdateShape();
                fixPos.OpenSetupView();
                CurrFixPos = fixPos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InitFixPos(FixPos3DBaseModel fixPos)
        {
            if (fixPos == null) return;
            fixPos.OnOpenSetupPanel = OnOpenSetupPanel;
            fixPos.OnAddShape = OnAddShape;
            fixPos.OnRemoveShape = OnRemoveShape;
            fixPos.OnRepaint = OnRepaint;
            fixPos.InitShape();
        }

        public bool EnableFixPos()
        {
            if (CurrFixPos == null)
                return false;
            try
            {
                Loc = new double[3];
                CurrFixPos.EnableFixPos();
                Loc[0] = CurrFixPos.X;
                Loc[1] = CurrFixPos.Y;
                Loc[2] = CurrFixPos.Angle;
                OnUpdateTools?.Invoke(_scrMatrix, CurrFixPos?.XAxis, CurrFixPos?.YAxis);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisableFixPos()
        {
            if (CurrFixPos == null)
                return;
            Loc = null;
            CurrFixPos.DisableFixPos();
            UpdateMatrix3D(_scrMatrix);
        }

        public void DeleteFixPos()
        {
            if (CurrFixPos == null)
                return;
            CurrFixPos.DeleteFixPos();
            if (Loc != null) DisableFixPos();
            OnCloseSetupPanel?.Invoke(CurrFixPos);
            CurrFixPos = null;
        }
    }
}
