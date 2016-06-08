using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Beheivors
{
    public class DragBeheivor: Behavior<UserControl>
    {
        bool isMouseClicked;
//        private Nullable<Point> dragStart = null;
        private MouseButtonEventHandler mouseLeftButtonDown;
        private MouseButtonEventHandler mouseLeftButtonUp;
        private MouseEventHandler mouseLeave;
        private Action<UIElement> enableDrag;

        public DragBeheivor()
        {
            Window _parent = Application.Current.MainWindow;
            mouseLeftButtonDown = (sender, args) => {
                isMouseClicked = true; 
            };
            mouseLeftButtonUp = (sender, args) => {
                isMouseClicked = false;
            };
            mouseLeave = (sender, args) => {
                if (isMouseClicked)
                {
                    DataObject data = new DataObject();
                    data.SetData(typeof(ShapeViewModel),this.AssociatedObject.DataContext);
                    DragDrop.DoDragDrop(this.AssociatedObject,
                            data,
                            DragDropEffects.Move);
                }
                isMouseClicked = false;
            };
            enableDrag = (element) => {
                element.MouseLeftButtonDown += mouseLeftButtonDown;
                element.MouseLeave += mouseLeave;
                element.MouseLeftButtonUp += mouseLeftButtonUp;
            };

        }

        protected override void OnAttached()
        {
            base.OnAttached();
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
