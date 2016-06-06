using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    class Rectangle: Shape
    {
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Rectangle(String Name) : base()
        {
            this.Width = 150;
            this.Heigth = 75;
            this.Name = Name;
        }

        public override UIElement Draw()
        {
            System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
            rectangle.Width = this.Width;
            rectangle.Height = this.Heigth;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Colors.Transparent);
            System.Windows.Controls.Canvas.SetLeft(rectangle, this.Left);
            System.Windows.Controls.Canvas.SetTop(rectangle, this.Top);
            return (UIElement) rectangle;
        }
    }
}