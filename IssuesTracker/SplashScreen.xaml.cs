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
using System.Windows.Threading;

namespace IssuesTracker
{
    /// <summary>
    /// Interaction logic for Splashscreen.xaml
    /// </summary>
    public partial class Splashscreen : Window
    {
        DispatcherTimer dispatcher = new DispatcherTimer();
        public Splashscreen()
        {
            InitializeComponent();
            dispatcher.Interval = new TimeSpan(0, 0, 5);
            dispatcher.Start();
            dispatcher.Tick += Dispatcher_Tick;
        }
        
        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            dispatcher.Stop();
        }
    }
}
