using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class IssueCreationViewModel : INotifyPropertyChanged
    {
        public SimpleCommand RegisterIssueCmd { get; set; }
        public SimpleCommand cancelCmd { get; set; }
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
        public IssueCreationViewModel()
        {
            issue = new Issue();
            RegisterIssueCmd = new SimpleCommand(RegisterIssue);
            cancelCmd = new SimpleCommand(cancel);
            // projectnames = UsersDbMethods.GetProjectNamesDb();
            projectnames = ProjectsXmlMethods.GetProjectNamesXml();
            // usernames = UsersDbMethods.GetUsernames();
            usernames = UsersXmlMethods.GetUserNamesXml();

        }
        void RegisterIssue()
        {
            if (this.issue == null || string.IsNullOrEmpty(issue.IssueRelatedProject))
            {

            }
            else if (IssuesViewModel.issues.Contains(this.issue))
            {
                MessageBox.Show("this element already exist ");
            }

            else
            {
                // this.issue.IssueId = IssuesDbMethods.RegisterIssue(this.issue);
                this.issue.IssueId = IssuesXmlMethods.increaseid();
                IssuesXmlMethods.AddIssueXml(issue);
                IssuesViewModel.issues.Add(this.issue);
            }
        }
       
        void cancel()
        {
            this.issue = null;
            this.issue = new Issue();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName]string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
