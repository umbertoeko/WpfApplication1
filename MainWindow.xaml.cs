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
using WpfApplication1.Views;
using WpfApplication1.Beheivors;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Shape> shapeList;
        private int shapesCount;
        AdornerLayer aLayer;

        bool _isDown;
        bool _isDragging;
        bool selected = false;
        UIElement selectedElement = null;

        Point _startPoint;
        private double _originalLeft;
        private double _originalTop;

        public MainWindow()
        {
            InitializeComponent();
            shapeList = new List<Shape>();
            RectangleView newRect = new RectangleView();
//            UserControlCustomProperty.SetCanvasProperty(newRect,mainCanvas);
            newRect.mainCanvas = this.mainCanvas;
            mainCanvas.Children.Add(newRect);
/*
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Window1_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(DragFinishedMouseHandler);
            this.MouseMove += new MouseEventHandler(Window1_MouseMove);
            this.MouseLeave += new MouseEventHandler(Window1_MouseLeave);

            this.shapesCount = 0;
            mainCanvas.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(myCanvas_PreviewMouseLeftButtonDown);
            mainCanvas.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(DragFinishedMouseHandler);
*/
        }

        void myCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selected)
            {
                selected = false;
                if (selectedElement != null)
                {
                    aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                    selectedElement = null;
                }
            }

            if (e.Source != mainCanvas)
            {
                _isDown = true;
                _startPoint = e.GetPosition(mainCanvas);

                selectedElement = e.Source as UIElement;

                _originalLeft = Canvas.GetLeft(selectedElement);
                _originalTop = Canvas.GetTop(selectedElement);

                aLayer = AdornerLayer.GetAdornerLayer(selectedElement);
                aLayer.Add(new MyAdorner(selectedElement));
                selected = true;
                e.Handled = true;
            }
        }
        void Window1_MouseLeave(object sender, MouseEventArgs e)
        {
            StopDragging();
            e.Handled = true;
        }

        // Handler for drag stopping on user choise
        void DragFinishedMouseHandler(object sender, MouseButtonEventArgs e)
        {
            StopDragging();
            e.Handled = true;
        }

        // Method for stopping dragging
        private void StopDragging()
        {
            if (_isDown)
            {
                _isDown = false;
                _isDragging = false;
            }
        }

        // Hanler for providing drag operation with selected element
        void Window1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(mainCanvas).X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(mainCanvas).Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                    _isDragging = true;

                if (_isDragging)
                {
                    Point position = Mouse.GetPosition(mainCanvas);
                    double posY = position.Y - (_startPoint.Y - _originalTop);
                    double posX = position.X - (_startPoint.X - _originalLeft);
                    if (posY > 0 && posX > 0)
                    {
                        Canvas.SetTop(selectedElement, posY);
                        Canvas.SetLeft(selectedElement, posX);
                    }
                }
            }
        }

        void Window1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selected)
            {
                selected = false;
                if (selectedElement != null)
                {
                    aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                    selectedElement = null;
                }
            }
        }
        private void DrawShape(object sender, RoutedEventArgs e)
        {
            this.shapesCount++;
            int myValue = Convert.ToInt32(((Button)sender).Tag);
            string tmpName = "Shape__" + this.shapesCount;
            Shape el;
            switch (myValue)
            {
                case 0:
                    el = new Ellipse(tmpName);
                    break;
                case 1:
                    el = new Rectangle(tmpName);
                    break;
                case 2:
                    el = new Triangle(tmpName);
                    break;
                case 3:
                    el = new TextBlock(tmpName);
                    break;
                case 4:
                    el = new ImageBox(tmpName);
                    break;
                default: throw new Exception();
            }

            shapeButton myButton = new shapeButton(tmpName);
            this.shapesBar.Add(myButton);
            shapeList.Add(el);
            UIElement myShape = el.Draw();
            this.mainCanvas.Children.Add(myShape);
            myButton.CloseSignClicked += (send, eventArgs) =>
            {
                shapeList.Remove(el);
                if (myShape == selectedElement)
                {
                    selectedElement = null;
                    selected = false;
                }
                this.mainCanvas.Children.Remove(myShape);
                this.shapesBar.Remove(myButton);
            };
            myButton.SignClicked += (send, eventArgs) =>
            {
                if (selected)
                {
                    selected = false;
                    if (selectedElement != null)
                    {
                        aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                        selectedElement = null;
                    }
                }

                selectedElement = myShape as UIElement;

                _originalLeft = Canvas.GetLeft(selectedElement);
                _originalTop = Canvas.GetTop(selectedElement);

                aLayer = AdornerLayer.GetAdornerLayer(selectedElement);
                aLayer.Add(new MyAdorner(selectedElement));
                selected = true;
            }; 
        }

        private void ClearCanvas(object sender, RoutedEventArgs e)
        {
            this.mainCanvas.Children.Clear();
            shapeList.Clear();
            this.shapesBar.Clear();
            this.shapesCount = 0;
            selected = true;
            selectedElement = null;
        }

    }
}

