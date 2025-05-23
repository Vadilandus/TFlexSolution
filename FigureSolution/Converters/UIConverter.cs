using FigureSolution.Model;
using FigureSolution.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FigureSolution.Converters
{
    internal class UIConverter : IValueConverter
    {

        protected readonly IRenderService renderService;


        public UIConverter(IRenderService renderService) {  this.renderService = renderService; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BaseFigure Figure) return renderService.Draw(Figure);
            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
