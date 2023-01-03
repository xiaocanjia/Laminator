using System;
using System.IO;
using System.Xml.Serialization;
using BSLib;
using Vision3D;
using MeasResult;

namespace Meas3D
{
    public class Meas3DManager
    {
        [XmlIgnore]
        public Win3DManager Win3DMgr = new Win3DManager();

        public Calib.Calib3DManager CalibMgr;

        public FixPos.FixPos3DManager FixPosMgr;

        public Tool.Tools3DManager ToolMgr;

        public bool IsSaveImage = false;

        public bool IsSaveFailOnly = false;

        public bool IsSaveData = false;

        public string ImageDir = $"{AppDomain.CurrentDomain.BaseDirectory}Image";

        public string DataDir = $"{AppDomain.CurrentDomain.BaseDirectory}Data";

        [XmlIgnore]
        public Func<bool> OnStartGrab;

        [XmlIgnore]
        public Action OnEndScan;

        [XmlIgnore]
        public Func<string> OnGetStationName;

        [XmlIgnore]
        public Action<string> OnSetUserRight;

        [XmlIgnore]
        public Meas3DPage Page;

        public string CurrDecision;

        public string Name;

        public Meas3DManager()
        {
            CalibMgr = new Calib.Calib3DManager();
            ToolMgr = new Tool.Tools3DManager();
            FixPosMgr = new FixPos.FixPos3DManager();
            Page = new Meas3DPage(this);
        }

        public Meas3DManager(string name) : this()
        {
            Name = name;
        }

        public void RegisterEvents()
        {
            FixPosMgr.OnUpdateTools = ToolMgr.UpdateMatrix3D;
            FixPosMgr.OnUpdateVision = Win3DMgr.UpdateMatrix;
            FixPosMgr.OnRepaint = Win3DMgr.Repaint;
            FixPosMgr.OnAddShape = Win3DMgr.AddShape;
            FixPosMgr.OnRemoveShape = Win3DMgr.RemoveShape;
            ToolMgr.OnAddShape = Win3DMgr.AddShape;
            ToolMgr.OnRemoveShape = Win3DMgr.RemoveShape;
            ToolMgr.OnRepaint = Win3DMgr.Repaint;
            CalibMgr.OnAddShape = Win3DMgr.AddShape;
            CalibMgr.OnRemoveShape = Win3DMgr.RemoveShape;
            CalibMgr.OnRepaint = Win3DMgr.Repaint;
            ToolMgr.OnAffineTrans = CalibMgr.AffineTrans;
            CalibMgr.OnUpdateTools = ToolMgr.UpdateTools;
        }

        public void UpdateResult(JMatrix3D matrix3D, string sn = "")
        {
            try
            {
                CalibMgr.UpdateMatrix3D(matrix3D);
                FixPosMgr.UpdateMatrix3D(matrix3D);
                SaveMatrix(sn, matrix3D);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadMatrix3D(string filePath)
        {
            try
            {
                JMatrix3D matrix3D = new JMatrix3D(filePath);
                CalibMgr.UpdateMatrix3D(matrix3D);
                FixPosMgr.UpdateMatrix3D(matrix3D);
                ResultsLogger.SaveResult(DataDir, "", ToolMgr.GetResults());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveMatrix(string sn, JMatrix3D matrix3D)
        {
            if (!IsSaveImage || matrix3D == null)
                return;
            var retList = ToolMgr.GetResults();
            ResultsLogger.SaveResult(DataDir, sn, retList);
            var retFail = retList.FindAll((a) => a.Decision == Decision.FAIL);
            string decision = retFail == null ? "PASS" : "FAIL";
            if ((IsSaveFailOnly && decision == "PASS"))
                return;
            try
            {
                string imageDir = ImageDir;
                if (!Directory.Exists(imageDir))
                    Directory.CreateDirectory(imageDir);
                imageDir += $"\\{DateTime.Now.ToString("yyyy-MM-dd")}";
                if (!Directory.Exists(imageDir))
                    Directory.CreateDirectory(imageDir);
                imageDir += $"\\{Name}";
                if (!Directory.Exists(imageDir))
                    Directory.CreateDirectory(imageDir);
                imageDir += $"\\{decision}";
                if (!Directory.Exists(imageDir))
                    Directory.CreateDirectory(imageDir);
                string filePath = $"{imageDir}\\{sn}`{DateTime.Now.ToString("HH-mm-ss")}.tif";
                matrix3D.SaveTo(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
