using IssuesTracker.services;
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
using System.Windows.Shapes;

namespace IssuesTracker
{
    /// <summary>
    /// Interaction logic for Loginform.xaml
    /// </summary>
    public partial class Loginform : Window
    {
        public Loginform()
        {
            InitializeComponent();
        }
        private void BtxLogin_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
