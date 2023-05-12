using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Reactive;
using System.Security.Claims;

namespace LogicDiagram3000.Views.logicScheme
{
    public class InChipView : TemplatedControl
    {
        public static readonly StyledProperty<bool> InCheskProperty =
           AvaloniaProperty.Register<InChipView, bool>("InChesk");
        public bool InChesk
        {
            get => GetValue(InCheskProperty);
            set => SetValue(InCheskProperty, value);
        }
    }
}
