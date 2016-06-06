using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1.Beheivors
{
    public static class UserControlCustomProperty
    {
        public static readonly DependencyProperty canvasProperty = DependencyProperty.RegisterAttached(
        "mainCanvas", typeof(Canvas), typeof(UserControl), new FrameworkPropertyMetadata());

        public static void SetCanvasProperty(DependencyObject element, Canvas value)
        {
            element.SetValue(canvasProperty, value);
        }

        public static Canvas GetCanvasProperty(DependencyObject element)
        {
            return (Canvas)element.GetValue(canvasProperty);
        }
    }
}
