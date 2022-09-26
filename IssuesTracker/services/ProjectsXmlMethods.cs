using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using IssuesTracker.model;

namespace IssuesTracker.services
{
    public class ProjectsXmlMethods
    {
        static string root = "C:\\Users\\WORD\\Documents";
        static string path = $"{root}\\Projects\\Projects.xml";
        static string idpath = $"{root}\\Projects\\ids.xml";
        public static void CreatePojectDir()
        {
            if (!Directory.Exists($"{root}\\Projects"))
            {
                Directory.CreateDirectory($"{root}\\Projects");
            }
            else { };
        }
        public static void CreateDirectory(string directoryname)
        {
            if (Directory.Exists($"{root}\\Projects\\{directoryname}")) { }
            else
            {
                Directory.CreateDirectory($"{root}\\Projects\\{directoryname}");
            }
        }
        public static void createProjectFile()
        {
          // string projectname1 = project.ProjectName.Replace(' ', '_');

            try
            {
                string path = $"{root}\\Projects\\Projects.xml";

                if (!File.Exists(path))
                {
                    XElement doc = new XElement("Projects");
                    doc.Save(path);
                }
                else { };

                if (!File.Exists(idpath))
                {
                    XElement doc = new XElement("id",new XAttribute("value","0"));
                    doc.Save(idpath);
                }
                else { };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public static void AddprojectXml(Project project)
        {
            string path = $"{root}\\Projects\\Projects.xml";
            XElement doc = XElement.Load(path);
            XElement elmt = new XElement("Project", new XAttribute("Name", project.ProjectName ?? string.Empty),
                   new XAttribute("Id", project.ProjectId.ToString() ?? string.Empty), new XAttribute("StartDate", project.StartDate.GetValueOrDefault().ToShortDateString()),
                   new XAttribute("TargetEndDate", project.TargetEndDate.GetValueOrDefault().ToShortDateString()), new XAttribute("ActualEndDate", project.ActualEndDate.GetValueOrDefault().ToShortDateString()),
                   new XAttribute("CreatedDate", project.CreatedDate.GetValueOrDefault().ToShortDateString()));
            doc.Add(elmt);
            doc.Save(path);
        }
        public static void DeleteProjectXml(int id)
        {
            XElement doc = XElement.Load(path);
            XElement elmt= doc.Elements("Project").Where(c => c.Attribute("Id").Value == id.ToString()).FirstOrDefault();
            elmt.Remove();
            doc.Save(path);

        }
        public static void ModifyProjectXml(Project project)
        {
            XElement doc = XElement.Load(path);
            XElement elmt = doc.Descendants("Project").Where(c => c.Attribute("Id").Value == project.ProjectId.ToString()).FirstOrDefault();
            elmt.Attribute("Name").Value = project.ProjectName;
            elmt.Attribute("StartDate").Value = project.StartDate.ToString();
            elmt.Attribute("TargetEndDate").Value = project.TargetEndDate.ToString();
            elmt.Attribute("ActualEndDate").Value = project.ActualEndDate.ToString();
            elmt.Attribute("CreatedDate").Value = project.CreatedDate.ToString();
            doc.Save(path);
        }
        public static ObservableCollection<Project> GetProjectXml()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>();
            XElement doc = XElement.Load(path);
            IEnumerable<XElement> xElements = doc.Descendants();
            foreach(XElement elnt in xElements)
            {
                Project project = new Project()
                {
                    ActualEndDate = DateTime.Parse(elnt.Attribute("ActualEndDate").Value),
                    CreatedDate = Convert.ToDateTime(elnt.Attribute("CreatedDate").Value),
                    StartDate = Convert.ToDateTime(elnt.Attribute("StartDate").Value),
                    TargetEndDate = Convert.ToDateTime(elnt.Attribute("TargetEndDate").Value),
                    ProjectName = elnt.Attribute("Name").Value,
                    ProjectId = Int32.Parse(elnt.Attribute("Id").Value)
                };
                projects.Add(project);
            }
            return projects;
        }
        public static Project GetProjectByIdXml(int id)
        {
            XElement doc = XElement.Load(path);
            XElement elemt = doc.Descendants("Project").Where(c => c.Attribute("Id").Value == id.ToString()).FirstOrDefault();
            Project project = new Project()
            {
                ProjectName = elemt.Attribute("Name").Value,
                StartDate = Convert.ToDateTime(elemt.Attribute("StartDate").Value),
                TargetEndDate = Convert.ToDateTime(elemt.Attribute("TargetEndDate").Value),
                ActualEndDate = Convert.ToDateTime(elemt.Attribute("ActualEndDate").Value),
                CreatedDate = Convert.ToDateTime(elemt.Attribute("CreatedDate").Value),
                 ProjectId=Int32.Parse(elemt.Attribute("Id").Value)
            };
           return project;
        }
        public static int increaseid()
        {
            XElement doc = XElement.Load(idpath);
            int val = Int32.Parse(doc.Attribute("value").Value);
            val++;
            doc.Attribute("value").Value = val.ToString();
            doc.Save(idpath);
            return val;
        }
        public static ObservableCollection<string>GetProjectNamesXml()
        {
            ObservableCollection<string> projectnames = new ObservableCollection<string>();
            XElement doc = XElement.Load(path);
            var xelements = doc.Descendants();
            foreach(XElement elnt in xelements)
            {
                string projectname = elnt.Attribute("Name").Value;
                projectnames.Add(projectname);
            }
            return projectnames;
        }


    }
}
