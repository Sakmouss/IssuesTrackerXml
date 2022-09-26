using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IssuesTracker.model;
using IssuesTracker.data;
using System.Collections.ObjectModel;

namespace IssuesTracker.services
{
    public class IssuesDbMethods
    {
        public static int RegisterIssue(Issue issue)
        {
            MessageBox.Show(issue.IssueRelatedProject);
            DBissue issuedb = new DBissue();
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                try
                {
                   DBissue dbissue = new DBissue()
                    {
                        assignedPerson = issue.AssignedPersonName,
                        identifiedDate = issue.IssueIdentifiedDate,
                        issueDescription = issue.IssueDescription,
                        issueSumup = issue.IssueSumup,
                        issueProgression=issue.issueProgression,
                        actualResolutionDate = issue.ActualResolutionDate,
                        resolutionSumup = issue.ResolutionSumup,
                        resolutionTargetDate = issue.ResolutionTargetDate,
                        relatedProjectId = ProjectDbMethods.GetProjectIdByname(issue.IssueRelatedProject)
                   };
                     issuedb = db.DBissues.Add(dbissue);
                     db.SaveChanges();
                 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return issuedb.issueId;
            }
        }
        public static ObservableCollection<Issue> GetIssuesDb()
        {
            ObservableCollection<Issue> issues = new ObservableCollection<Issue>();
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                try
                {
                    var issuesdb = db.DBissues;
                    foreach (DBissue issuedb in issuesdb)
                    {
                        Issue issue = new Issue()
                        {
                            ActualResolutionDate = issuedb.actualResolutionDate,
                            IssueDescription = issuedb.issueDescription,
                            IssueId = issuedb.issueId,
                            IssueRelatedProjectId = issuedb.relatedProjectId,
                            IssueSumup = issuedb.issueSumup,
                            ResolutionSumup = issuedb.resolutionSumup,
                            ResolutionTargetDate = issuedb.resolutionTargetDate,
                            IssueRelatedProject = UsersDbMethods.GetProjectName(issuedb.relatedProjectId),
                            AssignedPersonName = issuedb.assignedPerson,
                            IssueIdentifiedDate=issuedb.identifiedDate,
                            
                        };
                        issues.Add(issue);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return issues;
            }
        }
        public static Issue GetIssueById(int issueid)
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                var issuedb = db.DBissues.Where(c => c.issueId == issueid).FirstOrDefault();
                Issue issue = new Issue()
                {
                    ActualResolutionDate = issuedb.actualResolutionDate,
                    IssueDescription = issuedb.issueDescription,
                    IssueId = issuedb.issueId,
                    IssueRelatedProjectId = issuedb.relatedProjectId,
                    IssueSumup = issuedb.issueSumup,
                    issueProgression=issuedb.issueProgression,
                    ResolutionSumup = issuedb.resolutionSumup,
                    ResolutionTargetDate = issuedb.resolutionTargetDate,
                    IssueRelatedProject = $"{UsersDbMethods.GetProjectName(issuedb.relatedProjectId)}",
                    AssignedPersonName = issuedb.assignedPerson,
                    IssueIdentifiedDate=issuedb.identifiedDate
                 };
                return issue;
            }
        }
        public static void UpdateIssueDb(Issue issue)
        {
            using (TrackerDBEntities db = new  TrackerDBEntities())
            {
                try
                {
                  DBissue dbissue = db.DBissues.Where(c => c.issueId == issue.IssueId).FirstOrDefault();
                     dbissue.identifiedDate = issue.IssueIdentifiedDate;
                    dbissue.issueDescription = issue.IssueDescription;
                    dbissue.issueSumup = issue.IssueSumup;
                    dbissue.actualResolutionDate = issue.ActualResolutionDate;
                    dbissue.resolutionSumup = issue.ResolutionSumup;
                    dbissue.resolutionTargetDate = issue.ResolutionTargetDate;
                    dbissue.relatedProjectId = issue.IssueRelatedProjectId;
                    dbissue.assignedPerson = issue.AssignedPersonName;
                    dbissue.issueProgression = issue.issueProgression;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }
        }
        static int GetIssueIdByName(string issuename)
        {
            string[] names = issuename.Split(' ');
            return Int32.Parse(names[0]);
        }
        public static void DeleteIssueById(int issueid)
        {
            if (issueid == 0)
            { }
            else
            {
                using (TrackerDBEntities db = new TrackerDBEntities())
                {
                    var issue = db.DBissues.Where(c => c.issueId == issueid).FirstOrDefault();
                    db.DBissues.Remove(issue);
                    db.SaveChanges();
                }
            }
        }
        public static void DeleteIssueByProject(int projectid)
        {
            using (TrackerDBEntities db = new  TrackerDBEntities())
            {
                var issues = db.DBissues.Where(c => c.relatedProjectId == projectid);
                db.DBissues.RemoveRange(issues);
                db.SaveChanges();
            }
        }
    }
}
