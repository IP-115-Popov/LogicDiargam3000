using Avalonia;
using DynamicData.Binding;
using LogicDiagram3000.Models.logicChip;
using System;

namespace LogicDiagram3000.Models.Connectors
{
    public class Connector : AbstractNotifyPropertyChanged
    {
        public Connector()
        {
            TimeSpan timeOfUtcDay = DateTime.UtcNow.TimeOfDay;
            double seconds = timeOfUtcDay.TotalSeconds;
            Id = Convert.ToInt32(seconds * 10000);
            IdIn1 = 0;
            IdOut1 = 0;
        }

        //Save
        public int Id { get; set; }
        public int IdIn1 { get; set; }
        public int IdOut1 { get; set; }
        //
        protected int in1;
        public ChipToIn TiedToOut1Chip { get; set; }
        public ChipToIn TiedToIn1Chip { get; set; }
        public int In1 
        {
            get => in1;
            set
            {
                SetAndRaise(ref in1, value);
                Out1();
            }
        }
        public void Out1()
        {
            if (TiedToOut1Chip != null)
            {
                if (TiedToOut1Chip.TiedToIn1Chip == this) TiedToOut1Chip.In1 = In1;
                if (TiedToOut1Chip.TiedToIn2Chip == this) TiedToOut1Chip.In2 = In1;
            }
        }

        private Point startPoint;
        private Point endPoint;
        protected bool isFocused;
        public bool IsFocused
        {
            get => isFocused;
            set => SetAndRaise(ref isFocused, value);
        }
        public string? TupeChip
        {
            get => "Connector";
        }
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                SetAndRaise(ref startPoint, value);
            }
        }
        public Point EndPoint
        {
            get => endPoint;
            set
            {
                SetAndRaise(ref endPoint, value);
            }
        }
        public void ChangeStartPoint(Point dPoint)
        {
            this.StartPoint += dPoint;
        }
        public void ChangeEndPoint(Point dPoint)
        {
            this.EndPoint += dPoint;
        }
        public void ClearBindings(ChipToIn? a)
        {
            if (TiedToIn1Chip != null && TiedToIn1Chip != a)
            {
                if (TiedToIn1Chip.TiedToOut1Chip != this) TiedToIn1Chip.TiedToOut1Chip = null;
                if (TiedToIn1Chip.TiedToIn1Chip != this) TiedToIn1Chip.TiedToIn1Chip = null;
                if (TiedToIn1Chip.TiedToIn2Chip != this) TiedToIn1Chip.TiedToIn2Chip = null;
            }
            if (TiedToOut1Chip != null && TiedToIn1Chip != a)
            {
                if (TiedToOut1Chip.TiedToOut1Chip != this) TiedToIn1Chip.TiedToOut1Chip = null;
                if (TiedToOut1Chip.TiedToIn1Chip != this) TiedToIn1Chip.TiedToIn1Chip = null;
                if (TiedToOut1Chip.TiedToIn2Chip != this) TiedToIn1Chip.TiedToIn2Chip = null;
            }
        }
        public void Dispose()
        {         
            TiedToOut1Chip = null;
            TiedToIn1Chip = null;
        }
    }
}
