using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IssuesTracker.model;
using IssuesTracker.services;
using IssuesTracker.views;
using System.Windows.Controls;
using System.Windows.Media;



namespace IssuesTracker.viewmodel
{
    class ModifyIssueViewModel : INotifyPropertyChanged
    {
        public List<string> issuePriority { get; set; }
        public List<string> issueStatus { get; set; }
        string root = "C:\\Users\\WORD\\Documents";
        public SimpleCommand UpdateIssueCmd { get; set; }
        public SimpleCommand DeleteIssueCmd { get; set; }
        public SimpleCommand CreateDocCmd { get; set; }
        public ObservableCollection<string> projectnames { get; set; }
        public ObservableCollection<string> usernames { get; set; }

        private Issue _issue;
        public Issue issue
        {
            get { return _issue; }
            set
            {
                if (_issue != value)
                    _issue = value;
                onpropertychanged();

            }
        }
        public ModifyIssueViewModel()
        {
            issue = new Issue();
            UpdateIssueCmd = new SimpleCommand(UpdateIssue);
            DeleteIssueCmd = new SimpleCommand(DeleteIssue);
            CreateDocCmd = new SimpleCommand(createflowdoc);
            // projectnames = UsersDbMethods.GetProjectNamesDb();
            // usernames = UsersDbMethods.GetUsernames();
            projectnames = ProjectsXmlMethods.GetProjectNamesXml();
            usernames = UsersXmlMethods.GetUserNamesXml();
            issuePriority = new List<string>() { "HIGH", "MEDIUM", "LOW" };
            issueStatus = new List<string>() { "OPEN", "HOLG-ON", "CLOSED" };
        }
        void DeleteIssue()
        {
            if (issue == null) { }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this element?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        //IssuesDbMethods.DeleteIssueById(issue.IssueId);
                        IssuesXmlMethods.DeleteIssueXml(issue);
                        IssuesViewModel.issues.Remove(issue);
                        issue = null;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        void UpdateIssue()
        {
            if (this.issue != null)
            {
                // IssuesDbMethods.UpdateIssueDb(this.issue);
                IssuesXmlMethods.ModifyIssueXml(issue);
                UpdateIssuesCollection();
            }
            else { }
        }
        void UpdateIssuesCollection()
        {
            int index = IssuesViewModel.issues.IndexOf(issue);
            IssuesViewModel.issues[index].ActualResolutionDate = issue.ActualResolutionDate;
            IssuesViewModel.issues[index].AssignedPersonName = issue.AssignedPersonName;
            IssuesViewModel.issues[index].IssueDescription = issue.IssueDescription;
            IssuesViewModel.issues[index].IssueId = issue.IssueId;
            IssuesViewModel.issues[index].IssueIdentifiedDate = issue.IssueIdentifiedDate;
            IssuesViewModel.issues[index].IssueRelatedProject = issue.IssueRelatedProject;
            IssuesViewModel.issues[index].IssueRelatedProjectId = issue.IssueRelatedProjectId;
            IssuesViewModel.issues[index].IssueSumup = issue.IssueSumup;
            IssuesViewModel.issues[index].ResolutionSumup = issue.ResolutionSumup;
            IssuesViewModel.issues[index].ResolutionTargetDate = issue.ResolutionTargetDate;
        }
        void CreateDoc()
        {

            IssueDocViewModel vm = new IssueDocViewModel();
            if (this.issue == null) { }
            else
            {
                vm.issue.AssignedPersonName = this.issue.AssignedPersonName;
                 vm.issue.IssueDescription = this.issue.IssueDescription;
                vm.issue.IssueRelatedProject = this.issue.IssueRelatedProject;
                vm.issue.IssueSumup = this.issue.IssueSumup;
                vm.issue.ResolutionTargetDate = this.issue.ResolutionTargetDate;
                Presenter.show(vm);
            }
        }
      string getprojectname(string formername)
        {
            string[] names = formername.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < names.Length; i++)
            {
                sb.Append(names[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }
        void createflowdoc()
        {
            if (this.issue != null && this.issue.IssueId != 0)
            {
                issuedocumentView docview = new issuedocumentView();
                docview.issue = this.issue;

                docview.Show();
            }
            else { }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName]string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
