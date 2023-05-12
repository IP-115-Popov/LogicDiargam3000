using Avalonia;
using Avalonia.Controls.Primitives;

namespace LogicDiagram3000.Views.logicScheme
{
    public class IndicatorChipView : TemplatedControl
    {
        public static readonly StyledProperty<string> IndicatorCheskProperty =
           AvaloniaProperty.Register<IndicatorChipView, string>("IndicatorChesk");
        public string IndicatorChesk
        {
            get => GetValue(IndicatorCheskProperty);
            set => SetValue(IndicatorCheskProperty, value);
        }
    }
}
