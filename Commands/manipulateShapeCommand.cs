using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Commands
{
    class manipulateShapeCommand :ICommand
    {
        private Action<ShapeViewModel> _action;

        public manipulateShapeCommand(Action<ShapeViewModel> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter as ShapeViewModel);
        }
    }
}
