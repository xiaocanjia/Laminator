using BoardSDK;
using System.Xml.Serialization;

namespace BoardSys
{
    public class BoardParam
    {
        public EBoardType Type = EBoardType.Advantech;

        public string ID = "";

        public AxisParam[] AxesParam;

        public DIParam[] DIsParam;  //输入

        public DOParam[] DOsParam;  //输出

        [XmlIgnore]
        public IBoard Board;
    }
}
