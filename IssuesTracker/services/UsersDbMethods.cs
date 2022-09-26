using IssuesTracker.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IssuesTracker.data;

namespace IssuesTracker.services
{
    public class UsersDbMethods
    {
        //Add insest user into the database usinq linq
        public static int RegisterUserDb(User user)
        {
          DBuser pr = new DBuser();
            try
            {
                using (TrackerDBEntities db = new  TrackerDBEntities())
                {
                    DBuser dbperson = new DBuser()
                    {
                        personName = user.Name,
                        userName = user.UserName,
                        assignedProject = user.AssignedProjectName,
                        personEmail = user.UserEmail,
                        personRole = user.UserRole,
                        personPhoto = user.PersonPhoto,
                        registeredDate = user.RegisteredDate,
                    };
                    pr = db.DBusers.Add(dbperson);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.InnerException.ToString()); }
            return pr.userId;
        }

        // get all the user from database
        public static ObservableCollection<User> GetDbUsersDb()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            using (TrackerDBEntities db = new  TrackerDBEntities())
            {
                var usersDb = db.DBusers;
                foreach (DBuser person in usersDb)
                {
                    User user = new User()
                    {
                        Name = person.personName,
                        UserName = person.userName,
                        UserEmail = person.personEmail,
                        PersonPhoto = person.personPhoto,
                        RegisteredDate = person.registeredDate,
                        UserRole = person.personRole,
                        UserId = person.userId,
                        AssignedProjectName = person.assignedProject
                    };
                    users.Add(user);
                }
            }
            return users;
        }
        // get the projectNames
        public static ObservableCollection<string> GetProjectNamesDb()
        {
            ObservableCollection<string> projectnames = new ObservableCollection<string>();
            string conectionstring = "data source = (localdb)\\MSSQLLocalDB; initial catalog = TrackerDB;" +
           " integrated security = True";
           string cmdText = "Select projectName From TrackerDB.dbo.DBprojects";
            using (SqlConnection con = new SqlConnection(conectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectnames.Add($"{reader.GetString(0)}");
                }
                con.Close();
            }
            return projectnames;
        }

        public static string GetProjectName(int projectId)
        {
            string conectionstring = "data source=(localdb)\\MSSQLLocalDB;" +
           "initial catalog=TRackerDB;integrated security=True";
            string cmdText = $"Select projectName From TrackerDB.dbo.DBprojects Where IdprojectId={projectId}";
            string projectname = string.Empty;
            using (SqlConnection con = new SqlConnection(conectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectname = reader.GetString(0);
                }
                con.Close();
            }
            return projectname;
        }

        public static void UpdateUser(User user)
        {
            using (TrackerDBEntities db=new TrackerDBEntities())
            {
                var _user = db.DBusers.Where(c => c.userId == user.UserId).FirstOrDefault();
                _user.personEmail = user.UserEmail;
                _user.personName = user.Name;
                _user.personRole = user.UserRole;
                _user.registeredDate = user.RegisteredDate;
                _user.userName = user.UserName;
                _user.personPhoto = user.PersonPhoto;
                db.SaveChanges();
            }
        }

        public static User GetUserbyId(int userid)
        {
            var userdb = new DBuser();
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                userdb = db.DBusers.Where(c => c.userId == userid).FirstOrDefault();

                User user = new User()
                {
                    UserId = userid,
                    AssignedProjectName = userdb.assignedProject,
                    Name = userdb.personName,
                    RegisteredDate = userdb.registeredDate,
                    UserEmail = userdb.personEmail,
                    UserName = userdb.userName,
                    UserRole = userdb.personRole,
                    PersonPhoto = userdb.personPhoto,

                };
                return user;
            }

        }
        public static void DeleteUserById(int userid)
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                var user = db.DBusers.Where(c => c.userId == userid).FirstOrDefault();
                db.DBusers.Remove(user);
                db.SaveChanges();
            }
        }

        public static void UpdateUserDb(User user)
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                DBuser pERSON = db.DBusers.Where(c => c.userId == user.UserId).FirstOrDefault();
                pERSON.personName = user.Name;
                pERSON.personPhoto = user.PersonPhoto;
                pERSON.personRole = user.UserRole;
                pERSON.userName = user.UserName;
                pERSON.registeredDate = user.RegisteredDate;
                pERSON.personEmail = user.UserEmail;
                pERSON.assignedProject = user.AssignedProjectName;
                db.SaveChanges();
            }
        }
        /*  static int GetProjectIdByName(string projectname)
          {
              string[] names = projectname.Split(' ');
              return Int32.Parse(names[0]);
          }
          */
        public static ObservableCollection<string> GetUsernames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            string conectionstring = "data source=(localdb)\\MSSQLLocalDB;" +
           "initial catalog=TrackerDB;integrated security=True";
            string cmdText = "Select personName From TrackerDB.dbo.DBusers";
            using (SqlConnection con = new SqlConnection(conectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    names.Add($"{reader.GetString(0)}");
                }
                con.Close();
            }
            return names;

        }
        public static string GetUserNameById(int Userid)
        {
            string conectionstring = "data source=(localdb)\\MSSQLLocalDB;" +
          "initial catalog=DataManagerDB;integrated security=True";
            string cmdText = $"Select PersonName From IssueTrackindDB.dbo.USERs Where personId={Userid}";
            string username = string.Empty;
            using (SqlConnection con = new SqlConnection(conectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    username = reader.GetString(0);
                }
                con.Close();
            }
            return username;
        }

        public static string GetUserNameByid(int? Userid)
        {
            if (Userid == null)
            {
                return "Null";
            }
            else
            {
                string conectionstring = "data source=(localdb)\\MSSQLLocalDB;" +
              "initial catalog=DataManagerDB;integrated security=True";
                string cmdText = $"Select personName From IssueTrackindDB.dbo.USERs Where personId={Userid}";
                string username = string.Empty;
                using (SqlConnection con = new SqlConnection(conectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        username = reader.GetString(0);
                    }
                    con.Close();
                }
                return username;
            }
        }
       
       
        public static void DeleteProjectName(string projecrtname)
        {
            using (TrackerDBEntities db = new TrackerDBEntities())
            {
                var users = db.DBusers.Where(c => c.assignedProject == projecrtname);
                foreach (DBuser user in users)
                {
                    user.assignedProject = "";
                }
                db.SaveChanges();
            }
        }


    }
}
