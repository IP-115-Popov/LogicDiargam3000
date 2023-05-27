using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class NotChip : ChipToIn
    {
        public string? TupeChip
        {
            get => "NotChip";
        }
        //protected override int OutSignal() => ~in1Signal;
        protected override void Out1()
        {
            if (TiedToOut1Chip != null)
                TiedToOut1Chip.In1 = ~In1;
        }
    }
}
