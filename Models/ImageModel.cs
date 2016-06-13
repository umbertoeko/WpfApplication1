using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    class ImageModel : ShapeModel
    {
        private double _width;
        private double _height;
        private string _path;

        public ImageModel(string name) : base()
        {
            Random rand = new Random();
            this._height = rand.Next(50, 200);
            this._width = rand.Next(50, 200);
            this._path = "pack://application:,,,/Images/darth.jpg";
            this.Name = name;
        }

        public String Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
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
