using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IssuesTracker.services
{
    public class ParamCommand : ICommand
    {
        private Action<Object> _execute;
        private Func<Object, bool> _canexecute;
        public event EventHandler CanExecuteChanged;
        public ParamCommand(Action<Object> execute, Func<Object, bool> canexecute)
        {
            if (execute == null) { throw new ArgumentNullException(nameof(execute)); };
            _execute = execute;
            _canexecute = canexecute ?? (x => true);
        }
        public ParamCommand(Action<Object> execute) : this(execute, null)
        {

        }
        void raisecanexecutechanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
