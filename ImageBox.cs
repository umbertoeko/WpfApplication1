using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    class ImageBox : Shape
    {
        public double Width { get; set; }
        public double Heigth { get; set; }
        public string Path { get; set; }

        public ImageBox(String Name) : base()
        {
            this.Width = 100;
            this.Heigth = 100;
            this.Path = "pack://application:,,,/Images/darth.jpg";
            this.Name = Name;
        }

        public override UIElement Draw()
        {
            System.Windows.Controls.Image myImage =  new System.Windows.Controls.Image();
            myImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(Path, UriKind.RelativeOrAbsolute));
            myImage.Width = this.Width;
            myImage.Height = this.Heigth;
            System.Windows.Controls.Canvas.SetLeft(myImage, this.Left);
            System.Windows.Controls.Canvas.SetTop(myImage, this.Top);
            return (UIElement)myImage;
        }
    }
}
