using System;
using System.Xml.Linq;

namespace LogicDiagram3000.Models.logicChip
{
    public class IndicatorChip : ChipToIn
    {
        private string name;
        public IndicatorChip()
        {
            TimeSpan timeOfUtcDay = DateTime.UtcNow.TimeOfDay;
            double seconds = timeOfUtcDay.TotalSeconds;
            Name = seconds.ToString();
            In1 = 0;
        }
        public Scheme PairantScheme { get; set; }
        protected override void Out1()
        {
            if (TiedToOut1Chip != null)
                TiedToOut1Chip.In1 = In1;
        }
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public string? TupeChip
        {
            get => "IndicatorChip";
        }
    }
}
