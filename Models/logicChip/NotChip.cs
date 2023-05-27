namespace LogicDiagram3000.Models.logicChip
{
    public class NotChip : ChipToIn
    {
        public string? TupeChip
        {
            get => "NotChip";
        }
        protected override void Out1()
        {
            if (TiedToOut1Chip != null)
                TiedToOut1Chip.In1 = ~In1;
        }
    }
}
