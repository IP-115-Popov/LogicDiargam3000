using Avalonia.Data.Converters;
using LogicDiagram3000.Models.logicChip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.Converters
{
    public class CanvasListToOutListConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ObservableCollection<IndicatorChip> OutList = new ObservableCollection<IndicatorChip>();
            foreach (var item in (ObservableCollection<object>)value)
            {
                if (item is IndicatorChip)
                {
                    OutList.Add((IndicatorChip)item);
                }
            }
            return OutList;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
