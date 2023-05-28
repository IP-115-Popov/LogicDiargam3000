using DynamicData.Binding;
using System;
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
        public string? TupeChip
        {
            get => Name;
        }
        protected override void Out1()
        {           
        }

        public Scheme Clone()
        {
            Scheme clone = new Scheme();           
            clone.name = Name;
            clone.canvasList = CanvasList;
            return clone;
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
