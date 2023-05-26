using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using DynamicData;
using LogicDiagram3000.Models.Connectors;
using LogicDiagram3000.Models.logicChip;
using LogicDiagram3000.ViewModels;
using System;
using System.Linq;

namespace LogicDiagram3000.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (this.DataContext is MainWindowViewModel viewModel)
                {
                    foreach(var i in viewModel.CanvasList)
                    {
                        if (i is ChipToIn)
                            if (((ChipToIn)i).IsFocused == true)
                            {
                                viewModel.CanvasList.Remove(i);
                                break;
                            }
                        if (i is Connector)
                            if (((Connector)i).IsFocused == true)
                            {
                                viewModel.CanvasList.Remove(i);
                                break;
                            }
                    }
                }
            }
        }
        private Avalonia.Point pointerPressedEvent;
        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Control control)
            {
                if (control.DataContext is ChipToIn chipToIn)
                {

                    pointerPressedEvent = pointerPressedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());
                    if (pointerPressedEventArgs.Source is Ellipse)
                    {
                        if (this.DataContext is MainWindowViewModel viewModel)
                        {
                            Connector? conector = null;
                            conector = new Connector()
                            {
                                StartPoint = pointerPressedEvent,
                                EndPoint = pointerPressedEvent,
                            };
                            if (conector != null)
                            {
                                //к выходу  чипа а присоедин€ю вход конектора
                                chipToIn.OutSignalHandlerNotify += conector.In1Signal;


                                chipToIn.MarginHandlerNotify += conector.ChangeStartPoint;
                                viewModel.CanvasList.Add(conector);
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                        }
                    }
                    else
                    {
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerReleasedDragShape;
                    }
                }
                else if (control is Canvas)
                {
                    pointerPressedEvent = pointerPressedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());
                    if (this.DataContext is MainWindowViewModel viewModel)
                    {
                        viewModel.AddChipOnCanvas(pointerPressedEvent);
                    }
                }
            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Control control)
            {
                if (control.DataContext is ChipToIn chipToIn)
                {
                    Avalonia.Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());
                    chipToIn.Margin = (currentPointerPosition.X - chipToIn.Width / 2).ToString() + "," + (currentPointerPosition.Y - chipToIn.Height / 2).ToString();
                }
            }
        }
        private void PointerReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasedDragShape;
        }
        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Connector connector = viewModel.CanvasList[viewModel.CanvasList.Count - 1] as Connector;
                Avalonia.Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                connector.EndPoint = new Avalonia.Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);

            }
        }

        private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;


            var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault();

            var element = canvas.InputHitTest(pointerReleasedEventArgs.GetPosition(canvas));

            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is ChipToIn chipToIn)
                {
                    Connector connector = viewModel.CanvasList[viewModel.CanvasList.Count - 1] as Connector;
                    chipToIn.MarginHandlerNotify += connector.ChangeEndPoint;
                    //к выходу конектора присоедин€ю вход чипа 
                    if (chipToIn.port1free)
                    {
                        connector.OutSignalHandlerNotify += chipToIn.In1Signal;
                        chipToIn.port1free = false;
                    }
                    else if (chipToIn.port2free)
                    { 
                        connector.OutSignalHandlerNotify += chipToIn.In2Signal;
                        chipToIn.port2free = false;
                    }
                    return;
                }
            }
            else
            {
                viewModel.CanvasList.RemoveAt(viewModel.CanvasList.Count - 1);
            }
        }
        Avalonia.Point oldPoint = new Avalonia.Point(0, 0);
        private void PointerMoveDrawConectedLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Connector connector = viewModel.CanvasList[viewModel.CanvasList.Count - 1] as Connector;
                Avalonia.Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                connector.EndPoint = new Avalonia.Point(connector.EndPoint.X + oldPoint.X, connector.EndPoint.Y + oldPoint.Y);
                oldPoint = new Avalonia.Point(currentPointerPosition.X - oldPoint.X, currentPointerPosition.Y - oldPoint.Y);
            }
        }
    }
}
