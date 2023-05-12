using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class IndicatorChip : ChipToIn
    {
        private string outSignalMy;
        public IndicatorChip()
        {
            OutSignalMy = "0";
        }
        public string? TupeChip
        {
            get => "IndicatorChip";
        }

        public string OutSignalMy
        {
            get => in1Signal.ToString();
            set
            {
                outSignalMy = in1Signal.ToString();
                SetAndRaise(ref outSignalMy, value);
            }
        }
    }
}
