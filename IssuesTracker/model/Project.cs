using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTracker.model
{
    public class Project : INotifyPropertyChanged
    {
        private int _ProjectId;
        public int ProjectId
        {
            get { return _ProjectId; }
            set
            {
                if (_ProjectId != value)
                    _ProjectId = value;
                onpropertychanged();
            }
        }
        private string _ProjectName;
        public string ProjectName
        {
            get { return _ProjectName; }
            set
            {
                if (_ProjectName != value)
                    _ProjectName = value;
                onpropertychanged();
            }
        }
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                    _startDate = value;
                onpropertychanged();
            }
        }
        private DateTime? _TargetEndDate;
        public DateTime? TargetEndDate
        {
            get { return _TargetEndDate; }
            set
            {
                if (_TargetEndDate != value)
                    _TargetEndDate = value;
                onpropertychanged();

            }
        }
        private DateTime? _ActualEndDate;
        public DateTime? ActualEndDate
        {
            get { return _ActualEndDate; }
            set
            {
                if (_ActualEndDate != value)
                    _ActualEndDate = value;
                onpropertychanged();
            }
        }
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                if (_CreatedDate != value)
                    _CreatedDate = value;
                onpropertychanged();
            }
        }
        private string _PersonCreatedName;
        public string PersonCreatedName
        {
            get { return _PersonCreatedName; }
            set
            {
                if (_PersonCreatedName != value)
                    _PersonCreatedName = value;
                onpropertychanged();
            }
        }
        private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate
        {
            get { return _ModifiedDate; }
            set
            {
                if (_ModifiedDate != value)
                    _ModifiedDate = value;
                onpropertychanged();
            }
        }
        private string _ModifiedPersonName;
        public string ModifiedPersonName
        {
            get { return _ModifiedPersonName; }
            set
            {
                if (_ModifiedPersonName != value)
                    _ModifiedPersonName = value;
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
            if (!(obj is Project))
            {
                return false;
            }
            return this.ProjectName == ((Project)obj).ProjectName;
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
