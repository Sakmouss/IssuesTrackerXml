using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Forms;

namespace IssuesTracker.views
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : System.Windows.Controls.UserControl
    {
        public AddUserView()
        {
            InitializeComponent();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            tbxUserName.Text = string.Empty;
            tbxEmail.Text = "";
            tbxName.Text = "";
           
            cbxAssigneProjectName.SelectedItem = null;
            cbxUserRole.SelectedItem = null;
            imgPhoto.Source = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Uri uri = new Uri(dlg.FileName);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = uri;
                bmp.DecodePixelWidth = 70;
                bmp.EndInit();
                imgPhoto.Source = bmp;
            }
        }

        private void AuditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuditStkpl.Visibility == Visibility.Collapsed)
            {
                AuditStkpl.Visibility = Visibility.Visible;
                AuditBtn.Content = "-";
            }
            else if (AuditStkpl.Visibility == Visibility.Visible)
            {
                AuditStkpl.Visibility = Visibility.Collapsed;
                AuditBtn.Content = "+";
            }
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (panelInfo.Visibility == Visibility.Collapsed)
            {
                panelInfo.Visibility = Visibility.Visible;
                btnInfo.Content = "-";
            }
            else if (panelInfo.Visibility == Visibility.Visible)
            {
                panelInfo.Visibility = Visibility.Collapsed;
                btnInfo.Content = "+";
            }
        }
    }
}
