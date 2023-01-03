using System;
using System.Xml.Serialization;
using HalconDotNet;
using Vision2D;
using Meas2D.FixPos;

namespace Meas2D
{
    public class Meas2DManager
    {
        private HImage _currImg;

        public Tools2DManager ToolMgr;

        public FixPos2DManager FixPosMgr;

        [XmlIgnore]
        public Win2DManager Win2DMgr = new Win2DManager();

        public string Name;

        [XmlIgnore]
        public Action<HImage> OnUpdateImg;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Meas2DPage Page;

        [XmlIgnore]
        public Action OnStartGrab;

        public Meas2DManager()
        {
            ToolMgr = new Tools2DManager();
            FixPosMgr = new FixPos2DManager();
            Page = new Meas2DPage(this);
        }

        public void RegisterEvents()
        {
            ToolMgr.OnRepaint = Win2DMgr.Repaint;
            ToolMgr.OnAddShape = Win2DMgr.AddShape;
            ToolMgr.OnRemoveShape = Win2DMgr.RemoveShape;
            FixPosMgr.OnRepaint = Win2DMgr.Repaint;
            FixPosMgr.OnAddShape = Win2DMgr.AddShape;
            FixPosMgr.OnRemoveShape = Win2DMgr.RemoveShape;
            FixPosMgr.OnUpdateVision = Win2DMgr.UpdateImg;
        }

        public void UpdateImage(HImage image)
        {
            _currImg = image;
            FixPosMgr.UpdateImage(_currImg);
        }

        public void LoadImage(string filePath)
        {
            UpdateImage(new HImage(filePath));
        }

        public void SaveImage(string filePath)
        {
            _currImg?.WriteImage("jpg", 0, filePath);
        }
    }
}
