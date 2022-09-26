
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTracker.model
{
    public class Issue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void onpropertychanged([CallerMemberName]string propertyname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        private int _IssueId;
        public int IssueId
        {
            get { return _IssueId; }
            set
            {
                if (_IssueId != value)
                    _IssueId = value;
                onpropertychanged();
            }
        }
        private string _IssueSumup;
        public string IssueSumup
        {
            get { return _IssueSumup; }
            set
            {
                if (_IssueSumup != value)
                    _IssueSumup = value;
                onpropertychanged();
            }
        }
        private string _IssueDescription;
        public string IssueDescription
        {
            get { return _IssueDescription; }
            set
            {
                if (_IssueDescription != value)
                    _IssueDescription = value;
                onpropertychanged();
            }
        }

        private DateTime? _IssueIdentifiedDate;
        public DateTime? IssueIdentifiedDate
        {
            get { return _IssueIdentifiedDate; }
            set
            {
                if (_IssueIdentifiedDate != value)
                    _IssueIdentifiedDate = value;
                onpropertychanged();
            }
        }
        private int _IssueRelatedProjectId;

        public int IssueRelatedProjectId
        {
            get { return _IssueRelatedProjectId; }
            set
            {
                if (_IssueRelatedProjectId != value)
                    _IssueRelatedProjectId = value;
                onpropertychanged();
            }
        }
        private string _IssueRelatedProject;
        public string IssueRelatedProject
        {
            get { return _IssueRelatedProject; }
            set
            {
                if (_IssueRelatedProject != value)
                    _IssueRelatedProject = value;
                onpropertychanged();
            }
        }
        private string _AssignedPersonName;
        public string AssignedPersonName
        {
            get { return _AssignedPersonName; }
            set
            {
                if (_AssignedPersonName != value)
                    _AssignedPersonName = value;
                onpropertychanged();
            }
        }
        private string _issueProgression;
        public string issueProgression
        {
            get { return _issueProgression; }
            set
            {
                if(_issueProgression!=value)
                {
                    _issueProgression = value;
                }
                onpropertychanged();
            }
        }

       
       
        
        private DateTime? _ResolutionTargetDate;
        public DateTime? ResolutionTargetDate
        {
            get { return _ResolutionTargetDate; }
            set
            {
                if (_ResolutionTargetDate != value)
                    _ResolutionTargetDate = value;
                onpropertychanged();
            }
        }
       
        
        private DateTime? _ActualResolutionDate;
        public DateTime? ActualResolutionDate
        {
            get { return _ActualResolutionDate; }
            set
            {
                if (_ActualResolutionDate != value)
                    _ActualResolutionDate = value;
                onpropertychanged();
            }
        }
        private string _ResolutionSumup;
        public string ResolutionSumup
        {
            get { return _ResolutionSumup; }
            set
            {
                if (_ResolutionSumup != value)
                    _ResolutionSumup = value;
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
            if (!(obj is Issue))
            {
                return false;
            }
            return this.IssueId == ((Issue)obj).IssueId;
           
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
