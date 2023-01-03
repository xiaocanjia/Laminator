using System;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;
using BoardSys;

namespace JSystem.Station
{
    public partial class StationView : UIPage
    {
        StationBase _station;

        public StationView()
        {
            InitializeComponent();
        }

        public StationView(StationBase station) : this()
        {
            _station = station;
            foreach (AxisInfo axis in station.AxesInfo)
            {
                AxisPanel panel = axis.View;
                axis.View.Refresh();
                Panel_Axes.Controls.Add(panel);
                Panel_Axes.Height += (panel.Height + 3);
                Panel_PointInfo.Location = new Point(Panel_PointInfo.Location.X, Panel_PointInfo.Location.Y + panel.Height + 3);
                Panel_PointInfo.Height = Panel2.Height - Panel_Axes.Height - 15;
                if (axis.IsBelt)
                    continue;
                DGV_PointInfo.Columns.Add(axis.Name, axis.Name);
                DGV_PointInfo.Columns[DGV_PointInfo.Columns.Count - 1].Width = 90;
                DGV_PointInfo.Columns[DGV_PointInfo.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (_station.DebugForm == null)
                Btn_Debug.Visible = false;
        }

        public void UpdatePointsInfo()
        {
            if (_station.PointsInfo == null)
                return;
            foreach (PointInfo point in _station.PointsInfo)
            {
                object[] info = new object[_station.AxesInfo.Length + 1];
                info[0] = point.Name;
                int idx = 1;
                for (int i = 1; i <= _station.AxesInfo.Length; i++)
                {
                    if (_station.AxesInfo[i - 1].IsBelt)
                        continue;
                    info[idx] = double.IsNaN(point.Pos[i - 1]) ? "/" : point.Pos[i - 1].ToString();
                    idx++;
                }
                DGV_PointInfo.Rows.Add(info);
            }
        }

        public void SetEnable(bool isEnable)
        {
            foreach (AxisInfo axis in _station.AxesInfo)
                axis.View.SetEnable(isEnable);
            DGV_PointInfo.ReadOnly = !isEnable;
            foreach (Control control in Panel_PointInfo.Controls)
            {
                if (control is UIButton button)
                    button.Enabled = isEnable;
            }
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            for (int i = 0; i < DGV_PointInfo.Rows.Count; i++)
            {
                int idx = 0;
                for (int j = 0; j < _station.AxesInfo.Length; j++)
                {
                    if (_station.AxesInfo[j].IsBelt)
                        continue;
                    _station.PointsInfo[i].Pos[j] = DGV_PointInfo.Rows[i].Cells[idx + 1].Value.ToString() == "/" ? double.NaN : Convert.ToDouble(DGV_PointInfo.Rows[i].Cells[idx + 1].Value);
                    idx++;
                }
            }
            UIMessageTip.Show("应用成功");
        }

        private void Btn_Record_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            if (DGV_PointInfo.CurrentRow == null)
                return;
            if (!UIMessageBox.ShowAsk($"请确认是否将当前坐标记录到{DGV_PointInfo.CurrentRow.Cells[0].Value}"))
                return;
            int idx = 0;
            for (int i = 0; i < _station.AxesInfo.Length; i++)
            {
                if (_station.AxesInfo[i].IsBelt)
                    continue;
                DGV_PointInfo.CurrentRow.Cells[idx + 1].Value = BoardSysIF.Instance.GetActPos(_station.AxesInfo[i].BoardID, _station.AxesInfo[i].AxisIndex);
                idx++;
            }
        }

        private void Btn_SingleAxisMove_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            if (DGV_PointInfo.CurrentCell == null || DGV_PointInfo.CurrentCell.Value.ToString() == "/")
                return;
            int idx = DGV_PointInfo.CurrentCell.ColumnIndex - 1;
            if (idx < 0) return;
            BoardSysIF.Instance.AbsMove(_station.AxesInfo[idx].BoardID, _station.AxesInfo[idx].AxisIndex, Convert.ToDouble(DGV_PointInfo.CurrentCell.Value));
        }

        private void Btn_AllAxisMove_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            if (DGV_PointInfo.CurrentRow == null)
                return;
            int idx = 0;
            for (int i = 0; i < _station.AxesInfo.Length; i++)
            {
                if (_station.AxesInfo[i].IsBelt)
                    continue;
                idx++;
                if (DGV_PointInfo.CurrentRow.Cells[idx].Value.ToString() == "/")
                    continue;
                BoardSysIF.Instance.AbsMove(_station.AxesInfo[i].BoardID, _station.AxesInfo[i].AxisIndex, Convert.ToDouble(DGV_PointInfo.CurrentRow.Cells[idx].Value));
            }
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            if (DGV_PointInfo.Columns.Count == 1)
                return;
            foreach (AxisInfo axis in _station.AxesInfo)
                BoardSysIF.Instance.StopMove(axis.BoardID, axis.AxisIndex);
        }

        private void Btn_Debug_Click(object sender, EventArgs e)
        {
            _station.DebugForm.StartPosition = FormStartPosition.CenterScreen;
            _station.DebugForm.ShowDialog();
        }

        private void CbB_MoveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (AxisInfo axis in _station.AxesInfo)
                axis.View.SetMoveType(CbB_MoveType.Text);
        }
    }
}
