using System;
using System.Linq;
using System.Collections.Generic;
using MeasResult;
using JSystem.Param;

namespace JSystem.Perform
{
    public class PerformManager
    {
        public StatisticsManager StatisticsMgr;

        public Func<bool> OnInit;

        public Func<bool> OnStart;

        public Func<bool> OnPause;

        public Func<bool, bool> OnStop;

        public Action<bool> OnSetButtonState;

        public Action OnClearAlarm;

        public Action<int, int, List<MesResult>> OnUpdateRets;

        private int _rowIdx = 0;

        private int _colIdx = 0;

        public PerformManager()
        {
            StatisticsMgr = new StatisticsManager();
        }

        public bool Start()
        {
            _rowIdx = 0;
            _colIdx = 0;
            return OnStart();
        }
        
        public void UpdateRusults(string sn, List<MesResult> rets)
        {
            string decision = rets.Where((ret) => { return ret.Decision == Decision.FAIL; }).Count() > 0 ? "FAIL" : "PASS";
            OnUpdateRets?.Invoke(_rowIdx, _colIdx, rets);
            StatisticsMgr.UpdateCurrResult(sn, decision);
            _rowIdx++;
            if (_rowIdx >= ParamManager.GetIntParam("料盘行数"))
            {
                _colIdx++;
                _rowIdx = 0;
                if (_colIdx >= ParamManager.GetIntParam("料盘列数"))
                    _colIdx = 0;
            }
        }

        public void SetButtonState(bool isStart)
        {
            OnSetButtonState?.Invoke(isStart);
        }

        public void ClearAlarm()
        {
            OnClearAlarm?.Invoke();
        }
    }
}
