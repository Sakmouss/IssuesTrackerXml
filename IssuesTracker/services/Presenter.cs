using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTracker.services
{
    class Presenter
    {
        public static void show(Object item)
        {
            Contener con = new Contener() { DataContext = item };
            con.Show();
        }
    }
}
