using System.Xml.Serialization;

namespace BoardSys
{
    public class AxisParam
    {
        public int Index = 0;

        public string Name = "";
        
        public double MoveVelH = 20.0;

        [XmlIgnore]
        public double MoveVelHPluse
        {
            get { return MoveVelH * PlusePerMM; }
        }

        public double MoveVelL = 2.0;

        [XmlIgnore]
        public double MoveVelLPluse
        {
            get { return MoveVelL * PlusePerMM; }
        }

        public double MoveAcc = 20.0;

        [XmlIgnore]
        public double MoveAccPluse
        {
            get { return MoveAcc * PlusePerMM; }
        }

        public double MoveDcc = 20.0;

        [XmlIgnore]
        public double MoveDccPluse
        {
            get { return MoveDcc * PlusePerMM; }
        }

        public uint MoveDir = 0;

        public uint HomeMode = 0;

        public uint HomeDir = 0;

        public double HomeOffset = 1.0;

        public double HomeVelH = 20.0;

        [XmlIgnore]
        public double HomeVelHPluse
        {
            get { return HomeVelH * PlusePerMM; }
        }

        public double HomeVelL = 20.0;

        [XmlIgnore]
        public double HomeVelLPluse
        {
            get { return HomeVelL * PlusePerMM; }
        }

        public double HomeAcc = 3.0;

        [XmlIgnore]
        public double HomeAccPluse
        {
            get { return HomeAcc * PlusePerMM; }
        }

        public double HomeDcc = 3.0;

        [XmlIgnore]
        public double HomeDccPluse
        {
            get { return HomeDcc * PlusePerMM; }
        }

        public uint PlusePerMM = 1000;
    }
}
