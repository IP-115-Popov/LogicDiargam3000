using DynamicData.Binding;
using System.Collections.ObjectModel;
using System.Linq;

namespace LogicDiagram3000.Models.logicChip
{
    public class Scheme : ChipToIn
    {
        private string name;
        private ObservableCollection<object> canvasList;
        public Scheme()
        {
            name = "Схема";
            canvasList = new ObservableCollection<object>();
        }
        protected override void Out1()
        {
            //if (TiedToOut1Chip != null && CanvasList != null)
            //{
            //    int rezShame;
            //    InChip in1Schame = (InChip)(CanvasList.FirstOrDefault(x => x is InChip));
            //    InChip in2Schame = (InChip)(CanvasList.FirstOrDefault(x => (x is InChip && x != in1Schame)));
            //    in1Schame.IsSignalTrue = In1.ToString();
            //    in2Schame.IsSignalTrue = In2.ToString();
            //    IndicatorChip out1Schame = (IndicatorChip)(CanvasList.FirstOrDefault(x => (x is IndicatorChip)));
            //    rezShame = out1Schame.In1;
            //    TiedToOut1Chip.In1 = rezShame;
            //}             
        }
        public ObservableCollection<object> CanvasList
        {
            get => canvasList;
            set => SetAndRaise(ref canvasList, value);
        }
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
    }
}
