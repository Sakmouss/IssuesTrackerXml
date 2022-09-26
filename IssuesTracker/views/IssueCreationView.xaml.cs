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

namespace IssuesTracker.views
{
    /// <summary>
    /// Interaction logic for IssueCreationView.xaml
    /// </summary>
    public partial class IssueCreationView : UserControl
    {
        public IssueCreationView()
        {
            InitializeComponent();
        }
        private void Downbtn_Click(object sender, RoutedEventArgs e)
        {
            canvDescription.Height = 200;
            tbxIssueDescription.Height = 200;
            tbxIssueDescription.FontSize = 14;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            uptn.Visibility = Visibility.Visible;
        }

        private void Uptn_Click(object sender, RoutedEventArgs e)
        {
            tbxIssueDescription.Height = 60;
            canvDescription.Height = 60;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            downbtn.Visibility = Visibility.Visible;
        }

        private void Downbtn1_Click(object sender, RoutedEventArgs e)
        {
            canvsumup.Height = 150;
            tbxIssueSumup.Height = 150;
            tbxIssueSumup.FontSize = 14;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            uptn1.Visibility = Visibility.Visible;
        }

        private void Uptn1_Click(object sender, RoutedEventArgs e)
        {
            canvsumup.Height = 40;
            tbxIssueSumup.Height = 40;
            tbxIssueSumup.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            downbtn1.Visibility = Visibility.Visible;
        }

        private void Downbtn2_Click(object sender, RoutedEventArgs e)
        {
            canvprogress.Height = 150;
            tbxprogress.Height = 150;
            tbxprogress.FontSize = 14;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            uptn2.Visibility = Visibility.Visible;
        }

        private void Uptn2_Click(object sender, RoutedEventArgs e)
        {
            canvprogress.Height = 40;
            tbxprogress.Height = 40;
            tbxprogress.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            downbtn2.Visibility = Visibility.Visible;
        }

        private void Downbtn3_Click(object sender, RoutedEventArgs e)
        {
            canvresolt.Height = 150;
            tbxresolt.Height = 150;
            tbxresolt.FontSize = 14;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            uptn3.Visibility = Visibility.Visible;
        }

        private void Uptn3_Click(object sender, RoutedEventArgs e)
        {
            canvresolt.Height = 40;
            tbxresolt.Height = 40;
            tbxresolt.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            downbtn3.Visibility = Visibility.Visible;
        }
    }
}
