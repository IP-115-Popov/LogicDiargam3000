﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.logicChip
{
    public class XorChip : ChipToIn
    {
        public string? TupeChip
        {
            get => "XorChip";
        }
        protected override int OutSignal() => (in1Signal ^ in2Signal);
    }
}
