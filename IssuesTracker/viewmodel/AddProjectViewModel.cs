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
    public class AddProjectViewModel : INotifyPropertyChanged
    {
        //  string DeletProjecrMsg = "Choosing to continue this action will delete the project" +
        //     " and every element related to" +
        //     "are you sure you want to continue?";
        public SimpleCommand RegisterProjectCmd { get; set; }

        public SimpleCommand CancelProjectCmd { get; set; }

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
        public AddProjectViewModel()
        {
            project = new Project();
            RegisterProjectCmd = new SimpleCommand(RegisterProject);

            CancelProjectCmd = new SimpleCommand(CancelProject);

        }
        void RegisterProject()
        {
            if (project == null || string.IsNullOrEmpty(project.ProjectName))
            {
                MessageBox.Show("choose an appropriate project name for that project");
            }

            else if (ProjectsViewModel.projects.Contains(project))
            { MessageBox.Show("A projet of this name already exist choose another name"); }

            else
            {
                Project _project = new Project()
                {
                    ProjectName = project.ProjectName,
                    ActualEndDate = project.ActualEndDate,
                    ModifiedDate = project.ModifiedDate,
                    ModifiedPersonName = project.ModifiedPersonName,
                    CreatedDate = project.CreatedDate,

                    PersonCreatedName = project.PersonCreatedName,
                    StartDate = project.StartDate,
                    TargetEndDate = project.TargetEndDate,
                    ProjectId = ProjectsXmlMethods.increaseid()
                    
                };
              //  int ProjectId = ProjectDbMethods.RegisterProjectDb(_project);
              //  _project.ProjectId = ProjectId;

                ProjectsViewModel.projects.Add(_project);
                ProjectsViewModel.ProjectNumber = ProjectDbMethods.GetProjectNumberDb().ToString();
               // ProjectsXmlMethods.CreateDirectory(_project.ProjectName);
               
                ProjectsXmlMethods.AddprojectXml(_project);
            }

        }


        void CancelProject()
        {

            this.project = null;
            this.project = new Project();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }

}
