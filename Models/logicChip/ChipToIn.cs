using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public abstract class ChipToIn : AbstractNotifyPropertyChanged
    {
        public bool port1free;
        public bool port2free;
        protected string? margin;
        protected string? oldMargin;
        protected int width;
        protected int height;
        public ChipToIn()
        {
            port1free = true;
            port2free = true;
            In1SignalProperty = 0;
            In1SignalProperty = 0;
        }
        public string? Margin
        {
            get => margin;
            set
            {
                //запоминаю прошлое положение
                oldMargin = margin;
                //изменяем положение на новое
                SetAndRaise(ref margin, value);
                //тригерим ивент оповешаюший конекторы об изменениях
                //вычесляем дельту
                MarginHandlerNotify?.Invoke(new Avalonia.Point(Avalonia.Point.Parse(margin).X - Avalonia.Point.Parse(oldMargin).X, Avalonia.Point.Parse(margin).Y - Avalonia.Point.Parse(oldMargin).Y));
            }
        }
        public int Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }
        public int Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }
        public delegate void MarginHandler(Avalonia.Point point);
        public event MarginHandler? MarginHandlerNotify;
        //signal transmission
        protected int in1Signal;
        protected int in2Signal;
        public void In1Signal(int value)
        {
            In1SignalProperty = value;
            OutSignalHandlerNotify?.Invoke(OutSignal());
        }
        public void In2Signal(int value)
        {
            In2SignalProperty = value;
            OutSignalHandlerNotify?.Invoke(OutSignal());
        }
        protected virtual int OutSignal() => 0;
        public delegate void OutSignalHandler(int a);
        public event OutSignalHandler? OutSignalHandlerNotify;
        protected int In1SignalProperty
        {
            get => in1Signal;
            set => SetAndRaise(ref in1Signal, value);
        }
        protected int In2SignalProperty
        {
            get => in2Signal;
            set => SetAndRaise(ref in2Signal, value);
        }
    }
}
