using Avalonia;
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
        private bool addChipDraw;
        private bool orChipDraw;
        private bool notChipDraw;
        private bool xorChipDraw;
        private bool demultiplexerChipDraw;
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
        public bool AddChipDraw
        {
            get => addChipDraw;
            set => this.RaiseAndSetIfChanged(ref addChipDraw, value);
        }
        public bool OrChipDraw
        {
            get => orChipDraw;
            set => this.RaiseAndSetIfChanged(ref orChipDraw, value);
        }
        public bool NotChipDraw
        {
            get => notChipDraw;
            set => this.RaiseAndSetIfChanged(ref notChipDraw, value);
        }
        public bool XorChipDraw
        {
            get => xorChipDraw;
            set => this.RaiseAndSetIfChanged(ref xorChipDraw, value);
        }
        public bool DemultiplexerChipDraw
        {
            get => demultiplexerChipDraw;
            set => this.RaiseAndSetIfChanged(ref demultiplexerChipDraw, value);
        }
        public void AddChipOnCanvas(Point A)
        {
            string AStrting = A.ToString();
            if (AddChipDraw) CanvasList.Add(new AndChip()
            {
                Margin = AStrting,
                Height = 128,
                Width = 128,
            });
            if (OrChipDraw) CanvasList.Add(new OrChip()
            {
                Margin = AStrting,
                Height = 128,
                Width = 128,
            });
            if (NotChipDraw) CanvasList.Add(new NotChip()
            {
                Margin = AStrting,
                Height = 128,
                Width = 128,
            });
            if (XorChipDraw) CanvasList.Add(new XorChip()
            {
                Margin = AStrting,
                Height = 128,
                Width = 128,
            });
            if (DemultiplexerChipDraw) CanvasList.Add(new DemultiplexerChip()
            {
                Margin = AStrting,
                Height = 128,
                Width = 128,
            });
        }
    }
}
