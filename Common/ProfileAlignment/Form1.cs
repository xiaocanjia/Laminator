using System;
using System.Drawing;
using System.Collections.Generic;
using Sunny.UI;
using System.Threading.Tasks;
using System.Threading;
using Camera3DSDK;

namespace ProfileCalib
{
    public partial class Form1 : UIForm
    {
        private float _interval = 0.012f;

        private List<Camera3D> _camList;

        public void AddCam3D(Camera3D cam3D)
        {
            _camList.Add(cam3D);
        }

        public void StartGrab()
        {
           
        }

        public Form1()
        {
            InitializeComponent();
            CbB_Cam_Name.Items.Clear();
            foreach (ECamera3DType type in Enum.GetValues(typeof(ECamera3DType)))
                CbB_Cam_Name.Items.Add(type.ToString());
            _camList = new List<Camera3D>();
            Camera3D cam1 = new Camera3D();
            cam1.Color = Color.Red;
            _camList.Add(cam1);
            Panel.Controls.Add(cam1.View);
            Camera3D cam2 = new Camera3D();
            cam2.Color = Color.Blue;
            _camList.Add(cam2);
            Panel.Controls.Add(cam2.View);
            CbB_Cam_Name.SelectedIndex = 14;

            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.YAxis.AxisLabel.DecimalCount = 3;
            option.XAxis.Name = "X";
            option.YAxis.Name = "Y";
            
            ProfileChart.SetOption(option);
            ProfileChart.Option.YAxis.Max = 15;
            ProfileChart.Option.YAxis.Min = -15.0;
            ProfileChart.Option.XAxis.Max = 0.0;
            ProfileChart.Option.YAxis.Min = 40.0;
        }

        public void SetInterval(float interval)
        {
            _interval = interval;
        }

        private void Btn_StartGrab_Click(object sender, EventArgs e)
        {
            foreach (Camera3D cam in _camList)
            {
                var series = ProfileChart.Option.AddSeries(new UILineSeries(cam.IP));
                series.ShowLine = false;
                series.SymbolSize = 4;
                series.Color = cam.Color;
                series.CustomColor = true;
            }
            new Task(() =>
            {
                while (true)
                {
                    Invoke(new Action(() =>
                    {
                        foreach (Camera3D cam in _camList)
                        {
                            ProfileChart.Option.Clear(cam.IP);
                            float[] profile = cam.GrabProfile();
                            for (int i = 0; i < profile.Length; i++)
                                ProfileChart.Option.AddData(cam.IP, i * _interval, profile[i]);
                        }
                        ProfileChart.Refresh();
                    }));
                    Thread.Sleep(100);
                }
            }).Start();
        }

        private void CbB_Cam_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Camera3D cam in _camList)
                cam.SetCameraType(CbB_Cam_Name.SelectedIndex);
        }
    }
}
