using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class shapeButton : UserControl
    {
        public event EventHandler CloseSignClicked;
        public event EventHandler SignClicked;

        public shapeButton(string text)
        {
            InitializeComponent();
            this.controlLabel.Content = text;
        }

        private void DeleteCurrentShape(object sender, MouseButtonEventArgs e)
        {
            EventHandler handler = CloseSignClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EventHandler handler = SignClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
