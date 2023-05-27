﻿using Avalonia;
using DynamicData.Binding;
using LogicDiagram3000.Models.logicChip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.Connectors
{
    public class Connector : AbstractNotifyPropertyChanged
    {
        //new Lojic 
        //protected ChipToIn tiedToOut1Chip;
        //protected ChipToIn tiedToIn1Chip;
        protected int in1;
        public ChipToIn TiedToOut1Chip { get; set; }
        public ChipToIn TiedToIn1Chip { get; set; }
        public int In1 
        {
            get => in1;
            set
            {
                SetAndRaise(ref in1, value);
                Out1();
            }
        }
        public void Out1()
        {
            if (TiedToOut1Chip != null)
            {
                if (TiedToOut1Chip.TiedToIn1Chip == this) TiedToOut1Chip.In1 = In1;
                if (TiedToOut1Chip.TiedToIn2Chip == this) TiedToOut1Chip.In2 = In1;
            }
        }


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
       // protected int in1Signal;
        //public void In1Signal(int value)
        //{
        //    in1Signal = value;
        //    OutSignalHandlerNotify?.Invoke(OutSignal());
       // }

       // protected virtual int OutSignal() => in1Signal;
        //public delegate void OutSignalHandler(int a);
       // public event OutSignalHandler? OutSignalHandlerNotify;
    }
}
