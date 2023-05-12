using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class AndChip : ChipToIn
    {
        public string? TupeChip
        {
            get => "AndChip";
        }
        protected override int OutSignal()
        {
            int rez = (in1Signal & in2Signal);
            return rez;
        }
            
    }
}
