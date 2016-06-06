using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication1
{
    class Triangle :Shape
    {
        public double Angle { set; get; }
        public double sideWidth1 { set; get; }
        public double sideWidth2 { set; get; }

        public Triangle(String Name) : base()
        {
            this.sideWidth1 = 100;
            this.sideWidth2 = 100;
            this.Angle = 60;
            this.Name = Name;
        }

        public override UIElement Draw()
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.Fill = System.Windows.Media.Brushes.Transparent;
            double angleRadians =  this.Angle * (Math.PI / 180.0);
            System.Windows.Point Point3 = new System.Windows.Point(this.sideWidth2 * Math.Cos(angleRadians), 0);
            System.Windows.Point Point1 = new System.Windows.Point(0, this.sideWidth2 * Math.Sin(angleRadians));
            System.Windows.Point Point2 = new System.Windows.Point(this.sideWidth1 * Math.Cos(0), 
                this.sideWidth1 * Math.Sin(0)+ this.sideWidth2 * Math.Sin(angleRadians));
            PointCollection myPointCollection = new PointCollection(); 
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPolygon.Points = myPointCollection;
            System.Windows.Controls.Canvas.SetLeft(myPolygon, this.Left);
            System.Windows.Controls.Canvas.SetTop(myPolygon, this.Top);
            return (UIElement)myPolygon;
        }

    }
}
