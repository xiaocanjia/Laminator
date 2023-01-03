using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using HalconDotNet;
using Vision2D;
using MeasResult;

namespace Meas2D
{
    [XmlInclude(typeof(ReadCodeToolModel))]
    public class Tool2DBaseModel
    {
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

        public ETool2DType Type;

        public bool IsCombined;

        protected HImage _image;

        protected double[] _xAxisParam;

        protected double[] _yAxisParam;

        [XmlIgnore]
        public MesResult[] Results { get; set; }

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnDelete;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnCloseSetupPanel;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnCopy;

        [XmlIgnore]
        public Action<Shape2DBase> OnAddShape;

        [XmlIgnore]
        public Func<Shape2DBase> OnGetShape;

        [XmlIgnore]
        public Action<EShape2DType> OnAddShapeByMouse;

        [XmlIgnore]
        public Action OnAddFinished;

        [XmlIgnore]
        public Action<Shape2DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action OnUpdateValue;

        [XmlIgnore]
        public Action OnUpdateCombinedTool;

        [XmlIgnore]
        public MinimizedView NormalView { get; set; }

        [XmlIgnore]
        public UserControl SetupView { get; set; }

        [XmlIgnore]
        public Action<string> OnAddLog;

        [XmlIgnore]
        public Func<ETool2DType, List<Tool2DBaseModel>> OnGetToolsByType;

        public virtual void InitShape() { }

        public virtual void UpdateImage(HImage image, double[] xAxisParam, double[] yAxisParam)
        {
            _image = image;
            _xAxisParam = xAxisParam;
            _yAxisParam = yAxisParam;
            UpdateResult();
            UpdateShape();
        }

        public virtual void OpenSetupView()
        {
            SetupView.Dock = DockStyle.Fill;
            OnOpenSetupPanel?.Invoke(this);
        }

        public virtual void CloseSetupView() { OnCloseSetupPanel?.Invoke(this); }

        public virtual void DeleteTool() { OnDelete?.Invoke(this); }

        public virtual void CopyTool() { OnCopy?.Invoke(this); }

        public virtual void UpdateResult() { }

        public virtual void UpdateShape() { }

        protected void ClearShapes(List<Shape2DBase> shapes)
        {
            if (shapes == null) return;
            foreach (Shape2DBase shape in shapes)
                OnRemoveShape?.Invoke(shape);
        }

        public Tool2DBaseModel Copy()
        {
            object tool;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(Tool2DBaseModel));
                xml.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                tool = xml.Deserialize(ms);
                ms.Close();
            }
            return (Tool2DBaseModel)tool;
        }
    }
}
