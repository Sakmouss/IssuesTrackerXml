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
    /// Interaction logic for ModifyIssueView.xaml
    /// </summary>
    public partial class ModifyIssueView : UserControl
    {
        public ModifyIssueView()
        {
            InitializeComponent();
        }

        private void Downbtn_Click(object sender, RoutedEventArgs e)
        {
            canvdescript.Height = 200;
            tbxIssueDescript.Height = 200;
            tbxIssueDescript.FontSize = 16;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Upbtn.Visibility = Visibility.Visible;
        }

        private void Upbtn_Click(object sender, RoutedEventArgs e)
        {
            tbxIssueDescript.Height = 60;
            canvdescript.Height = 60;
            tbxIssueDescript.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Downbtn.Visibility = Visibility.Visible;
        }

        private void Downbtn1_Click(object sender, RoutedEventArgs e)
        {
            canvSumup.Height = 150;
            tbxIssueSuup.Height = 150;
            tbxIssueSuup.FontSize = 16;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Upbtn1.Visibility = Visibility.Visible;
        }

        private void Upbtn1_Click(object sender, RoutedEventArgs e)
        {
            canvSumup.Height = 40;
            tbxIssueSuup.Height = 40;
            tbxIssueSuup.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Downbtn1.Visibility = Visibility.Visible;
        }

        private void Downbtn2_Click(object sender, RoutedEventArgs e)
        {
            canvResolution.Height = 150;
            tbxResolution.Height = 150;
            tbxResolution.FontSize = 16;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Upbtn2.Visibility = Visibility.Visible;
        }

        private void Upbtn2_Click(object sender, RoutedEventArgs e)
        {
            canvResolution.Height = 40;
            tbxResolution.Height = 40;
            tbxResolution.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Downbtn2.Visibility = Visibility.Visible;
        }

        private void Downbtn3_Click(object sender, RoutedEventArgs e)
        {
            canvprogress.Height = 150;
            tbxprogress.Height = 150;
            tbxprogress.FontSize = 16;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Upbtn3.Visibility = Visibility.Visible;
        }

        private void Upbtn3_Click(object sender, RoutedEventArgs e)
        {
            canvprogress.Height = 40;
            tbxprogress.Height = 40;
            tbxprogress.FontSize = 12;
            Button button = (Button)sender;
            button.Visibility = Visibility.Collapsed;
            Downbtn3.Visibility = Visibility.Visible;
        }

    }
}
