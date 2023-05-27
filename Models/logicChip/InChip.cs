using System;

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
        public string IsSignalTrue
        {
            get => isSignalTrue;
            set
            {
                SetAndRaise(ref isSignalTrue, value);
                if (isSignalTrue != "" && TiedToOut1Chip != null) TiedToOut1Chip.In1 = Convert.ToInt32(isSignalTrue);
            }
        }
    }
}
