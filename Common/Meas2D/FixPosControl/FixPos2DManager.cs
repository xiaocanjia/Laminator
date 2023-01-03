using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Vision2D;
using HalconDotNet;

namespace Meas2D.FixPos
{
    public class FixPos2DManager
    {
        [XmlIgnore]
        public Dictionary<EFixPos2DType, string> FixPosName;

        private HImage _scrImage;

        public double[] Loc;

        public FixPos2DBaseModel CurrFixPos;

        [XmlIgnore]
        public Action<Shape2DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape2DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<FixPos2DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public Action<FixPos2DBaseModel> OnCloseSetupPanel;

        [XmlIgnore]
        public Action<HImage> OnUpdateVision;

        [XmlIgnore]
        public Action<HImage, double[], double[]> OnUpdateTools;

        public FixPos2DManager()
        {
            FixPosName = new Dictionary<EFixPos2DType, string>();
            FixPosName.Add(EFixPos2DType.CIRCLELINE, "圆线定位");
            FixPosName.Add(EFixPos2DType.CIRCLES, "圆圆定位");
            FixPosName.Add(EFixPos2DType.LINES, "线线定位");
            FixPosName.Add(EFixPos2DType.MODELMATCH, "模板匹配");
        }

        public void UpdateImage(HImage srcImage)
        {
            try
            {
                _scrImage = srcImage;
                CurrFixPos?.UpdateImage(srcImage);
                CurrFixPos?.UpdatePos();
                HImage image = srcImage;
                if (Loc != null)
                {
                    HHomMat2D hom = new HHomMat2D();
                    hom = hom.HomMat2dRotate((CurrFixPos.Angle - Loc[2]) / 180.0 * Math.PI, CurrFixPos.Row, CurrFixPos.Column);
                    hom = hom.HomMat2dTranslate(Loc[0] - CurrFixPos.Row, Loc[1] - CurrFixPos.Column);
                    image = image.AffineTransImage(hom, "constant", "false");
                }
                OnUpdateVision?.Invoke(image);
                CurrFixPos?.UpdateImage(image);
                CurrFixPos?.UpdatePos();
                CurrFixPos?.UpdateShape();
                OnUpdateTools?.Invoke(image, CurrFixPos?.XAxis, CurrFixPos?.YAxis);
                OnRepaint?.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddFixPos(EFixPos2DType type)
        {
            try
            {
                if (_scrImage == null) return;
                FixPos2DBaseModel fixPos = FixPos2DFactory.CreateFixPos(type);
                InitFixPos(fixPos);
                fixPos.UpdateImage(_scrImage);
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

        public void InitFixPos(FixPos2DBaseModel fixPos)
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
                Loc[0] = CurrFixPos.Row;
                Loc[1] = CurrFixPos.Column;
                Loc[2] = CurrFixPos.Angle;
                OnUpdateTools?.Invoke(_scrImage, CurrFixPos?.XAxis, CurrFixPos?.YAxis);
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
            UpdateImage(_scrImage);
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
