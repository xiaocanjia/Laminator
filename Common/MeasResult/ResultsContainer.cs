using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MeasResult
{
    public partial class ResultsContainer : UserControl
    {
        private List<ResultPanel> _resultPanels = new List<ResultPanel>();

        public ResultsContainer()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            UpdateStyles();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void CreateHandle()
        {
            if (!IsHandleCreated)
            {
                try
                {
                    base.CreateHandle();
                }
                catch { }
                finally
                {
                    if (!IsHandleCreated)
                    {
                        base.RecreateHandle();
                    }
                }
            }
        }

        public void AddResult(MesResult[] results)
        {
            ResultsPanel.Controls.Clear();
            GC.Collect();
            if (results == null) return;
            foreach (MesResult result in results)
            {
                ResultPanel panel = new ResultPanel(result);
                _resultPanels.Add(panel);
                panel.BorderStyle = BorderStyle.FixedSingle;
                ResultsPanel.Controls.Add(panel);
            }
        }

        public void UpdateValues()
        {
            foreach (ResultPanel panel in _resultPanels)
            {
                panel.UpdateLabelValue();
            }
        }
    }
}
