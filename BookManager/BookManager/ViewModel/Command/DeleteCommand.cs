using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookManager.ViewModel.Command
{
    /* DeleteCommand handles the DeleteButton's function entirely.
       The Difference to RelayCommand is its Constructor awaiting
       an Action with an object, and has no need for a whenToExecute
       for the when is always to remain true in case of Deleting an
       Item upon activation. */
    class DeleteCommand : ICommand
    {

        private Action<object> whatToExecuteObj;

        public DeleteCommand(Action<object> what)
        {
            this.whatToExecuteObj = what;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            whatToExecuteObj(parameter);
        }

       
    }
}
