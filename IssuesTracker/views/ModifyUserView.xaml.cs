using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IssuesTracker.views
{
    /// <summary>
    /// Interaction logic for ModifyUserView.xaml
    /// </summary>
    public partial class ModifyUserView : System.Windows.Controls.UserControl
    {
        public ModifyUserView()
        {
            InitializeComponent();
        }
        private void ImgUser_MouseDown(object sender, MouseButtonEventArgs e)
        {

           /* OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Uri uri = new Uri(dlg.FileName);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = uri;
                bmp.DecodePixelWidth = 70;
                bmp.EndInit();
                imgUser.Source = bmp;
            }
            */
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Uri uri = new Uri(dlg.FileName);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = uri;
                bmp.DecodePixelWidth = 70;
                bmp.EndInit();
                imgUser.Source = bmp;
            }
        }
    }
}
