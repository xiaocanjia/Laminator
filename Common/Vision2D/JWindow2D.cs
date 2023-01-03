using System;
using System.Windows.Forms;
using HalconDotNet;
using JLogging;

namespace Vision2D
{
    public partial class JWindow2D : UserControl
    {
        private object _imgLock = new object();

        private double _lastX, _lastY;  //记录鼠标的上一个位置

        private EOperationMode _currMode = EOperationMode.NONE;
        
        private HWindow _hWindow;

        private int _activeShapeIdx = -1;

        private Win2DManager _manager;

        private HImage _currImage;

        public JWindow2D()
        {
            InitializeComponent();
            _hWindow = HWindowControl.HalconWindow;
            HWindowControl.MouseUp += VisionControl_MouseUp;
            HWindowControl.MouseDown += VisionControl_MouseDown;
            HWindowControl.HMouseWheel += VisionControl_MouseWheel;
            HWindowControl.MouseMove += VisionControl_MouseMove;
        }

        public void Init(Win2DManager manager)
        {
            _manager = manager;
            _manager.ShapeMgr.SetWindow(_hWindow);
            _manager.OnReapint = RePaint;
            _manager.OnResetWinPart = ResetWinPart;
            ResetWinPart();
            RePaint();
        }

        public void RePaint()
        {
            try
            {
                _currImage = _manager?.GetCurrImage();
                if (_currImage == null)
                    return;
                _hWindow.DispCircle(0.0, 0.0, 1.0);
                HSystem.SetSystem("flush_graphic", "false");
                _hWindow.ClearWindow();
                if (_currImage.CountChannels() == 3)
                    _hWindow.DispColor(_currImage);
                else
                    _hWindow.DispImage(_currImage);
                _manager.ShapeMgr.DrawShapes();
                _manager.MsgMgr.DispMsg();
                HSystem.SetSystem("flush_graphic", "true");
                _hWindow.DispCircle(0.0, 0.0, 1.0);
            }
            catch (Exception ex)
            {
                LoggingIF.Log(ex.Message);
            }
        }

