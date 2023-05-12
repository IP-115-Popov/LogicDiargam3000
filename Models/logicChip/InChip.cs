using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class InChip : ChipToIn
    {
        private string isSignalTrue;
        public InChip()
        {
            IsSignalTrue = "0";
        }
        public string? TupeChip
        {
            get => "InChip";
        }
        protected override int OutSignal() => in1Signal;
        public string IsSignalTrue
        {
            get => isSignalTrue;
            set
            {
                  if (isSignalTrue != "") In1Signal(Convert.ToInt32(isSignalTrue));
            //    //(base.OutSignalHandlerNotify)?.Invoke(Convert.ToInt32(IsSignalTrue));
                SetAndRaise(ref isSignalTrue, value);              
            }
        }
    }
}
