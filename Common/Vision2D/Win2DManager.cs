using System;
using HalconDotNet;

namespace Vision2D
{
    public class Win2DManager
    {
        private HImage _image;

        public ShapeManager ShapeMgr;

        public MsgManager MsgMgr;

        public Action OnReapint;

        public Action OnResetWinPart;

        public Win2DManager()
        {
            ShapeMgr = new ShapeManager();
            MsgMgr = new MsgManager();
        }

        public void UpdateImg(HImage image)
        {
            if (image == null)
                return;
            _image?.Dispose();
            _image = image.Clone();
            ShapeMgr.UpdateImage(image);
            OnResetWinPart?.Invoke();
        }

        public void GetImageSize(out int width, out int height)
        {
            width = 0;
            height = 0;
            if (_image == null)
                return;
            _image.GetImageSize(out width, out height);
        }

        public HImage GetCurrImage()
        {
            return _image;
        }

        public void Repaint()
        {
            OnReapint?.Invoke();
        }

        public void AddMessage(JMessage msg)
        {
            MsgMgr.AddMessage(msg);
        }

        public void AddShape(Shape2DBase shape)
        {
            ShapeMgr.AddShape(shape);
        }

        public void RemoveShape(Shape2DBase shape)
        {
            ShapeMgr.RemoveShape(shape);
        }

        public void Clear()
        {
            ShapeMgr?.ClearShapes();
            MsgMgr?.Clear();
            OnReapint();
        }
    }
}
