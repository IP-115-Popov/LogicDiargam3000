using DynamicData.Binding;
using System.Collections.ObjectModel;

namespace LogicDiagram3000.Models.logicChip
{
    public class Scheme : AbstractNotifyPropertyChanged
    {
        private string name;
        private ObservableCollection<object> canvasList;
        public Scheme()
        {
            name = "Схема";
            canvasList = new ObservableCollection<object>();
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