        public void ResetWinPart()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ResetWinPart()));
            }
            else
            {
                double startX = 0.0;
                double startY = 0.0;
                double width = 0.0;
                double height = 0.0;
                _manager.GetImageSize(out int imgWidth, out int imgHeight);
                if (imgWidth == 0 || imgHeight == 0)
                    return;
                double imgRatio = imgWidth / (double)imgHeight;
                double winRatio = Width / (double)Height;

                if (imgRatio >= winRatio)
                {
                    width = imgWidth;
                    height = imgWidth / winRatio;
                    startX = 0;
                    startY = (height - imgHeight) / 2;
                }
                else
                {
                    width = imgHeight * winRatio;
                    height = imgHeight;
                    startX = (width - imgWidth) / 2;
                    startY = 0;
                }
                _manager.MsgMgr.ResetSize();
                _hWindow.SetPart(-startY, -startX, height - startY - 1, width - startX - 1);
                _manager.ShapeMgr.SetOSize(height / 200);
            }
        }

        /// <summary>
        /// 锁定控件显示,其它线程不得进入
        /// </summary>
        private void LockDisplay()
        {
            System.Threading.Monitor.Enter(_imgLock);
        }

        /// <summary>
        /// 解锁控件显示,其它线程可操作
        /// </summary>
        private void UnlockDisplay()
        {
            System.Threading.Monitor.Exit(_imgLock);
        }

        private void VisionControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    _hWindow.GetMposition(out int y, out int x, out int button);
                    if (_currMode == EOperationMode.DRAWINGSHAPE)
                    {
                        Shape2DPoint point = new Shape2DPoint(y, x);
                        point.IsAutoSize = false;
                        _manager.ShapeMgr.AddShape(point);
                    }
                    else
                    {
                        _activeShapeIdx = _manager.ShapeMgr.GetActiveShape(x, y);

                        if (_activeShapeIdx == -1)
                        {
                            _lastX = e.X;
                            _lastY = e.Y;
                            _currMode = EOperationMode.MOVINGIMAGE;
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            _currMode = EOperationMode.MOVINGSHAPE;
                        }
                    }
                }
                catch { }
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
            RePaint();
        }

        private void VisionControl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                LockDisplay();
                switch (_currMode)
                {
                    case EOperationMode.MOVINGIMAGE:
                        MoveImage(e.X, e.Y);
                        break;
                    case EOperationMode.MOVINGSHAPE:
                        MoveOrZoomShape();
                        break;
                    case EOperationMode.DRAWINGSHAPE:
                        break;
                    case EOperationMode.NONE:
                        DispMousePos();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                LoggingIF.Log($"{ex.ToString()}", LogLevels.Error);
            }
            finally
            {
                UnlockDisplay();
            }
        }

        private void VisionControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ResetWinPart();
                RePaint();
            }
            else if (e.Button == MouseButtons.Left)
            {
                switch (_currMode)
                {
                    case EOperationMode.MOVINGIMAGE:
                        Cursor = Cursors.Arrow;
                        break;
                    case EOperationMode.MOVINGSHAPE:
                        _manager.ShapeMgr.GetShapeByIndex(_activeShapeIdx).OnMoved?.Invoke();
                        _manager.ShapeMgr.ResetActiveShapeIdx();
                        RePaint();
                        break;
                    case EOperationMode.DRAWINGSHAPE:
                        break;
                    case EOperationMode.NONE:
                        break;
                    default:
                        break;
                }
            }
            if (_currMode != EOperationMode.DRAWINGSHAPE)
                _currMode = EOperationMode.NONE;
        }

        private void VisionControl_MouseWheel(object sender, HMouseEventArgs e)
        {
            try
            {
                LockDisplay();
                ZoomImage(e.Delta, e.X, e.Y);
                RePaint();
            }
            catch (Exception ex)
            {
                LoggingIF.Log($"{ex.ToString()}", LogLevels.Error);
            }
            finally
            {
                UnlockDisplay();
            }
        }

        private void MoveImage(double newX, double newY)
        {
            double x = newX - _lastX;
            double y = newY - _lastY;

            _lastX = newX;
            _lastY = newY;
            _hWindow.GetPart(out HTuple row0, out HTuple col0, out HTuple row1, out HTuple col1);
            double zoom = (col1.D - col0.D) / Width;
            x *= zoom;
            y *= zoom;
            _hWindow.SetPart(row0.D - y, col0.D - x, row1.D - y, col1.D - x);
            RePaint();
        }

        private void MoveOrZoomShape()
        {
            _hWindow.GetMposition(out int y, out int x, out int button);
            _manager.ShapeMgr.MoveOrZoomShape(x, y);
            RePaint();
        }

        private void ZoomImage(int delta, double newX, double newY)
        {
            _hWindow.GetPart(out int row0, out int col0, out int row1, out int col1);

            int width = col1 - col0;
            int height = row1 - row0;

            double k = (double)width / Width;
            if ((k < 50.0 && delta < 0) || (k > 0.1 && delta > 0))
            {
                double zoom;
                if (delta > 0)
                    zoom = 1.2;
                else
                    zoom = 1.0 / 1.2;

                double r1 = row0 + ((1 - (1.0 / zoom)) * (newY - row0));
                double c1 = col0 + ((1 - (1.0 / zoom)) * (newX - col0));
                double r2 = r1 + (height / zoom);
                double c2 = c1 + (width / zoom);
                _manager.MsgMgr.ZoomSize(zoom);
                _hWindow.SetPart(r1, c1, r2, c2);
                _manager.ShapeMgr.SetOSize(height / zoom / 200);
            }
        }

        private void DispMousePos()
        {
            try
            {
                if (_currImage == null)
                {
                    Label_Pos.Text = "";
                    return;
                }
                _hWindow.GetMposition(out int row, out int col, out int button);
                string posX = (col * 0.02).ToString("F3");
                string posY = (row * 0.02).ToString("F3");
                string posZ = _currImage.GetGrayval(row, col).ToString();
                Label_Pos.Text = "(" + posX + "," + posY + "," + posZ + ") ";
            }
            catch { }
        }
    }
}
