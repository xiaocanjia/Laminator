using System.Xml.Serialization;

namespace BoardSys
{
    public class DIParam
    {
        [XmlIgnore]
        public string BoardID = "";

        public int AxisIndex = 0;

        public int PointIndex = 0;

        public string Name = "";
    }

    public class DOParam
    {
        [XmlIgnore]
        public string BoardID = "";

        public int AxisIndex = 0;

        public int PointIndex = 0;

        public string Name = "";
    }
}
