using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using BSLib;
using Vision3D;
using MeasResult;

namespace Meas3D.Tool
{
    [XmlInclude(typeof(FitPlaneTool3DModel))]
    [XmlInclude(typeof(FitCircleTool3DModel))]
    [XmlInclude(typeof(FitLineTool3DModel))]
    [XmlInclude(typeof(VertexLocTool3DModel))]
    [XmlInclude(typeof(CirclesDistTool3DModel))]
    [XmlInclude(typeof(PointsDistTool3DModel))]
    [XmlInclude(typeof(CTLDistTool3DModel))]
    [XmlInclude(typeof(RegionHeightTool3DModel))]
    [XmlInclude(typeof(ClueTool3DModel))]
    [XmlInclude(typeof(LinesDistTool3DModel))]
    [XmlInclude(typeof(PlaneToPlaneAngleTool3DModel))]
    [XmlInclude(typeof(PlanesIntersectionTool3DModel))]
    public class Tool3DBaseModel
    {
        public Tool3DBaseModel() { }
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (NormalView != null)
                    NormalView.ToolName = _name;
                if (Results != null)
                {
                    for (int i = 0; i < Results.Length; i++)
                        Results[i].Tool = _name;
                }
            }
        }

        public ETool3DType Type { get; set; }

        protected JMatrix3D _matrix3D;

        protected double[] _xAxisParam;

        protected double[] _yAxisParam;

        public MesResult[] Results { get; set; }

        public bool IsCombined = false; //是否是组合算子

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnDelete;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnCloseSetupPanel;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnCopy;

        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;
        
        [XmlIgnore]
        public Func<Shape3DBase> OnGetShape;

        [XmlIgnore]
        public Action<EShape3DType> OnAddShapeByMouse;

        [XmlIgnore]
        public Action OnAddFinished;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action OnUpdateValue;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnUpdateCombinedTool;
        
        public delegate void AffineTrans(float[] xArrSrc, float[] yArrSrc, float[] zArrSrc, out float[] xArrDst, out float[] yArrDst, out float[] zArrDst);

        [XmlIgnore]
        public AffineTrans OnAffineTrans;

        [XmlIgnore]
        public MinimizedView NormalView { get; set; }

        [XmlIgnore]
        public UserControl SetupView { get; set; }

        [XmlIgnore]
        public Func<List<Tool3DBaseModel>> OnGetToolsList;

        public virtual void InitShape() { }

        public virtual void OpenSetupView()
        {
            SetupView.Dock = DockStyle.Fill;
            OnOpenSetupPanel?.Invoke(this);
        }

        public void UpdateCombinedTool()
        {
            OnUpdateCombinedTool?.Invoke(this);
        }

        public virtual bool ContainTool(Tool3DBaseModel tool) { return false; }

        public virtual void UpdateMatrix3D(JMatrix3D Matrix3D, double[] xAxisParam, double[] yAxisParam)
        {
            _matrix3D = Matrix3D;
            _xAxisParam = xAxisParam;
            _yAxisParam = yAxisParam;
            UpdateResult();
            UpdateShape();
        }

        public virtual void CloseSetupView() { OnCloseSetupPanel?.Invoke(this); }

        public virtual void DeleteTool() { OnDelete?.Invoke(this); }

        public virtual void CopyTool() { OnCopy?.Invoke(this); }

        public virtual void UpdateResult() { }

        public virtual void UpdateShape()
        {
            OnRepaint?.Invoke();
        }

        protected void ClearShapes(List<Shape3DBase> shapes)
        {
            if (shapes == null) return;
            foreach (Shape3DBase shape in shapes)
                OnRemoveShape?.Invoke(shape);
        }

        public Tool3DBaseModel Copy()
        {
            object tool;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(Tool3DBaseModel));
                xml.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                tool = xml.Deserialize(ms);
                ms.Close();
            }
            return (Tool3DBaseModel)tool;
        }
    }
}
