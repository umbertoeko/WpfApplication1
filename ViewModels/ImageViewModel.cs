using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    class ImageViewModel : ShapeViewModel
    {
        protected new ImageModel model { get { return (ImageModel)base.model; } }

        public ImageViewModel(ImageModel model) : base(model)
        {
        }

        public double Height
        {
            get { return model.Height; }
            set { model.Height = value; }
        }

        public double Width
        {
            get { return model.Width; }
            set { model.Width = value; }
        }

        public String ImagePath
        {
            get { return model.Path; }
            set { model.Path = value; }
        }
    }
}
