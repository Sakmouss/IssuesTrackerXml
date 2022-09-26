using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssuesTracker.model;

namespace IssuesTracker.viewmodel
{
    class IssueDocViewModel
    {
        public Issue issue { get; set; }
        public IssueDocViewModel()
        {
            issue = new Issue();
        }
    }
}
