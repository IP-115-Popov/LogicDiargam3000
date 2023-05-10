using LogicDiagram3000.Models.logicChip;
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
        public MainWindowViewModel()
        {
            CanvasList = new ObservableCollection<object>();
            CanvasList.Add(new AndChip()
            {
                Margin = "100,100",
                Height = 128,
                Width = 128,
            });
        }
        public ObservableCollection<object> CanvasList
        {
            get => canvasList;
            set => this.RaiseAndSetIfChanged(ref canvasList, value);
        }

    }
}
