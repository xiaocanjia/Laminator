using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace JSystem.Device
{
    [XmlInclude(typeof(ScanningGun))]
    [XmlInclude(typeof(Camera2D))]
    [XmlInclude(typeof(Camera3D))]
    public class DeviceBase
    {
        public string Name;

        [XmlIgnore]
        public UserControl View;

        [XmlIgnore]
        public DevStatusPanel StatusPanel;

        [XmlIgnore]
        public Action<bool> OnUpdateStatus;

        [XmlIgnore]
        public Action<bool> OnSetEnable;

        public virtual void SetUserRight(string right) { OnSetEnable?.Invoke(right != "操作员"); }

        public virtual bool Connect() { return true; }

        public virtual void DisConnect() { }

        public virtual bool CheckConnection() { return true; }
    }
}
