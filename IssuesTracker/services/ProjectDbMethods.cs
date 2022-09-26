using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IssuesTracker.model;
using IssuesTracker.data;
using System.Data.SqlClient;
using System.Data;

namespace IssuesTracker.services
{
    class ProjectDbMethods
    {
        //Add insest project into the database usinq linq
        public static int RegisterProjectDb(Project project)
        {
            DBproject pr = new DBproject();
            try
            {
                using (TrackerDBEntities db = new TrackerDBEntities())
                {
                    DBproject dbProject = new DBproject()
                    {
                        projectName = project.ProjectName,
                        createdDate = project.CreatedDate,
                        startDate = project.StartDate,
                        targetEndDate = project.TargetEndDate,
                        actualEndDate = project.ActualEndDate,
                    };
                    pr = db.DBprojects.Add(dbProject);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.InnerException.ToString()); }
            return pr.IdprojectId;
        }

        // get all the projects from database
        public static ObservableCollection<Project> GetProjectsDb()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>();
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                var projectsdb = db.DBprojects;
                foreach (DBproject pROJECT in projectsdb)
                {
                    Project project = new Project()
                    {
                        ActualEndDate = pROJECT.actualEndDate,
                        CreatedDate = pROJECT.createdDate,
                        ProjectId = pROJECT.IdprojectId,
                        ProjectName = pROJECT.projectName,
                        StartDate = pROJECT.startDate,
                        TargetEndDate = pROJECT.targetEndDate
                    };
                    projects.Add(project);
                }
            }
            return projects;
        }

        // get project details by project id
        public static Project getProjectbyId(int ProjectId)
        {
            
            
                var projectdb = new DBproject();

                using (TrackerDBEntities db = new TrackerDBEntities())
                {
                    projectdb = db.DBprojects.Where(c => c.IdprojectId == ProjectId).FirstOrDefault();
                }

                Project project = new Project()
                {
                    ProjectId = projectdb.IdprojectId,
                    ActualEndDate = projectdb.actualEndDate,
                    CreatedDate = projectdb.createdDate,
                    ProjectName = projectdb.projectName,
                    StartDate = projectdb.startDate,
                    TargetEndDate = projectdb.targetEndDate
                };
                return project;
           
            
        }
        // get project details by name
        public static Project GetProjectbyName(string projectName)
        {
            var projectdb = new DBproject();
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                projectdb = db.DBprojects.Where(c => c.projectName == projectName).FirstOrDefault();
            }
            Project project = new Project()
            {
                ProjectId = projectdb.IdprojectId,
                ActualEndDate = projectdb.actualEndDate,
                CreatedDate = projectdb.createdDate,
                ProjectName = projectdb.projectName,
                StartDate = projectdb.startDate,
                TargetEndDate = projectdb.targetEndDate
            };
            return project;
        }

        //Delete project by id
        public static void DeleteProjectById(int projectid)
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                var project = db.DBprojects.Where(c => c.IdprojectId == projectid).FirstOrDefault();
                db.DBprojects.Remove(project);
                db.SaveChanges();
            }
        }
        // get the project numbers
        public static int GetProjectNumberDb()
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                return db.DBprojects.Count();
            }
        }
        //update project
        public static void UpdateProjectDb(Project project)
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                var _project = db.DBprojects.Where(c => c.IdprojectId == project.ProjectId).FirstOrDefault();
               // _project.projectName = project.ProjectName;
                _project.createdDate = project.CreatedDate;
                _project.startDate = project.StartDate;
                _project.targetEndDate = project.TargetEndDate;
                _project.actualEndDate = project.ActualEndDate;
                db.SaveChanges();

            }
        }
        //Get project id from it name
        public static int GetProjectIdbyName(string projectname)
        {
            string conectionstring = "data source=(localdb)\\MSSQLLocalDB;" +
            "initial catalog=IssueTrackindDB;integrated security=True";
            string cmdText = $"Select projectId From IssueTrackindDB.dbo.PROJECTs Where projectName={projectname}";
            int projectid = 0;
            using (SqlConnection con = new SqlConnection(conectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectid = reader.GetInt32(0);
                }
                con.Close();
            }
            return projectid;
        }
        //Get project id from it name using linq
        public static int GetProjectIdByname(string projectname)
        {
            DBproject project = new DBproject();
            try
            {
                using (TrackerDBEntities db = new TrackerDBEntities())
                {
                    project = db.DBprojects.Where(c => c.projectName == projectname).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(project.IdprojectId.ToString());
            return project.IdprojectId;

        }

    }
}
