using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Encodage_Fermette.ViewModel
{
    
    public class BasePropriete : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        protected bool AssignerChamp<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            PropertyChangedEventHandler handler = PropertyChanged;
            field = value;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName.Substring(4)));
            //OnPropertyChanged();
            return true;
        }
    }
    
    public class BaseCommande : ICommand
    {
        private Action _Action;
        public BaseCommande(Action Action_)
        { _Action = Action_; }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        { return true; }
        public void Execute(object parameter)
        { if (_Action != null) _Action(); }
    }
  
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        private Predicate<object> canExecute;

        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }

}