using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using Vision3D;
using BSLib;
using MeasResult;

namespace Meas3D.Tool
{
    public class Tools3DManager
    {
        public List<Tool3DBaseModel> ToolsList;

        private JMatrix3D _Matrix3D;

        private double[] _xAxisParam;

        private double[] _yAxisParam;

        private Tool3DBaseModel _currentTool;

        [XmlIgnore]
        public Dictionary<ETool3DType, string> ToolsName;

        [XmlIgnore]
        public Action<Shape3DBase> OnAddShape;

        [XmlIgnore]
        public Action<EShape3DType> OnAddShapeByMouse;

        [XmlIgnore]
        public Func<Shape3DBase> OnGetShape;

        [XmlIgnore]
        public Action OnAddFinished;

        [XmlIgnore]
        public Action<Shape3DBase> OnRemoveShape;

        [XmlIgnore]
        public Action OnRepaint;

        [XmlIgnore]
        public Action<List<MesResult>> OnUpdateResults;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnAddTool;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnRemoveTool;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnOpenSetupPanel;

        [XmlIgnore]
        public Action<Tool3DBaseModel> OnCloseSetupPanel;

        public delegate void AffineTrans1(float[] xArrSrc, float[] yArrSrc, float[] zArrSrc, out float[] xArrDst, out float[] yArrDst, out float[] zArrDst);

        [XmlIgnore]
        public AffineTrans1 OnAffineTrans;

        public Tools3DManager()
        {
            ToolsList = new List<Tool3DBaseModel>();
            ToolsName = new Dictionary<ETool3DType, string>();
            ToolsName.Add(ETool3DType.FITCIRCLE, "拟合圆");
            ToolsName.Add(ETool3DType.FITLINE, "拟合直线");
            ToolsName.Add(ETool3DType.FITPLANE, "拟合平面");
            ToolsName.Add(ETool3DType.VECTEXLOC, "顶点坐标");
            ToolsName.Add(ETool3DType.REGIONHEIGHT, "高度测量");
            ToolsName.Add(ETool3DType.CIRCLESDIST, "圆圆距离");
            ToolsName.Add(ETool3DType.LINESDIST, "线线距离");
            ToolsName.Add(ETool3DType.CTLDIST, "圆线距离");
            ToolsName.Add(ETool3DType.PLANESINTERSECTION, "面面交点");
            ToolsName.Add(ETool3DType.POINTSDIST, "点点距离");
            ToolsName.Add(ETool3DType.PLANETOPLANEANGLE, "面面角度");
        }

        public void UpdateMatrix3D(JMatrix3D Matrix3D, double[] xAxisParam, double[] yAxisParam)
        {
            _Matrix3D = Matrix3D;
            _xAxisParam = xAxisParam ?? (new double[3] { 0, 1, 0 });
            _yAxisParam = yAxisParam ?? (new double[3] { 1, 0, 0 });
            UpdateTools();
        }

        public void UpdateTools()
        {
            foreach (Tool3DBaseModel tool in ToolsList)
            {
                if (!tool.IsCombined)
                    tool.UpdateMatrix3D(_Matrix3D, _xAxisParam, _yAxisParam);
            }
            foreach (Tool3DBaseModel tool in ToolsList)
            {
                if (tool.IsCombined)
                    tool.UpdateMatrix3D(_Matrix3D, _xAxisParam, _yAxisParam);
            }
            OnRepaint?.Invoke();
        }

        public List<MesResult> GetResults()
        {
            List<MesResult> resultList = new List<MesResult>();
            foreach (Tool3DBaseModel tool in ToolsList)
            {
                if (tool.Results == null) continue;
                resultList.AddRange(tool.Results);
            }
            return resultList;
        }

        public void AddTool(ETool3DType type)
        {
            try
            {
                Tool3DBaseModel tool = ToolsFactory.CreateTool(type);
                tool.Name = ToolsName[type] + (ToolsList.Where(x => x.Type == type).Count() + 1);
                InitTool(tool);
                tool.OpenSetupView();
                tool.UpdateMatrix3D(_Matrix3D, _xAxisParam, _yAxisParam);
                OnAddTool?.Invoke(tool);
                ToolsList.Add(tool);
            }
            catch (Exception ex)
            {
                throw new Exception("工具添加异常" + ex.Message);
            }
        }

        public void InitTool(Tool3DBaseModel tool)
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
            tool.OnGetToolsList = GetTools;
            tool.OnUpdateCombinedTool = UpdateCombinedTool;
            tool.OnAffineTrans = AffineTrans;
            tool.InitShape();
        }

        private void AffineTrans(float[] xArrSrc, float[] yArrSrc, float[] zArrSrc, out float[] xArrDst, out float[] yArrDst, out float[] zArrDst)
        {
            OnAffineTrans(xArrSrc, yArrSrc, zArrSrc, out xArrDst, out yArrDst, out zArrDst);
        }

        private void OpenSetupPanel(Tool3DBaseModel tool)
        {
            OnOpenSetupPanel(tool);
            _currentTool = tool;
        }

        public void CloseSetupPanel()
        {
            _currentTool?.CloseSetupView();
        }

        private List<Tool3DBaseModel> GetTools()
        {
            return ToolsList;
        }

        private void UpdateCombinedTool(Tool3DBaseModel currTool)
        {
            foreach (Tool3DBaseModel tool in ToolsList)
            {
                if (tool.IsCombined && tool.ContainTool(currTool))
                    tool.UpdateMatrix3D(_Matrix3D, _xAxisParam, _yAxisParam);
            }
        }

        private void DeleteTool(Tool3DBaseModel tool)
        {
            ToolsList.Remove(tool);
            OnRemoveTool?.Invoke(tool);
        }

        private void CopyTool(Tool3DBaseModel tool)
        {
            Tool3DBaseModel copyTool = tool.Copy();
            copyTool.Name = ToolsName[tool.Type] + (ToolsList.Where(x => x.Type == copyTool.Type).Count() + 1);
            InitTool(copyTool);
            copyTool.OpenSetupView();
            copyTool.UpdateMatrix3D(_Matrix3D, _xAxisParam, _yAxisParam);
            OnAddTool?.Invoke(copyTool);
            ToolsList.Add(copyTool);
        }
    }
}
