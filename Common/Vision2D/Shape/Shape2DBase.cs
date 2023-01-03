using System;
using System.Drawing;
using System.Xml.Serialization;
using HalconDotNet;

namespace Vision2D
{
    [XmlInclude(typeof(Shape2DLine))]
    [XmlInclude(typeof(Shape2DPoint))]
    [XmlInclude(typeof(Shape2DRect))]
    [XmlInclude(typeof(Shape2DCircle))]
    public class Shape2DBase
    {
        public Shape2DBase() { }

        public int ID { get; set; }

        public string Color { get; set; }

        public EShape2DType Type { get; set; }

        public bool IsEditable { get; set; }

        public bool IsVisible { get; set; }

        /// <summary>
        /// 操作点的大小，O-operate
        /// </summary>
        public double OSize = 3.0;

        protected int _handlesNum;

        protected int _activeHandleIdx;

        protected Size _msize = new Size(3, 3);

        [XmlIgnore]
        public Action OnMoved;

        public virtual void Paint(HWindow window) { }

        public virtual void Init(HWindow window, HImage image) { }

        public virtual double DistToClosestHandle(double x, double y) { return 0.0; }

        public virtual void MoveOrZoom(double newX, double newY) { }

        public virtual HRegion GetRegion() { return null; }
    }
}
