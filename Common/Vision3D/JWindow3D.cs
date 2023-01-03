using System;
using System.Windows.Forms;
using HalconDotNet;
using BSLib;
using JLogging;

namespace Vision3D
{
    public partial class JWindow3D : UserControl
    {
        private object _imgLock = new object();

        private double _lastX, _lastY;  //记录鼠标的上一个位置

        private OperationMode _currMode = OperationMode.NONE;

        public HWindow _hWindow;

        private int _activeShapeIdx = -1;

        private bool _isLuminace = false;

        private DateTime _lastTime;

        private Win3DManager _manager;

        public JWindow3D()
        {
            InitializeComponent();
            CbB_Mode.SelectedIndex = 0;
            _hWindow = HWindowControl.HalconWindow;
            HWindowControl.SizeChanged += HWindowControl_SizeChanged;
            HWindowControl.MouseUp += VisionControl_MouseUp;
            HWindowControl.MouseDown += VisionControl_MouseDown;
            HWindowControl.HMouseWheel += VisionControl_MouseWheel;
            HWindowControl.MouseMove += VisionControl_MouseMove;
        }

        private void HWindowControl_SizeChanged(object sender, EventArgs e)
        {
            ResetWinPart();
            RePaint();
        }

        public void Init(Win3DManager manager)
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
                _hWindow.DispCircle(0.0, 0.0, 1.0);
                HSystem.SetSystem("flush_graphic", "false");
                _hWindow.ClearWindow();
                HImage image = _manager?.GetCurrImage();
                if (image == null)
                    return;
                _hWindow.DispColor(image);
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

        private void ResetWinPart()
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
                HImage image = _manager?.GetCurrImage();
                if (image == null || Width == 0 || Height == 0) return;
                image.GetImageSize(out int imgWidth, out int imgHeight);
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
                    if (_currMode == OperationMode.DRAWINGSHAPE)
                    {
                        Shape3DPoint point = new Shape3DPoint(y, x);
                        point.IsAutoSize = false;
                    }
                    else
                    {
                        _activeShapeIdx = _manager.ShapeMgr.GetActiveShape(x, y);

                        if (_activeShapeIdx == -1)
                        {
                            _lastX = e.X;
                            _lastY = e.Y;
                            _currMode = OperationMode.MOVINGIMAGE;
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            _currMode = OperationMode.MOVINGSHAPE;
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
                    case OperationMode.MOVINGIMAGE:
                        MoveImage(e.X, e.Y);
                        break;
                    case OperationMode.MOVINGSHAPE:
                        MoveOrZoomShape();
                        break;
                    case OperationMode.DRAWINGSHAPE:
                        break;
                    case OperationMode.NONE:
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
                    case OperationMode.MOVINGIMAGE:
                        Cursor = Cursors.Arrow;
                        break;
                    case OperationMode.MOVINGSHAPE:
                        _manager.ShapeMgr.GetShapeByIndex(_activeShapeIdx).OnMoved?.Invoke();
                        _manager.ShapeMgr.ResetActiveShapeIdx();
                        RePaint();
                        break;
                    case OperationMode.DRAWINGSHAPE:
                        break;
                    case OperationMode.NONE:
                        break;
                    default:
                        break;
                }
            }
            if (_currMode != OperationMode.DRAWINGSHAPE)
                _currMode = OperationMode.NONE;
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
                DateTime currTime = DateTime.Now;
                if ((currTime - _lastTime).TotalMilliseconds < 100)
                    return;
                JMatrix3D matrix3D = _manager?.GetCurrMatrix3D();
                if (matrix3D == null)
                {
                    Label_Pos.Text = "";
                    return;
                }
                _lastTime = currTime;
                _hWindow.GetMposition(out int row, out int col, out int button);
                string posX = (col * matrix3D.Pitch).ToString("F3");
                string posY = (row * matrix3D.Pitch).ToString("F3");
                string posZ = (matrix3D.HeightData[row * matrix3D.Column + col]).ToString("F3");
                string Luminace = (matrix3D.LuminaceData[row * matrix3D.Column + col]).ToString();
                Label_Pos.Text = "(" + posX + "," + posY + "," + posZ + ") " + Luminace;
            }
            catch { }
        }

        private void CbB_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isLuminace = CbB_Mode.Text == "亮度图";
            _manager?.SwitchMode(_isLuminace);
            RePaint();
        }
    }
}
