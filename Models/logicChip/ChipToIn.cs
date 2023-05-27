using DynamicData.Binding;
using LogicDiagram3000.Models.Connectors;
using System;

namespace LogicDiagram3000.Models.logicChip
{
    public abstract class ChipToIn : AbstractNotifyPropertyChanged, IDisposable
    {
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
                SetAndRaise(ref in1, value);
                Out1();
            }
        }
        public int In2
        {
            get => in2;
            set
            {
                SetAndRaise(ref in2, value);
                Out1();
            }
        }
        protected virtual void Out1()
        {
            if (TiedToOut1Chip != null)
                TiedToOut1Chip.In1 = 0;
        }
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
        public void ClearBindings()
        {
            if (TiedToOut1Chip != null) TiedToOut1Chip.Dispose();
            if (TiedToIn1Chip != null) TiedToIn1Chip.Dispose();
            if (TiedToIn2Chip != null) TiedToIn2Chip.Dispose();
        }
        public void Dispose()
        {           
            TiedToOut1Chip = null;
            TiedToIn1Chip = null;
            TiedToIn2Chip = null;
        }
    }
}
