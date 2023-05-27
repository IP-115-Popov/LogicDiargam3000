using LogicDiagram3000.Models.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class DemultiplexerChip : ChipToIn
    {
        public string? TupeChip
        {
            get => "DemultiplexerChip";
        }
        public Connector TiedToOut2Chip { get; set; }
        protected override void Out1()
        {
            if (In2 == 0)
            {
                if (TiedToOut1Chip != null)
                {
                    TiedToOut1Chip.In1 = In1;
                    TiedToOut2Chip.In1 = 0;

                }
            }
            else if (In2 == 1)
            {
                if (TiedToOut2Chip != null)
                {
                    TiedToOut1Chip.In1 = 0;
                    TiedToOut2Chip.In1 = In1;
                }
            }
        }
    }
}
