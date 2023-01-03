using System;
using HalconDotNet;
using BSLib;

namespace Vision3D
{
    public class Win3DManager
    {
        private JMatrix3D _matrix3D;

        private HImage _image;

        public ShapeManager ShapeMgr;

        public MsgManager MsgMgr;

        public Action OnReapint;

        public Action OnResetWinPart;

        private bool _isLuminace = false;

        public Win3DManager()
        {
            ShapeMgr = new ShapeManager();
            MsgMgr = new MsgManager();
        }

        public void UpdateMatrix(JMatrix3D matrix3D)
        {
            if (matrix3D == null)
                return;
            _matrix3D = matrix3D;
            _image = _matrix3D.ConvertToImage(_isLuminace);
            ShapeMgr.UpdateMatrix(matrix3D);
            OnResetWinPart?.Invoke();
        }

        public JMatrix3D GetCurrMatrix3D()
        {
            return _matrix3D;
        }

        public void SwitchMode(bool isLuminace)
        {
            if (_isLuminace != isLuminace)
            {
                _isLuminace = isLuminace;
                _image = _matrix3D?.ConvertToImage(_isLuminace);
            }
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

        public void AddShape(Shape3DBase shape)
        {
            ShapeMgr.AddShape(shape);
        }

        public void RemoveShape(Shape3DBase shape)
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
