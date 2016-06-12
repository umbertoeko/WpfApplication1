using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;
using WpfApplication1.Commands;
using System.Windows.Input;
using System.ComponentModel;

namespace WpfApplication1.ViewModels
{
    public class MainModelView :INotifyPropertyChanged

    {
        private ObservableCollection<ShapeViewModel> _shapes = new ObservableCollection<ShapeViewModel>();
        private ShapeViewModel _selected;
        private ICommand _addRectangle;
        private ICommand _addEllipse;
        private ICommand _clearAll;
        private ICommand _deleteShape;
        private ICommand _selectShape;
        private int itemsCount = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand ClearAll
        {
            get
            {
                return _clearAll ?? (_clearAll = new addShapeCommand(() =>
                {
                    _shapes.Clear();
                    _selected = null;
                    itemsCount = 0;
                    OnPropertyChanged("SelectedItem");
                    OnPropertyChanged("Shapes");
                }));
            }
        }

        public ICommand DeleteShape
        {
            get
            {
                return _deleteShape ?? (_deleteShape = new manipulateShapeCommand((ShapeViewModel shape) =>
                {
                    int index =_shapes.IndexOf(shape);
                    if (index >=    0)
                    {
                        if (shape == _selected)
                        {
                            _selected = null;
                            OnPropertyChanged("Shapes");
                        }
                        _shapes.RemoveAt(index);
                        OnPropertyChanged("SelectedItem");
                    }
                }));
            }
        }

        public ICommand SelectShape
        {
            get
            {
                return _selectShape ?? (_selectShape = new manipulateShapeCommand((ShapeViewModel shape) =>
                {
                    int index = _shapes.IndexOf(shape);
                    if (index >= 0)
                    {
                        _selected = _shapes[index];
                        OnPropertyChanged("SelectedItem");
                    }
                }));
            }
        }

        public ICommand AddRectangle
        {
            get
            {
                return _addRectangle ?? (_addRectangle = new addShapeCommand(() => 
                {
                    itemsCount++;
                    _shapes.Add(new RectangleViewModel(new RectangleModel("Shape_"+ itemsCount)));
                    _selected = _shapes.Last();
                    OnPropertyChanged("SelectedItem");
                    OnPropertyChanged("Shapes");
                }));
            }
        }

        public ICommand AddEllipse
        {
            get
            {
                return _addEllipse ?? (_addEllipse = new addShapeCommand(() => 
                {
                    itemsCount++;
                    _shapes.Add(new EllipseViewModel(new EllipseModel("Shape_" + itemsCount)));
                    _selected = null;
                    OnPropertyChanged("SelectedItem");
                    OnPropertyChanged("Shapes");
                }));
            }
        }

        public MainModelView()
        {
            _selected = null; 
        }

        public ObservableCollection<ShapeViewModel> Shapes
        {
            get
            {
                return _shapes;
            }
        }

        public ShapeViewModel SelectedItem
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged("SelectedItem");
            }
        }

    }
}
