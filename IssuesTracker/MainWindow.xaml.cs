using IssuesTracker.services;
using IssuesTracker.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IssuesTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            ProjectsXmlMethods.CreatePojectDir();
            ProjectsXmlMethods.createProjectFile();
            UsersXmlMethods.CreateUserDir();
            UsersXmlMethods.createUsersFile();
            IssuesXmlMethods.CreateIssueDir();
            IssuesXmlMethods.createIssueFile();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MainWinCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            ProjectsView projectv = new ProjectsView();
            mainArea.Content = projectv;


        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersView usersView = new UsersView();
            mainArea.Content = usersView;
        }

        private void BtnIssues_Click(object sender, RoutedEventArgs e)
        {
            IssuesViews issuesViews = new IssuesViews();
            mainArea.Content = issuesViews;
        }
    }
}
