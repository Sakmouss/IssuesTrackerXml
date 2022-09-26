using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTracker.model
{
    public class User : INotifyPropertyChanged
    {
        private int _UserId;
        public int UserId
        {
            get { return _UserId; }
            set
            {
                if (_UserId != value)
                    _UserId = value;
                onpropertychanged();
            }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                    _UserName = value;
                onpropertychanged();
            }
        }
        private string _UserEmail;
        public string UserEmail
        {
            get { return _UserEmail; }
            set
            {
                if (_UserEmail != value)
                    _UserEmail = value;
                onpropertychanged();
            }
        }
        private string _UserRole;
        public string UserRole
        {
            get { return _UserRole; }
            set
            {
                if (_UserRole != value)
                    _UserRole = value;
                onpropertychanged();
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                    _Name = value;
                onpropertychanged();
            }
        }

        private DateTime? _RegisteredDate;
        public DateTime? RegisteredDate
        {
            get { return _RegisteredDate; }
            set
            {
                if (_RegisteredDate != value)
                    _RegisteredDate = value;
                onpropertychanged();
            }
        }
        private string _RegisteredPersonName;
        public string RegisteredPersonName
        {
            get { return _RegisteredPersonName; }
            set
            {
                if (_RegisteredPersonName != value)
                    _RegisteredPersonName = value;
                onpropertychanged();
            }
        }


        private Byte[] _PersonPhoto;
        public Byte[] PersonPhoto
        {
            get { return _PersonPhoto; }
            set
            {
                if (_PersonPhoto != value)
                    _PersonPhoto = value;
                onpropertychanged();
            }
        }
        private string _AssignedProjectName;
        public string AssignedProjectName
        {
            get { return _AssignedProjectName; }
            set
            {
                if (_AssignedProjectName != value)
                    _AssignedProjectName = value;
                onpropertychanged();

            }
        }


        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is User))
            {
                return false;
            }
            return this.Name == ((User)obj).Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }




        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName]string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
