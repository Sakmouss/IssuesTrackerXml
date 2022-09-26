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
    /// Interaction logic for ModifyProjectView.xaml
    /// </summary>
    public partial class ModifyProjectView : UserControl
    {
        public ModifyProjectView()
        {
            InitializeComponent();
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

        private void Btninfo_Click(object sender, RoutedEventArgs e)
        {

            if (panelInfo.Visibility == Visibility.Collapsed)
            {
                panelInfo.Visibility = Visibility.Visible;
                btninfo.Content = "-";
            }
            else if (panelInfo.Visibility == Visibility.Visible)
            {
                panelInfo.Visibility = Visibility.Collapsed;
                btninfo.Content = "+";

            }
        }
    }
}
