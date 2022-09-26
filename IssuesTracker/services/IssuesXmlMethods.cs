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
  public  class IssuesXmlMethods
    {
        static string root = "C:\\Users\\WORD\\Documents";
        static string path = $"{root}\\Issues\\Issues.xml";
        static string idpath = $"{root}\\Issues\\ids.xml";
        public static void CreateIssueDir()
        {
            if (!Directory.Exists($"{root}\\Issues"))
            {
                Directory.CreateDirectory($"{root}\\Issues"); 
            
}
            else { };
        }
        public static void createIssueFile()
        {
           

            try
            {
                string path = $"{root}\\Issues\\Issues.xml";

                if (!File.Exists(path))
                {
                    XElement doc = new XElement("Issues");
                    doc.Save(path);
                }
                else { };
                if (!File.Exists(idpath))
                {
                    XElement doc = new XElement("id", new XAttribute("value", "0"));
                    doc.Save(idpath);
                }
                else { };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        public static void AddIssueXml( Issue issue)
        {
            string path = $"{root}\\Issues\\Issues.xml";
            XElement doc = XElement.Load(path);
            XElement elmt = new XElement("Issue", new XAttribute("Id",issue.IssueId), 
                   new XAttribute("IdentifiedDate", issue.IssueIdentifiedDate.GetValueOrDefault().ToShortDateString()),
                   new XAttribute("AssignedPerson", issue.AssignedPersonName ?? string.Empty),
                   new XAttribute("TargetResolutionDate",issue.ResolutionTargetDate.GetValueOrDefault().ToShortDateString()),
                   new XAttribute("ActualResolutionDate",issue.ActualResolutionDate.GetValueOrDefault().ToShortDateString()),
                   new XAttribute("RelatedProject",issue.IssueRelatedProject ?? string.Empty),
                   new XElement("IssuesUmup",issue.IssueSumup ?? string.Empty),
                   new XElement("IssueDescription",issue.IssueDescription ?? string.Empty),
                   new XElement("Progress",issue.issueProgression ?? string.Empty),
                   new XElement("ResolutionSumup",issue.ResolutionSumup ?? string.Empty));
            doc.Add(elmt);
            doc.Save(path);
        }

        public static void DeleteIssueXml(Issue issue)
        {
            XElement doc = XElement.Load(path);
            XElement elmt = doc.Descendants("Issue").Where(c => c.Attribute("Id").Value == issue.IssueId.ToString()).FirstOrDefault();
            elmt.Remove();
            doc.Save(path);

        }

        public static void ModifyIssueXml(Issue issue)
        {
            XElement doc = XElement.Load(path);
            XElement elmt = doc.Descendants("Issue").Where(c => c.Attribute("Id").Value == issue.IssueId.ToString()).FirstOrDefault();
            elmt.Attribute("IdentifiedDate").Value = issue.IssueIdentifiedDate.ToString();
            elmt.Attribute("AssignedPerson").Value = issue.AssignedPersonName;
            elmt.Attribute("TargetResolutionDate").Value = issue.ResolutionTargetDate.ToString();
            elmt.Attribute("ActualResolutionDate").Value = issue.ActualResolutionDate.ToString();
            elmt.Element("IssuesUmup").Value = issue.IssueSumup;
            elmt.Element("IssueDescription").Value = issue.IssueDescription;
            elmt.Element("Progress").Value = issue.issueProgression;
            elmt.Element("ResolutionSumup").Value = issue.ResolutionSumup;
            doc.Save(path);
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
        public static ObservableCollection<Issue>GetIssuesXml()
        {
            ObservableCollection<Issue> issues = new ObservableCollection<Issue>();
            
            
                XElement doc = XElement.Load(path);
                var xelements = doc.Elements();
                foreach (XElement elmt in xelements)
                {
                    Issue issue = new Issue()
                    {
                        ActualResolutionDate = Convert.ToDateTime(elmt.Attribute("ActualResolutionDate").Value),
                        IssueId = Int32.Parse(elmt.Attribute("Id").Value),
                        IssueIdentifiedDate = Convert.ToDateTime(elmt.Attribute("IdentifiedDate").Value),
                        IssueRelatedProject = elmt.Attribute("RelatedProject").Value,
                        AssignedPersonName = elmt.Attribute("AssignedPerson").Value,
                        ResolutionTargetDate = Convert.ToDateTime(elmt.Attribute("TargetResolutionDate").Value),
                        IssueDescription = elmt.Element("IssueDescription").Value,
                        issueProgression = elmt.Element("IssueDescription").Value,
                        IssueSumup = elmt.Element("IssuesUmup").Value,
                        ResolutionSumup = elmt.Element("ResolutionSumup").Value
                    };
                    issues.Add(issue);
                }
            
            return issues;

        }
        public static Issue GetIssueByIdXml(int id)
        {
            XElement doc = XElement.Load(path);
            XElement elmt = doc.Elements().Where(c => c.Attribute("Id").Value == id.ToString()).FirstOrDefault();
            Issue issue = new Issue()
            {
                ActualResolutionDate = Convert.ToDateTime(elmt.Attribute("ActualResolutionDate").Value),
                IssueId = Int32.Parse(elmt.Attribute("Id").Value),
                IssueIdentifiedDate = Convert.ToDateTime(elmt.Attribute("IdentifiedDate").Value),
                IssueRelatedProject = elmt.Attribute("RelatedProject").Value,
                AssignedPersonName = elmt.Attribute("AssignedPerson").Value,
                ResolutionTargetDate = Convert.ToDateTime(elmt.Attribute("TargetResolutionDate").Value),
                IssueDescription = elmt.Element("IssueDescription").Value,
                issueProgression = elmt.Element("Progress").Value,
                IssueSumup = elmt.Element("IssuesUmup").Value,
                ResolutionSumup = elmt.Element("ResolutionSumup").Value
            };
            return issue;

        }
      public  static void DeleteIssueByProject(string ProjectName)
        {
            XElement doc = XElement.Load(path);
            var elements= doc.Elements().Where(c => c.Attribute("RelatedProject").Value == ProjectName);
            elements.Remove();
            doc.Save(path);
        }
    }
}
