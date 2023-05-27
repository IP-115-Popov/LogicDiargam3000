using DynamicData.Binding;
using LogicDiagram3000.Models.Connectors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public abstract class ChipToIn : AbstractNotifyPropertyChanged, IDisposable
    {
        //new Lojic 
        //protected object tiedToOut1Chip;
        //protected object tiedToIn1Chip;
        //protected object tiedToIn2Chip;
        protected int in1;
        protected int in2;
        public int EntryNumberForFiling { get; set; }
        public Connector TiedToOut1Chip { get; set; }
        public Connector TiedToIn1Chip { get; set; }
        public Connector TiedToIn2Chip { get; set; }
        public int In1
        { 
            get => in1;
            set
            {
                //in1 = value;
                SetAndRaise(ref in1, value);
                Out1();
            }
        }
        public int In2
        {
            get => in2;
            set
            {
                //in2 = value;
                SetAndRaise(ref in2, value);
                Out1();
            }
        }
        protected virtual void Out1()
        {
            if (TiedToOut1Chip != null)
                TiedToOut1Chip.In1 = 0;
        }
        //
        protected bool isFocused;
        protected string? margin;
        protected string? oldMargin;
        protected int width;
        protected int height;

        public ChipToIn()
        {
            EntryNumberForFiling = 0;
            In1= 0;
            In2= 0;

            //In1SignalProperty = 0;
            //In1SignalProperty = 0;
        }
        public bool IsFocused
        {
            get => isFocused;
            set
            {
               if (isFocused != value) SetAndRaise(ref isFocused, value);
            }
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
        //protected int in1Signal;
       // protected int in2Signal;
        public void Dispose()
        {
            //OutSignalHandlerNotify = null;
        }
        //public void In1Signal(int value)
        //{
        //    In1SignalProperty = value;
        //    OutSignalHandlerNotify?.Invoke(OutSignal());
        //}
        //public void In2Signal(int value)
        //{
        //    In2SignalProperty = value;
        //    OutSignalHandlerNotify?.Invoke(OutSignal());
        //}
        //protected virtual int OutSignal() => 0;
        //public delegate void OutSignalHandler(int a);
        //public event OutSignalHandler? OutSignalHandlerNotify;
        //protected int In1SignalProperty
        //{
        //    get => in1Signal;
        //    set => SetAndRaise(ref in1Signal, value);
       // }
       // protected int In2SignalProperty
        //{
        //    get => in2Signal;
         //   set => SetAndRaise(ref in2Signal, value);
        //}
    }
}
