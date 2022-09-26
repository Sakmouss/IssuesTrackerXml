using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IssuesTracker.model;
using IssuesTracker.services;

namespace IssuesTracker.viewmodel
{
    public class ProjectsViewModel : INotifyPropertyChanged
    {

        public SimpleCommand AddprojectCmd { get; set; }
        public SimpleCommand UpdateProjectCollectionCmd { get; set; }
        public SimpleCommand SearchProductCmd { get; set; }
        public ParamCommand GetProjectDetailsCmd { get; set; }

        public static ObservableCollection<Project> projects { get; set; }
        public static string ProjectNumber { get; set; }



        public ProjectsViewModel()
        {
            AddprojectCmd = new SimpleCommand(addproject);

            GetProjectDetailsCmd = new ParamCommand(GetProjectDetails, CanGetProjectDetails);

            // projects = ProjectDbMethods.GetProjectsDb();
            projects = ProjectsXmlMethods.GetProjectXml();
            ProjectNumber = projects.Count.ToString();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        void addproject()
        {

            AddProjectViewModel vm = new AddProjectViewModel();
            Presenter.show(vm);
        }
        void GetProjectDetails(Object parameter)
        {

            int Projectid = (int)parameter;
            ModifyProjectViewModel vm = new ModifyProjectViewModel();
            //  vm.project = ProjectDbMethods.getProjectbyId(Projectid);
            vm.project = ProjectsXmlMethods.GetProjectByIdXml(Projectid);
            Presenter.show(vm);
        }
        bool CanGetProjectDetails(Object parameter)
        {
            return true;
        }
        void UpdateProjectsCollection()
        {
            projects = new ObservableCollection<Project>(ProjectDbMethods.GetProjectsDb());

        }

    }
}
