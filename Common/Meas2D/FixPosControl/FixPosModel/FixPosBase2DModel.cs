using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using BSLib;
using HalconDotNet;
using Vision2D;

namespace Meas2D.FixPos
{
    [XmlInclude(typeof(CirclesFixPos2DModel))]
    [XmlInclude(typeof(LinesFixPos2DModel))]
    [XmlInclude(typeof(CircleLineFixPos2DModel))]
    [XmlInclude(typeof(ModelMatchFixPos2DModel))]
    public class FixPos2DBaseModel
    {
        [XmlIgnore]
        public Action<Shape2DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape2DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<FixPos2DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public UserControl SetupView;

        [XmlIgnore]
        public Action<string> OnAddLog;

        protected HImage _image;

        public double[] XAxis = new double[3] { 0, 1, 0 };

        public double[] YAxis = new double[3] { 1, 0, 0 };

        public double Row;

        public double Column;

        public double Angle;

        public double[] Loc;

        public bool IsEnable = false;

        public virtual void InitShape() { }

        public virtual void DeleteFixPos() { }

        public virtual void UpdatePos() { }

        public virtual void UpdateShape() { }

        public virtual void OpenSetupView()
        {
            SetupView.Dock = DockStyle.Fill;
            OnOpenSetupPanel?.Invoke(this);
        }

        public virtual void EnableFixPos()
        {
            IsEnable = true;
        }

        public virtual void DisableFixPos()
        {
            IsEnable = false;
        }

        public void UpdateImage(HImage image)
        {
            _image = image;
        }
    }
}
