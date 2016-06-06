using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    class TextBlock : Shape
    {
        public int FontSize { get; set; } 
        public string Text { get; set; }
        public TextBlock(String Name) : base()
        {
            this.Text = "Sample Text";
            this.FontSize = 22;
            this.Name = Name;
        }

        public override UIElement Draw()
        {
            System.Windows.Controls.Label myLabel = new System.Windows.Controls.Label();
            myLabel.FontSize = this.FontSize;
            myLabel.Content = this.Text;
            System.Windows.Controls.Canvas.SetLeft(myLabel, this.Left);
            System.Windows.Controls.Canvas.SetTop(myLabel, this.Top);
            return (UIElement)myLabel;
        }
    }
}
