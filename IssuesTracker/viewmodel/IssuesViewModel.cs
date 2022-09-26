using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssuesTracker.model;
using IssuesTracker.services;

namespace IssuesTracker.viewmodel
{
    public class IssuesViewModel
    {
        public static ObservableCollection<Issue> issues { get; set; }
        public SimpleCommand AddIssueCmd { get; set; }
        public ParamCommand GetIssueDetailCmd { get; set; }
        public static string IssueNumber { get; set; }
        public IssuesViewModel()
        {
            //issues = IssuesDbMethods.GetIssuesDb();
            issues = IssuesXmlMethods.GetIssuesXml();
            AddIssueCmd = new SimpleCommand(AddIssue);
            GetIssueDetailCmd = new ParamCommand(GetIssueDetails, canGetIssueDetails);
            IssueNumber = issues.Count.ToString();
        }
        bool canGetIssueDetails(Object parameter)
        {
            return true;
        }
        void GetIssueDetails(Object parameter)
        {
            int issueid = (int)parameter;
            ModifyIssueViewModel vm = new ModifyIssueViewModel();
            vm.issue = IssuesXmlMethods.GetIssueByIdXml(issueid);
         //  vm.issue = IssuesDbMethods.GetIssueById(issueid);
           Presenter.show(vm);
        }

        void AddIssue()
        {
            IssueCreationViewModel vm = new IssueCreationViewModel();
            Presenter.show(vm);
        }
    }
}
