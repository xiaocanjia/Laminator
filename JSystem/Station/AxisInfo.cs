using System;
using BoardSys;
using System.Xml.Serialization;

namespace JSystem.Station
{
    public class AxisInfo
    {
        public string Name;

        public string BoardID;

        public int AxisIndex;

        public bool IsBelt;

        [XmlIgnore]
        public bool IsAlarm;

        [XmlIgnore]
        public bool IsMoving;

        [XmlIgnore]
        public bool IsPositive;

        [XmlIgnore]
        public AxisPanel View;

        [XmlIgnore]
        public Action<double, double, byte, bool> OnUpdateView;

        [XmlIgnore]
        public Action OnAlarm;

        [XmlIgnore]
        public Action OnDisplayAlarm;

        public AxisInfo()
        {
            View = new AxisPanel(this);
        }

        public void UpdateState()
        {
            double cmdPos = BoardSysIF.Instance.GetCmdPos(BoardID, AxisIndex);
            double actPos = BoardSysIF.Instance.GetActPos(BoardID, AxisIndex);
            byte state = BoardSysIF.Instance.GetAxisState(BoardID, AxisIndex);
            IsAlarm = (state & (0x01 << 0)) > 0 ? true : false;
            bool isEnable = BoardSysIF.Instance.GetAxisServoEnabled(BoardID, AxisIndex);
            OnUpdateView?.Invoke(cmdPos, actPos, state, isEnable);
        }
    }
}
