using System;
using System.Linq;
using System.Collections.Generic;
using JSystem.Param;
using Meas3D;

namespace JSystem.Perform
{
    public class StatisticsManager
    {
        public string CurrDecision;

        public string CurrSN;

        public int Total;

        public int Pass;

        public int Fail;

        public double CT;

        public double UPH;

        private DateTime _startTime;

        private DateTime _endTime;

        public Action OnUpdateDispaly;

        public void StartClock()
        {
            _startTime = DateTime.Now;
        }

        public void StopClock()
        {
            _endTime = DateTime.Now;
            CT = (_endTime - _startTime).TotalSeconds / ParamManager.GetIntParam("产品个数");
            UPH = 3600 / CT;
        }

        public void UpdateCurrResult(string sn, string decision)
        {
            CurrSN = sn;
            CurrDecision = decision;
            Total++;
            if (CurrDecision == "PASS")
                Pass++;
            else
                Fail++;
            OnUpdateDispaly?.Invoke();
        }
    }
}
