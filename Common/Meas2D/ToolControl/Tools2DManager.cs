using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using HalconDotNet;
using Vision2D;
using BSLib;
using JLogging;

namespace Meas2D
{
    public class Tools2DManager
    {
        public List<Tool2DBaseModel> ToolsList;

        private HImage _image;

        private double[] _xAxisParam;

        private double[] _yAxisParam;

        private Tool2DBaseModel _currentTool;

        [XmlIgnore]
        public Dictionary<ETool2DType, string> ToolsName;

        [XmlIgnore]
        public Action<Shape2DBase> OnAddShape;

        [XmlIgnore]
        public Action<EShape2DType> OnAddShapeByMouse;

        [XmlIgnore]
        public Func<Shape2DBase> OnGetShape;

        [XmlIgnore]
        public Action OnAddFinished;

        [XmlIgnore]
        public Action<Shape2DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<List<Tool2DBaseModel>> OnUpdateResults;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnAddTool;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnRemoveTool;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public Action<Tool2DBaseModel> OnCloseSetupPanel;

        [XmlIgnore]
        public Action<string> OnAddLog;

        public Tools2DManager()
        {
            ToolsList = new List<Tool2DBaseModel>();
            ToolsName = new Dictionary<ETool2DType, string>();
            ToolsName.Add(ETool2DType.READCODE, "读取二维码");
        }

        public void UpdateTools(HImage image, double[] xAxisParam, double[] yAxisParam)
        {
            _image = image.Clone();
            _xAxisParam = xAxisParam ?? (new double[3] { 0, 1, 0 });
            _yAxisParam = yAxisParam ?? (new double[3] { 1, 0, 0 });
            foreach (Tool2DBaseModel tool in ToolsList)
            {
                if (!tool.IsCombined)
                    tool.UpdateImage(_image, _xAxisParam, _yAxisParam);
            }
            foreach (Tool2DBaseModel tool in ToolsList)
            {
                if (tool.IsCombined)
                    tool.UpdateImage(_image, _xAxisParam, _yAxisParam);
            }
            OnUpdateResults?.Invoke(ToolsList);
        }

        public void AddTool(ETool2DType type)
        {
            try
            {
                Tool2DBaseModel tool = ToolsFactory.CreateTool(type);
                tool.Name = ToolsName[type] + (ToolsList.Where(x => x.Type == type).Count() + 1);
                InitTool(tool);
                tool.OpenSetupView();
                tool.UpdateImage(_image, _xAxisParam, _yAxisParam);
                OnAddTool?.Invoke(tool);
                ToolsList.Add(tool);
            }
            catch (Exception ex)
            {
                OnAddLog?.Invoke($"工具添加异常，详情查看日志");
                LoggingIF.Log($"{ex.ToString()}", LogLevels.Error);
            }
        }

        public void InitTool(Tool2DBaseModel tool)
        {
            tool.OnOpenSetupPanel = OpenSetupPanel;
            tool.OnCloseSetupPanel = OnCloseSetupPanel;
            tool.OnAddShape = OnAddShape;
            tool.OnAddShapeByMouse = OnAddShapeByMouse;
            tool.OnAddFinished = OnAddFinished;
            tool.OnGetShape = OnGetShape;
            tool.OnRemoveShape = OnRemoveShape;
            tool.OnRepaint = OnRepaint;
            tool.OnDelete = DeleteTool;
            tool.OnCopy = CopyTool;
            tool.OnAddLog = OnAddLog;
            tool.OnGetToolsByType = GetToolsByType;
            tool.OnUpdateCombinedTool = UpdateCombinedTool;
            tool.InitShape();
        }

        private void OpenSetupPanel(Tool2DBaseModel tool)
        {
            OnOpenSetupPanel(tool);
            _currentTool = tool;
        }

        public void CloseSetupPanel()
        {
            _currentTool?.CloseSetupView();
        }

        public string GetCode()
        {
            List<Tool2DBaseModel> tools = GetToolsByType(ETool2DType.READCODE);
            if (tools == null || tools.Count == 0)
                return "";
            foreach (Tool2DBaseModel tool in tools)
            {
                if (((ReadCodeToolModel)tool).Code != "无")
                    return ((ReadCodeToolModel)tool).Code;
            }
            return "";
        }

        private List<Tool2DBaseModel> GetToolsByType(ETool2DType type)
        {
            return ToolsList.FindAll(tool => (tool.Type == type));
        }

        private void UpdateCombinedTool()
        {
            foreach (Tool2DBaseModel tool in ToolsList)
            {
                if (tool.IsCombined)
                    tool.UpdateImage(_image, _xAxisParam, _yAxisParam);
            }
        }

        private void DeleteTool(Tool2DBaseModel tool)
        {
            ToolsList.Remove(tool);
            OnRemoveTool?.Invoke(tool);
        }

        private void CopyTool(Tool2DBaseModel tool)
        {
            Tool2DBaseModel copyTool = tool.Copy();
            copyTool.Name = ToolsName[tool.Type] + (ToolsList.Where(x => x.Type == copyTool.Type).Count() + 1);
            InitTool(copyTool);
            copyTool.OpenSetupView();
            copyTool.UpdateImage(_image, _xAxisParam, _yAxisParam);
            OnAddTool?.Invoke(copyTool);
            ToolsList.Add(copyTool);
        }
    }
}
