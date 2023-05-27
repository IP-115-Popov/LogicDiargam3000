namespace LogicDiagram3000.Models.logicChip
{
    public class XorChip : ChipToIn
    {
        public string? TupeChip
        {
            get => "XorChip";
        }
        protected override void Out1()
        {
            if (TiedToOut1Chip != null)
                TiedToOut1Chip.In1 = In1 ^ In2;
        }
    }
}
