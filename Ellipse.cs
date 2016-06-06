using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    class Ellipse: Shape
    {
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Ellipse(String Name):base()
        {
            this.Width = 100;
            this.Heigth = 100;
            this.Name = Name;
        }

        public override UIElement Draw()
        {
            System.Windows.Shapes.Ellipse ellipse = new System.Windows.Shapes.Ellipse();
            ellipse.Width = this.Width;
            ellipse.Height = this.Heigth;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Transparent);
            System.Windows.Controls.Canvas.SetLeft(ellipse, this.Left);
            System.Windows.Controls.Canvas.SetTop(ellipse, this.Top);
            return (UIElement)ellipse;

        }
    }
}
