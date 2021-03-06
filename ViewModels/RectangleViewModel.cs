﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class RectangleViewModel:ShapeViewModel 
    {
        protected new RectangleModel model { get { return (RectangleModel)base.model; } }

        public RectangleViewModel(RectangleModel model): base(model)
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
