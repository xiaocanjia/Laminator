using System;
using System.Drawing;
using System.Xml.Serialization;
using HalconDotNet;
using BSLib;

namespace Vision3D
{
    [XmlInclude(typeof(Shape3DLine))]
    [XmlInclude(typeof(Shape3DPoint))]
    [XmlInclude(typeof(Shape3DRect))]
    [XmlInclude(typeof(Shape3DCircle))]
    public class Shape3DBase
    {
        public Shape3DBase() { }

        public int ID { get; set; }

        public string Color { get; set; }

        public EShape3DType Type { get; set; }

        public bool IsEditable { get; set; }

        public bool IsVisible { get; set; }

        /// <summary>
        /// 操作点的大小，O-operate
        /// </summary>
        public double OSize = 3.0;

        protected int _handlesNum;

        protected int _activeHandleIdx;

        protected Size _msize = new Size(3, 3);

        protected JMatrix3D _matrix3D;

        [XmlIgnore]
        public Action OnMoved;

        public virtual void Paint(HWindow window) { }

        public virtual double DistToClosestHandle(double x, double y) { return 0.0; }

        public virtual void MoveOrZoom(double newX, double newY) { }

        public virtual HRegion GetRegion() { return null; }

        public virtual void UpdateData(JMatrix3D matrix3D, HWindow window) { }
    }
}
