using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class IndicatorChip : ChipToIn
    {
        //private string outSignalMy;
        public IndicatorChip()
        {
            //OutSignalMy = "0";
            In1 = 0;
        }
        public string? TupeChip
        {
            get => "IndicatorChip";
        }

        //public string OutSignalMy
        //{
        //    get => In1.ToString();
        //    set
        //    {
        //        outSignalMy = In1.ToString();
        //        SetAndRaise(ref outSignalMy, value);
        //    }
        //}
    }
}
