using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class MainModelView
    {
        private ObservableCollection<ShapeViewModel> _shapes = new ObservableCollection<ShapeViewModel>();

        public MainModelView()
        {
            _shapes.Add(new RectangleViewModel(new RectangleModel()));
            _shapes.Add(new RectangleViewModel(new RectangleModel()));
            _shapes.Add(new RectangleViewModel(new RectangleModel()));
        }

        public ObservableCollection<ShapeViewModel> Shapes
        {
            get
            {
                return _shapes;
            }
        }
    }
}
