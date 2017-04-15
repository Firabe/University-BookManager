using System;
using System.Windows.Input;

namespace BookManager.ViewModel.Command
{
    class RelayCommand : ICommand
    {
        private Action whatToExecute;
        private Func<bool> whenToExecute;

        public RelayCommand(Action what, Func<bool> when)
        {
            whatToExecute = what;
            whenToExecute = when;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return whenToExecute();
        }

        public void Execute(object parameter)
        {
            whatToExecute();
        }
    }
}
