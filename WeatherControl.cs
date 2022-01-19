using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_task6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty = DependencyProperty.Register(
            nameof(Temperature),
            typeof(int),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemperature)),
            new ValidateValueCallback(ValidateTemperature));

        private static bool ValidateTemperature(object value)
        {
            int x = (int)value;
            if (x >= -50 && x <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object startValue)
        {
            int x = (int)startValue;
            if (x >= -50 && x <= 50)
                return x;
            else
                return 0;
        }

        public int Temperature // Температура
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public string windDirection; // С этими что делать пока не понятно
        public int windSpeed;

        public enum Precipitation // Осадки
        {
            Cолнечно = 0,
            Oблачно = 1,
            Дождь = 2,
            Снег = 4
        }
    }
}
