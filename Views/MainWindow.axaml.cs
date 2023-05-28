using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
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
        private async void OnDoubleTapped(object? sender, RoutedEventArgs routedEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                viewModel.EditableScheme = viewModel.SelectedScheme;
            }
        }
        //Menu
        private void CreateProject(object sender, RoutedEventArgs eventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                viewModel.IsVisibleHelloView = false; 
                viewModel.IsVisibleProjectView = true;
            }
        }
        private void CreateSchame(object sender, RoutedEventArgs eventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                viewModel.SchemeList.Add(new Scheme());
            }
        }
        private async void LoadXml(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Load(path[0]);
                }
            }
        }
        private async void SaveXml(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Save(path);
                }
            }
        }
        private void Exit(object sender, RoutedEventArgs eventArgs)
        {
            this.Close();
        }
        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (this.DataContext is MainWindowViewModel viewModel)
                {
                    for (int i = 0; i < viewModel.CanvasList.Count; i++)
                    {
                        if (viewModel.CanvasList[i] is ChipToIn chipToIn)
                            if (chipToIn.IsFocused == true)
                            {   if (chipToIn is Scheme scheme)
                                {
                                    foreach(var item in scheme.CanvasList)
                                    {
                                        if (item is InChip inChip)
                                        {
                                            if (inChip.TiedToIn1Chip != null) inChip.TiedToIn1Chip.ClearBindings(inChip);
                                            viewModel.CanvasList.Remove(inChip.TiedToIn1Chip);
                                            inChip.TiedToIn1Chip = null;                                          
                                        }
                                        if (item is IndicatorChip indicatorChip)
                                        { 
                                            if (indicatorChip.TiedToOut1Chip != null) indicatorChip.TiedToOut1Chip.ClearBindings(indicatorChip);
                                            viewModel.CanvasList.Remove(indicatorChip.TiedToOut1Chip);
                                            indicatorChip.TiedToOut1Chip = null;
                                        }
                                    }
                                }
                                if (chipToIn.TiedToIn1Chip != null) chipToIn.TiedToIn1Chip.ClearBindings(chipToIn);
                                if (chipToIn.TiedToIn2Chip != null) chipToIn.TiedToIn2Chip.ClearBindings(chipToIn);
                                if (chipToIn.TiedToOut1Chip != null) chipToIn.TiedToOut1Chip.ClearBindings(chipToIn);
                                if (chipToIn is DemultiplexerChip demultiplexerChip)
                                    if (demultiplexerChip.TiedToOut2Chip != null) 
                                        demultiplexerChip.TiedToOut2Chip.ClearBindings(chipToIn);

                                viewModel.CanvasList.RemoveAt(i);
                                viewModel.CanvasList.Remove(chipToIn.TiedToIn1Chip);
                                viewModel.CanvasList.Remove(chipToIn.TiedToIn2Chip);
                                viewModel.CanvasList.Remove(chipToIn.TiedToOut1Chip);
                                if (chipToIn is DemultiplexerChip demultiplexerChip2) viewModel.CanvasList.Remove(demultiplexerChip2.TiedToOut2Chip);

                                chipToIn.Dispose();
                                chipToIn = null;
                                break;
                            }
                        if (viewModel.CanvasList[i] is Connector connector)
                            if (connector.IsFocused == true)
                            {
                                viewModel.CanvasList.RemoveAt(i);
                                connector.ClearBindings(null);
                                connector.Dispose();
                                connector = null;
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
                    if (pointerPressedEventArgs.Source is Ellipse ellipse)
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
                                    chipToIn.MarginHandlerNotify += conector.ChangeStartPoint;
                                    if (ellipse.Name == "Out1")
                                    {
                                        chipToIn.TiedToOut1Chip = conector;
                                        conector.TiedToIn1Chip = chipToIn;
                                    }
                                    else if (ellipse.Name == "Out2")
                                    {
                                        ((DemultiplexerChip)chipToIn).TiedToOut2Chip = conector;
                                        conector.TiedToIn1Chip = chipToIn;
                                    }
                                    else if (ellipse.Name == "In1")
                                    {
                                        conector.TiedToOut1Chip = chipToIn;
                                        chipToIn.TiedToIn1Chip = conector;
                                    }
                                    else if (ellipse.Name == "In2")
                                    {
                                        conector.TiedToOut1Chip = chipToIn;
                                        chipToIn.TiedToIn2Chip = conector;
                                    }
                                    else if (chipToIn is InChip inChip)
                                    {
                                        inChip.PairantScheme.MarginHandlerNotify += conector.ChangeStartPoint;
                                        conector.TiedToOut1Chip = inChip;
                                        inChip.TiedToIn1Chip = conector;
                                    }
                                    else if (chipToIn is IndicatorChip indicatorChip)
                                    {
                                        indicatorChip.PairantScheme.MarginHandlerNotify += conector.ChangeStartPoint;
                                        indicatorChip.TiedToOut1Chip = conector;
                                        conector.TiedToIn1Chip = indicatorChip;
                                    }
                                
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
                        if (ellipse.Name == "Out1")
                        {
                            chipToIn.TiedToOut1Chip = connector;
                            connector.TiedToIn1Chip = chipToIn;
                        }
                        else if (ellipse.Name == "Out2")
                        {
                            ((DemultiplexerChip)chipToIn).TiedToOut2Chip = connector;
                            connector.TiedToIn1Chip = chipToIn;
                        }
                        else if (ellipse.Name == "In1")
                        {
                            connector.TiedToOut1Chip = chipToIn;
                            chipToIn.TiedToIn1Chip = connector;
                        }
                        else if (ellipse.Name == "In2")
                        {
                            connector.TiedToOut1Chip = chipToIn;
                            chipToIn.TiedToIn2Chip = connector;
                        }
                        else if(chipToIn is InChip inChip)
                        {
                            inChip.PairantScheme.MarginHandlerNotify += connector.ChangeEndPoint;
                            connector.TiedToOut1Chip = inChip;
                            inChip.TiedToIn1Chip = connector;
                        }
                        else if (chipToIn is IndicatorChip indicatorChip)
                        {
                            indicatorChip.PairantScheme.MarginHandlerNotify += connector.ChangeEndPoint;
                            indicatorChip.TiedToOut1Chip = connector;
                            connector.TiedToIn1Chip = indicatorChip;
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