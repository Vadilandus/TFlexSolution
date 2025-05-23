using System;
using System.Windows.Input;

namespace FigureSolution.Utils
{
    /// <summary>
    /// Класс реализующий команды, которые используются в XAML для привязок действий
    /// </summary>
    internal class RelayCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }


        /// <summary>
        /// Проверка возможности выполнения команды
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }


        /// <summary>
        /// Выполнение команды
        /// </summary>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }


        /// <summary>
        /// Событие изменения состояния команды
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
