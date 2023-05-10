using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LogicDiagram3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<object> canvasList;
        public ObservableCollection<object> CanvasList
        {
            get => canvasList;
            set => this.RaiseAndSetIfChanged(ref canvasList, value);
        }

    }
}
