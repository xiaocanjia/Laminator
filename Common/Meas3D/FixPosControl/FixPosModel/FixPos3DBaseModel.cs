using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using BSLib;
using Vision3D;

namespace Meas3D.FixPos
{
    [XmlInclude(typeof(CirclesFixPos3DModel))]
    [XmlInclude(typeof(LinesFixPos3DModel))]
    [XmlInclude(typeof(CircleLineFixPos3DModel))]
    [XmlInclude(typeof(ModelMatchFixPos3DModel))]
    public class FixPos3DBaseModel
    {
        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;
        
        [XmlIgnore]
        public Action<FixPos3DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public UserControl SetupView;

        [XmlIgnore]
        public Action<string> OnAddLog;

        protected JMatrix3D _matrix3D;

        public double[] XAxis = new double[3] { 0, 1, 0 };

        public double[] YAxis = new double[3] { 1, 0, 0 };

        public double X;

        public double Y;

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

        public void UpdateMatrix3D(JMatrix3D Matrix3D)
        {
            _matrix3D = Matrix3D;
        }
    }
}
