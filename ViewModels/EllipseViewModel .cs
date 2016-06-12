using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class EllipseViewModel:ShapeViewModel 
    {
        protected new EllipseModel model { get { return (EllipseModel)base.model; } }

        public EllipseViewModel(EllipseModel model): base(model)
        {
        }

        public double Height
        {
            get { return model.Height; }
            set { model.Height = value;}
        }

        public double Width
        {
            get { return model.Width; }
            set { model.Width = value;}
        }
    }
}
