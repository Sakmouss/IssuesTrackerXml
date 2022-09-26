using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IssuesTracker.model;
using IssuesTracker.services;

namespace IssuesTracker.viewmodel
{
    public class ModifyProjectViewModel : INotifyPropertyChanged
    {
        string DeletProjecrMsg = "Choosing to continue this action will delete the project" +
           " and any element related to. " +
           "are you sure you want to continue?";
        public SimpleCommand DeleteProjectCmd { get; set; }
        public SimpleCommand UpdateProjectCmd { get; set; }
        private Project _project;
        public Project project
        {
            get { return _project; }
            set
            {
                if (_project != value)
                    _project = value;
                onpropertychanged();
            }
        }

        public ModifyProjectViewModel()
        {
            project = new Project();
            DeleteProjectCmd = new SimpleCommand(DeleteProject);
            UpdateProjectCmd = new SimpleCommand(UpdateProject);

        }

        void UpdateProject()
        {
            if (project == null || project.ProjectId==0)
            {

            }
            else if (!string.IsNullOrEmpty(project.ProjectName))
            {
                // ProjectDbMethods.UpdateProjectDb(project);
                ProjectsXmlMethods.ModifyProjectXml(project);
                UpdateProjectCollection(project);
                
            }
            else { }

        }
        void UpdateProjectCollection(Project NewProject)
        {
            int index = ProjectsViewModel.projects.IndexOf(project);
            ProjectsViewModel.projects[index].ProjectName = project.ProjectName;
            ProjectsViewModel.projects[index].PersonCreatedName = project.PersonCreatedName;
            ProjectsViewModel.projects[index].ModifiedDate = project.ModifiedDate;
            ProjectsViewModel.projects[index].ModifiedPersonName = project.ModifiedPersonName;
            ProjectsViewModel.projects[index].StartDate = project.StartDate;
            ProjectsViewModel.projects[index].TargetEndDate = project.TargetEndDate;
            ProjectsViewModel.projects[index].ActualEndDate = project.ActualEndDate;
            ProjectsViewModel.projects[index].CreatedDate = project.CreatedDate;
        }


        void DeleteProject()
        {
            if (project == null || project.ProjectId == 0)
            {
                MessageBox.Show("this element is not in the database yet,try to delete" +
                  " an element already stored in the database ");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(DeletProjecrMsg, "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                       // UsersDbMethods.DeleteProjectName(project.ProjectName);
                        // IssuesDbMethods.DeleteIssueByProject(project.ProjectId);
                        // ProjectDbMethods.DeleteProjectById(project.ProjectId);
                        ProjectsXmlMethods.DeleteProjectXml(project.ProjectId);
                        ProjectsViewModel.projects.Remove(project);
                        IssuesXmlMethods.DeleteIssueByProject(project.ProjectName);
                        
                       
                        //  CancelProject();
                        this.project = null;
                        break;
                    case MessageBoxResult.No:
                        break;
                }



            }
        }
        void CancelProject()
        {
            project.ProjectName = "";
            project.StartDate = DateTime.Now;
            project.TargetEndDate = DateTime.Now;
            project.PersonCreatedName = "";
            project.ModifiedPersonName = "";
            project.ModifiedDate = DateTime.Now;
            project.CreatedDate = DateTime.Now;
            project.ActualEndDate = DateTime.Now;
            project.ProjectId = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName]string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
