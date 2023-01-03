namespace JSystem.Station
{
    public class PointInfo
    {
        public PointInfo() { }

        public PointInfo(string name)
        {
            Name = name;
        }

        public string Name;

        public double[] Pos = new double[10];
    }
}
