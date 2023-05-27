using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
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
    }
}
