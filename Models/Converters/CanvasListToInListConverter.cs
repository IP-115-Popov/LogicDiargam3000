using Avalonia.Data.Converters;
using DynamicData;
using LogicDiagram3000.Models.logicChip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.Converters
{
    public class CanvasListToInListConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ObservableCollection<InChip> InList = new ObservableCollection<InChip>();
            foreach(var item in (ObservableCollection<object>)value)
            { 
                if (item is InChip) 
                {
                    InList.Add((InChip)item);
                }
            }
            return InList;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
