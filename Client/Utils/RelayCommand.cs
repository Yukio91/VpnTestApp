﻿using System;
using System.Windows.Input;

namespace vpn.Client.Utils
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        private Predicate<object> canExecute;

        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute, object p)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ??
                throw new ArgumentNullException(nameof(execute));

            this.canExecute = canExecute ??
                throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null && canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChangedInternal;
            if (handler != null)
            {
                handler?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            canExecute = _ => false;
            execute = _ => { return; };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}