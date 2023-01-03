using System;
using System.IO;
using System.Xml.Serialization;
using Serilizer;
using JSystem.Perform;

namespace JSystem.Project
{
    public class ProjectManager
    {
        private readonly string _prosFile = "Pros.xml";

        [XmlIgnore]
        public Action<string> OnSavePointCloud;

        [XmlIgnore]
        public Action<string> OnLoadPointCloud;

        [XmlIgnore]
        public Action OnScanOnce;

        [XmlIgnore]
        public Func<string, bool> OnSaveProject;

        [XmlIgnore]
        public Func<string, bool> OnLoadProject;

        [XmlIgnore]
        public Action<string> OnSetUserRight;

        public Projects Projects;

        public string ProjectPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "Project\\" + Projects.CurrProject + ".xml";
            }
        }

        public ProjectManager()
        {
            Projects = new Projects();
            if (!File.Exists(_prosFile))
                return;
            Projects = XMLSerializer.Deserialize<Projects>(_prosFile);
            LoadProject(Projects.CurrProject);
        }

        ~ProjectManager()
        {
            XMLSerializer.Serialize(Projects, _prosFile);
        }

        public void SetUserRight(string right)
        {
            OnSetUserRight?.Invoke(right);
        }

        public bool SaveProject(string projectName)
        {
            if (!Projects.ProjectsName.Contains(projectName))
                Projects.ProjectsName.Add(projectName);
            string fileDir = AppDomain.CurrentDomain.BaseDirectory + "Project\\";
            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);
            Projects.CurrProject = projectName;
            if (!OnSaveProject(ProjectPath))
            {
                LogManager.Instance.AddLog($"产品{projectName}参数失败");
                return false;
            }
            XMLSerializer.Serialize(Projects, _prosFile);
            LogManager.Instance.AddLog($"产品{projectName}参数已保存");
            return true;
        }

        public void LoadProject(string projectName)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Project\\" + projectName + ".xml";
            if (!File.Exists(filePath))
                return;
            Projects.CurrProject = projectName;
            OnLoadProject?.Invoke(filePath);
            XMLSerializer.Serialize(Projects, _prosFile);
            LogManager.Instance.AddLog($"当前产品切换为{projectName}");
        }

        public void DeleteProject(string projectName)
        {
            Projects.ProjectsName.Remove(Projects.CurrProject);
            Projects.CurrProject = "";
            string fileDir = AppDomain.CurrentDomain.BaseDirectory + "Project\\";
            File.Delete(fileDir + projectName + ".xml");
        }
    }
}
