using System;
using System.Xml.Serialization;

namespace MeasResult
{
    public enum Decision
    {
        PASS,
        FAIL
    }

    public class MesResult
    {
        public MesResult() { }

        public MesResult(string tool, string name, string unit, bool isOutput = true) : this()
        {
            LowerLimit = -100;
            UpperLimit = 100;
            Offset = 0;
            HasLimit = true;
            Tool = tool;
            Name = name;
            ID = name;
            Unit = unit;
            IsOutput = isOutput;
        }

        public void SetResult(double value, double time)
        {
            Value = value;
            SpanTime = time;
        }

        public string Tool { get; set; }

        public string Name { get; set; }

        public string ID { get; set; }

        public bool HasLimit;

        private double _value = 0;

        [XmlIgnore]
        public double Value
        {
            get { return _value; }
            set
            {
                _value = Math.Round(IsAbs ? Math.Abs(value) : value, 3);
                Result = (_value + Offset).ToString() + Unit;
            }
        }

        [XmlIgnore]
        public string Result;

        private double _offset;
        public double Offset
        {
            get { return Math.Round(_offset, 3); }
            set { _offset = value; }
        }

        public string Unit { get; set; }

        public double UpperLimit { get; set; }

        public double LowerLimit { get; set; }

        public Decision Decision
        {
            get
            {
                if (double.IsNaN(Value))
                    return Decision.FAIL;
                if (Value >= LowerLimit && Value <= UpperLimit)
                    return Decision.PASS;
                return Decision.FAIL;
            }
        }

        public double SpanTime { get; set; }

        public bool IsOutput { get; set; }

        public bool IsAbs { get; set; }
    }
}
