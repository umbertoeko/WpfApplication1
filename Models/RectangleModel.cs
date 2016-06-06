using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1.Models
{
    public class RectangleModel: ShapeModel
    {
        public double _width;
        public double _heigth;

        public RectangleModel() : base()
        {
            this._heigth = 50;
            this._width = 150;
        }

        public double Width
        {
            get { return _width; }
            set
            {
               _width = value;
                OnPropertyChanged("Width");
            }
        }
        public double Heigth
        {
            get { return _heigth; }
            set
            {
                _heigth = value;
                OnPropertyChanged("Heigth");
            }
        }

    }
}