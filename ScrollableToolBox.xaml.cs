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
    public partial class ScrollableToolBox : UserControl
    {
        public ScrollableToolBox()
        {
            InitializeComponent();
        }

        public int Add(UIElement element)
        {
            return this.myToolBox.Children.Add(element);
        }

        public void Remove(UIElement element)
        {
            this.myToolBox.Children.Remove(element);
        }

        public void Clear()
        {
            this.myToolBox.Children.Clear();
        }

        private void scrollLeft_Click(object sender, RoutedEventArgs e)
        {
            myScrollableArea.LineLeft();
        }

        private void scrollRight_Click(object sender, RoutedEventArgs e)
        {
            myScrollableArea.LineRight();
        }
    }
}
