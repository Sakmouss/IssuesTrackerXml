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
    public class ModifyUserViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> projectnames { get; set; }
        public List<string> UserRoles { get; set; }
        public SimpleCommand RegisterUserCmd { get; set; }
        public SimpleCommand DeleteUserCmd { get; set; }
        public SimpleCommand UpdateUserCmd { get; set; }
        private User _user;
        public User user
        {
            get { return _user; }
            set
            {
                if (_user != value)
                    _user = value;
                onpropertychanged();
            }
        }


        public ModifyUserViewModel()
        {
            user = new User();
            //  projectnames = UsersDbMethods.GetProjectNamesDb();
            projectnames = ProjectsXmlMethods.GetProjectNamesXml();
            UserRoles = new List<string>() { "CEO", "MANAGER", "LEAD", "MEMBER" };
            DeleteUserCmd = new SimpleCommand(DeleteUser);
            UpdateUserCmd = new SimpleCommand(UpdateUser);
        }
        void DeleteUser()
        {


            if (user == null || user.UserId == 0)
            {
                MessageBox.Show("this element is not in the database yet,try to delete" +
                  " an element already stored in the database ");

            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sur you want to delete {user.Name}", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                       // UsersDbMethods.DeleteUserById(user.UserId);
                       
                        UsersXmlMethods.DeleteUserXml(user);
                        UsersViewModel.users.Remove(user);
                     
                        this.user = null;
                        this.user = new User();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        void UpdateUser()
        {
            if (this.user != null && this.user.UserId!=0)
            {
                //UsersDbMethods.UpdateUserDb(user);
                UsersXmlMethods.ModifyUserXml(user);
                UpdateUserCollection(user);
               
            }
            else { MessageBox.Show("this user is not registered in the database "); }
        }
        void UpdateUserCollection(User user)
        {
            int index = UsersViewModel.users.IndexOf(user);
            UsersViewModel.users[index].AssignedProjectName = user.AssignedProjectName;
            UsersViewModel.users[index].Name = user.Name;
            UsersViewModel.users[index].PersonPhoto = user.PersonPhoto;
            UsersViewModel.users[index].RegisteredDate = user.RegisteredDate;
            UsersViewModel.users[index].RegisteredPersonName = user.RegisteredPersonName;
            UsersViewModel.users[index].UserEmail = user.UserEmail;
            UsersViewModel.users[index].UserName = user.UserName;
            UsersViewModel.users[index].UserRole = user.UserRole;
        }
        string GetUserProjectName(string strProjectName)
        {
            string[] names = strProjectName.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < names.Length; i++)
            {
                sb.Append(names[i]);
                sb.Append(" ");
            }

            return sb.ToString();
        }
        void CancelUser()
        {
            this.user = null;
            this.user = new User();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
