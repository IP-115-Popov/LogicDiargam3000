using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.Connectors
{
    public class Connector : AbstractNotifyPropertyChanged
    {
        private Point startPoint;
        private Point endPoint;
        protected bool isFocused;
        public bool IsFocused
        {
            get => isFocused;
            set => SetAndRaise(ref isFocused, value);
        }
        public string? TupeChip
        {
            get => "Connector";
        }
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                SetAndRaise(ref startPoint, value);
            }
        }
        public Point EndPoint
        {
            get => endPoint;
            set
            {
                SetAndRaise(ref endPoint, value);
            }
        }
        public void ChangeStartPoint(Point dPoint)
        {
            this.StartPoint += dPoint;
        }
        public void ChangeEndPoint(Point dPoint)
        {
            this.EndPoint += dPoint;
        }
        //signal transmission
        protected int in1Signal;
        public void In1Signal(int value)
        {
            in1Signal = value;
            OutSignalHandlerNotify?.Invoke(OutSignal());
        }

        protected virtual int OutSignal() => in1Signal;
        public delegate void OutSignalHandler(int a);
        public event OutSignalHandler? OutSignalHandlerNotify;
    }
}
