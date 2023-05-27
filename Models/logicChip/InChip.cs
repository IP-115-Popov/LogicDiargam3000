using System;
using System.Xml.Linq;

namespace LogicDiagram3000.Models.logicChip
{
    public class InChip : ChipToIn
    {
        private string isSignalTrue;
        private string name;
        public InChip()
        {
            TimeSpan timeOfUtcDay = DateTime.UtcNow.TimeOfDay;
            double seconds = timeOfUtcDay.TotalSeconds;
            Name = seconds.ToString();
            IsSignalTrue = "0";
        }
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public string? TupeChip
        {
            get => "InChip";
        }
        public void Out1()
        {
            if (TiedToOut1Chip != null)
            {
                if (TiedToOut1Chip.TiedToIn1Chip == this) TiedToOut1Chip.In1 = In1;
            }
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
