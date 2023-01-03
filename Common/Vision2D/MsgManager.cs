using System.Collections.Generic;
using HalconDotNet;

namespace Vision2D
{
    public class MsgManager
    {
        private List<JMessage> _msgList;

        private HWindow _hWindow;

        public MsgManager()
        {
            _msgList = new List<JMessage>();
        }

        public void AddMessage(JMessage msg)
        {
            _msgList.Add(msg);
        }

        public void SetWindow(HWindow window)
        {
            _hWindow = window;
        }

        public void DispMsg()
        {
            foreach (JMessage msg in _msgList)
            {
                msg.Show(_hWindow);
            }
        }

        public void ResetSize()
        {
            foreach (JMessage msg in _msgList)
            {
                msg.ResetSize();
            }
        }

        public void ZoomSize(double zoom)
        {
            foreach (JMessage msg in _msgList)
            {
                msg.Size *= zoom;
            }
        }

        public void Clear()
        {
            _msgList.Clear();
        }
    }
}
