using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class DemultiplexerChip : ChipToIn
    {
        public int managerSignal;
        public DemultiplexerChip()
        {
            ManagerSignalProperty = 0;
        }
        public string? TupeChip
        {
            get => "DemultiplexerChip";
        }
        public int ManagerSignalProperty
        {
            get => managerSignal;
            set => SetAndRaise(ref managerSignal, value);
        }
        public void InSignal(int value)
        {
            In1SignalProperty = value;
            if (ManagerSignalProperty == 0)
            {
                Out1SignalHandlerNotify?.Invoke(OutSignal());
                Out2SignalHandlerNotify?.Invoke(0);
            }
            else if (ManagerSignalProperty == 1)
            {
                Out1SignalHandlerNotify?.Invoke(0);
                Out2SignalHandlerNotify?.Invoke(OutSignal());
            }
        }
        public void Manager(int value)
        {
            ManagerSignalProperty = value;
            InSignal(In1SignalProperty);
        }

        protected override int OutSignal() => in1Signal;
        public event OutSignalHandler? Out1SignalHandlerNotify;
        public event OutSignalHandler? Out2SignalHandlerNotify;
    }
}
