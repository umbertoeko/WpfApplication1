using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace WpfApplication1.Beheivors
{
    public class DragBeheivor: Behavior<UserControl>
    {

        private Nullable<Point> dragStart = null;
        private MouseButtonEventHandler mouseDown;
        private MouseButtonEventHandler mouseUp;
        private MouseEventHandler mouseMove;
        private Action<UIElement> enableDrag;

        public DragBeheivor()
        {
            mouseDown = (sender, args) => {
                var element = (UIElement)sender;
                dragStart = args.GetPosition(element);
                element.CaptureMouse();
            };
            mouseUp = (sender, args) => {
                var element = (UIElement)sender;
                dragStart = null;
                element.ReleaseMouseCapture();
            };
            mouseMove = (sender, args) => {
                if (dragStart != null && args.LeftButton == MouseButtonState.Pressed)
                {
                    var element = (UIElement)sender;

                    var p2 = args.GetPosition(mainCanvas);
                    Canvas.SetLeft(element, p2.X - dragStart.Value.X);
                    Canvas.SetTop(element, p2.Y - dragStart.Value.Y);
                }
            };
            enableDrag = (element) => {
                element.MouseDown += mouseDown;
                element.MouseMove += mouseMove;
                element.MouseUp += mouseUp;
            };

        }

        protected override void OnAttached()
        {
            this.enableDrag(AssociatedObject);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        public static readonly DependencyProperty canvasProperty = DependencyProperty.Register(
       "mainCanvas", typeof(Canvas), typeof(DragBeheivor), new FrameworkPropertyMetadata());

        public Canvas mainCanvas
        {
            get { return (Canvas)GetValue(canvasProperty); }
            set { SetValue(canvasProperty, value); }
        }
/*
        public static void SetCanvasProperty(DependencyObject element, Canvas value)
        {
            element.SetValue(canvasProperty, value);
        }

        public static Canvas GetCanvasProperty(DependencyObject element)
        {
            return (Canvas)element.GetValue(canvasProperty);
        }
*/
    }
}
