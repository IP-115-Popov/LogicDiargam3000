using Avalonia;
using Avalonia.Controls.Primitives;

namespace LogicDiagram3000.Views.logicScheme
{
    public class InChipView : TemplatedControl
    {
        public static readonly StyledProperty<string> InCheskProperty =
           AvaloniaProperty.Register<InChipView, string>("InChesk");
        public string InChesk
        {
            get => GetValue(InCheskProperty);
            set => SetValue(InCheskProperty, value);
        }
    }
}
