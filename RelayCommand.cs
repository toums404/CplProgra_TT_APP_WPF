using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CplProgra_TT_APP_WPF
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute; // action a executer lorsque la commande est invoke
        private readonly Func<bool> _canExecute; // fonction qui determine si la commande peut etre executee

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        
        public event EventHandler CanExecuteChanged // gere l'evenement CanExecuteChanged pour notifier les changements de l'etat de la commande
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();
    }
}
