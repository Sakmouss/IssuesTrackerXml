using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using IssuesTracker.model;

namespace IssuesTracker.services
{
  public class UsersXmlMethods
    {
        static string root = "C:\\Users\\WORD\\Documents";
        static string path = $"{root}\\Users\\Users.xml";
        static string idpath = $"{root}\\Users\\ids.xml";
        public static void CreateUserDir()
        {
            if (!Directory.Exists($"{root}\\Users"))
            {
                Directory.CreateDirectory($"{root}\\Users" +
                    $"");
            }
            else { };
        }
        public static void createUsersFile()
        {
            // string projectname1 = project.ProjectName.Replace(' ', '_');

            try
            {
                string path = $"{root}\\Users\\Users.xml";

                if (!File.Exists(path))
                {
                    XElement doc = new XElement("Users" +
                        "");
                    doc.Save(path);
                }
                else { };
                if (!File.Exists(idpath))
                {
                    XElement doc = new XElement("id", new XAttribute("value", "0"));
                    doc.Save(idpath);
                }
                else { };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public static void AddUserXml(User user)
        {
            string path = $"{root}\\Users\\Users.xml";
            XElement doc = XElement.Load(path);
            XElement elmt = new XElement("User", new XAttribute("Name", user.Name ?? string.Empty),
                       new XAttribute("Id", user.UserId.ToString()),
                       new XAttribute("Email", user.UserEmail ?? string.Empty),
                       new XAttribute("UserName", user.UserName ?? string.Empty),
                       new XAttribute("Role", user.UserRole ?? string.Empty),
                       new XAttribute("AssignedProject", user.AssignedProjectName ?? string.Empty),
                       new XAttribute("Photo", Convert.ToBase64String(user.PersonPhoto)));
                doc.Add(elmt);
                doc.Save(path);
            
           
        }

        public static void DeleteUserXml(User user)
        {
            XElement doc = XElement.Load(path);
            XElement elmt = doc.Descendants("User").Where(c => c.Attribute("Id").Value == user.UserId.ToString()).FirstOrDefault();
            elmt.Remove();
            doc.Save(path);

        }

        public static void ModifyUserXml(User user)
        {
            XElement doc = XElement.Load(path);
            XElement elmt = doc.Descendants("User").Where(c => c.Attribute("Id").Value == user.UserId.ToString()).FirstOrDefault();
            elmt.Attribute("Name").Value = user.UserName;
            elmt.Attribute("Email").Value = user.UserEmail;
            elmt.Attribute("UserName").Value = user.UserName;
            elmt.Attribute("Role").Value = user.UserRole;
            elmt.Attribute("AssignedProject").Value = user.AssignedProjectName;
            elmt.Attribute("Photo").Value = Convert.ToBase64String(user.PersonPhoto);
            doc.Save(path);
        }
        public static int increaseid()
        {
            XElement doc = XElement.Load(idpath);
            int val = Int32.Parse(doc.Attribute("value").Value);
            val++;
            doc.Attribute("value").Value = val.ToString();
            doc.Save(idpath);
            return val;
        }
        public static ObservableCollection<User> GetUsersXml()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            try
            {
               
                XElement doc = XElement.Load(path);
                IEnumerable<XElement> xElements = doc.Descendants();
                foreach (XElement elnt in xElements)
                {
                    User user = new User()
                    {
                        Name = elnt.Attribute("Name").Value,
                        UserId = Int32.Parse(elnt.Attribute("Id").Value),
                        AssignedProjectName = elnt.Attribute("AssignedProject").Value,
                        PersonPhoto = Convert.FromBase64String(elnt.Attribute("Photo").Value),
                        UserEmail = elnt.Attribute("Email").Value,
                        UserName = elnt.Attribute("UserName").Value,
                        UserRole = elnt.Attribute("Role").Value
                    };
                    users.Add(user);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return users;
        }
        public static User GetUserByIdXml(int id)
        {
            XElement doc = XElement.Load(path);
            XElement elemt = doc.Descendants("User").Where(c => c.Attribute("Id").Value == id.ToString()).FirstOrDefault();
            User user = new User()
            {
                Name = elemt.Attribute("Name").Value,
                PersonPhoto = Convert.FromBase64String(elemt.Attribute("Photo").Value),
                AssignedProjectName = elemt.Attribute("AssignedProject").Value,
                UserEmail = elemt.Attribute("Email").Value,
                UserId = Int32.Parse(elemt.Attribute("Id").Value),
                UserName = elemt.Attribute("UserName").Value,
                UserRole = elemt.Attribute("Role").Value
            };
            return user;
        }
        public static ObservableCollection<string>GetUserNamesXml()
        {
            ObservableCollection<string> usernames = new ObservableCollection<string>();
            XElement doc = XElement.Load(path);
            var xelements = doc.Descendants();
            foreach(XElement elmt in xelements)
            {
                string username = elmt.Attribute("Name").Value;
                usernames.Add(username);
            }
            return usernames;
        }
        
    }
}
