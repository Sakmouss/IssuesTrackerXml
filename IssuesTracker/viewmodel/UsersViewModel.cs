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
    public class UsersViewModel
    {
        public static ObservableCollection<User> users { get; set; }
        public SimpleCommand AddUserCmd { get; set; }
        public ParamCommand GetUserdetailsCmd { get; set; }
        public static string userNumber { get; set; }
        public UsersViewModel()
        {
            // users = UsersDbMethods.GetDbUsersDb();
            users = UsersXmlMethods.GetUsersXml();
            AddUserCmd = new SimpleCommand(AddUser);
            GetUserdetailsCmd = new ParamCommand(GetUserdetails, CanGetUserdetails);
            userNumber = users.Count.ToString();
        }
        void AddUser()
        {
            AddUserViewModel vm = new AddUserViewModel();
            Presenter.show(vm);
        }
        void GetUserdetails(Object parameter)
        {

            int Userid = (int)parameter;
            ModifyUserViewModel vm = new ModifyUserViewModel();
            // vm.user = UsersDbMethods.GetUserbyId(Userid);
            vm.user = UsersXmlMethods.GetUserByIdXml(Userid);
            Presenter.show(vm);
        }
        bool CanGetUserdetails(Object parameter)
        {
            return true;
        }
    }
}
