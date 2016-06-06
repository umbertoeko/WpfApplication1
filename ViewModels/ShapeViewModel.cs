using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class ShapeViewModel
    {
        protected ShapeModel model { get;}

        public ShapeViewModel(ShapeModel model)
        {
            this.model = model;
        }

        public double Top
        {
            get { return model.Top; }
            set { model.Top = value;}
        }

        public double Left
        {
            get { return model.Left; }
            set { model.Left = value;}
        }

        public string Name
        {
            get { return model.Name; }
            set { model.Name = value; }
        }

        public Color ForegroundColor
        {
            get { return model.ForegroundColor; }
            set { model.ForegroundColor = value; }
        }
    }
}
