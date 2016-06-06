using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    class Shape
    {
        public double Top { get; set; }
        public double Left { get; set; }
        public string Name { get; set; }
        public double ForegroundColor { get; set; }

        public Shape()
        {
            Top = 100;
            Left = 100;
            Name = "";
        }

        public virtual UIElement Draw()
        {
            return new UIElement();
        }
    }
}
