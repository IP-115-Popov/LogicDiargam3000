using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using LogicDiagram3000.Models.logicChip;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace LogicDiagram3000.Views
{
    public class SchameView : TemplatedControl
    {
        public static readonly StyledProperty<string> CastomTextProperty =
           AvaloniaProperty.Register<SchameView, string>("CastomText");
        public string CastomText
        {
            get => GetValue(CastomTextProperty);
            set => SetValue(CastomTextProperty, value);
        }

        public static readonly StyledProperty<ObservableCollection<InChip>> InListProperty =
           AvaloniaProperty.Register<SchameView, ObservableCollection<InChip>>("InList");
        public ObservableCollection<InChip> InList
        {
            get => GetValue(InListProperty);
            set => SetValue(InListProperty, value);
        }

        public static readonly StyledProperty<ObservableCollection<IndicatorChip>> OutListProperty =
           AvaloniaProperty.Register<SchameView, ObservableCollection<IndicatorChip>>("OutList");
        public ObservableCollection<IndicatorChip> OutList
        {
            get => GetValue(OutListProperty);
            set => SetValue(OutListProperty, value);
        }
    }
}
