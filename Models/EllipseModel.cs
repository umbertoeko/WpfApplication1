using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1.Models
{
    public class EllipseModel: ShapeModel
    {
        public double _width;
        public double _height;

        public EllipseModel(string name) : base()
        {
            Random rand = new Random();
            this._height = rand.Next(50, 200);
            this._width = rand.Next(50, 200);
            this.Name = name;
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
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

    }
}