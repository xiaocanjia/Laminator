using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sunny.UI;
using MeasResult;
using JSystem.Param;
using System.Windows.Forms;

namespace JSystem.Perform
{
    public partial class PerformPage : UIPage
    {
        private PerformManager _manager;

        public PerformPage()
        {
            InitializeComponent();
        }

        public void Init(PerformManager manager)
        {
            if (manager == null)
                return;
            _manager = manager;
            _manager.OnSetButtonState = SetButtonState;
            _manager.OnUpdateRets = UpdateRets;
            runningMsgPanel.Init(LogManager.Instance);
            statisticsPanel.Init(_manager.StatisticsMgr);
        }

        private void SetButtonState(bool isStart)
        {
            if(InvokeRequired)
                BeginInvoke(new Action(() => { SetButtonState(isStart); }));
            else
                Btn_Start.Symbol = isStart ? 61516 : 61515;
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                Invoke(new Action(() => { Btn_Reset.Enabled = false; }));
                Btn_Reset.Enabled = false;
                Btn_Start.Symbol = 61515;
                _manager.OnInit?.Invoke();
                Invoke(new Action(() => { Btn_Reset.Enabled = true; }));
            }).Start();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (Btn_Start.Symbol == 61515)
            {
                UpdateDGV_Tray();
                if (_manager.Start())
                    Btn_Start.Symbol = 61516;
            }
            else if (Btn_Start.Symbol == 61516)
            {
                _manager.OnPause?.Invoke();
                Btn_Start.Symbol = 61515;
            }
        }

        private void Btn_End_Click(object sender, EventArgs e)
        {
            _manager.OnStop?.Invoke(true);
            Btn_Start.Symbol = 61515;
        }

        private void Btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            _manager.ClearAlarm();
        }

        public void UpdateRets(int rowIdx, int colIdx, List<MesResult> rets)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateRets(rowIdx, colIdx, rets)));
            }
            else
            {
                int failCount = 0;
                DGV_Results.Rows.Clear();
                for (int i = 0; i < rets.Count; i++)
                {
                    if (!rets[i].IsOutput)
                        continue;
                    DGV_Results.AddRow(new object[] { rets[i].Tool, rets[i].Name, rets[i].Value, rets[i].UpperLimit, rets[i].LowerLimit, rets[i].Decision });
                    if (rets[i].Decision == Decision.FAIL)
                    {
                        DGV_Results.Rows[DGV_Results.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                        failCount++;
                    }
                }
                if (rowIdx == 0 && colIdx == 0)
                    DGV_Tray.ClearCellStyles();
                DGV_Tray.Rows[rowIdx].Cells[colIdx].Value = failCount > 0 ? "FAIL" : "PASS";
            }
        }

        private void DGV_Tray_SizeChanged(object sender, EventArgs e)
        {
            UpdateDGV_Tray();
        }

        private void UpdateDGV_Tray()
        {
            DGV_Tray.ClearAll();
            if (ParamManager.GetIntParam("料盘列数") == 0)
                return;
            int width = (DGV_Tray.Width - 5) / ParamManager.GetIntParam("料盘列数") / 3;
            for (int i = 0; i < ParamManager.GetIntParam("料盘列数"); i++)
            {
                DGV_Tray.Columns.Add("", "二维码");
                DGV_Tray.Columns[DGV_Tray.Columns.Count - 1].Width = width * 2;
                DGV_Tray.Columns[DGV_Tray.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DGV_Tray.Columns.Add("", "结果");
                DGV_Tray.Columns[DGV_Tray.Columns.Count - 1].Width = width;
                DGV_Tray.Columns[DGV_Tray.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < ParamManager.GetIntParam("料盘行数"); i++)
            {
                DGV_Tray.Rows.Add();
            }
        }
    }
}
