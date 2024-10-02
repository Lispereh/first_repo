using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp5.Model;

namespace WpfApp5.ViewModel
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        private double _celsius;
        private double _fahrenheit;
        private Temperature _temperature;

        public ICommand ConvertToCelsiusCommand { get; set; }
        public ICommand ConvertToFahrenheitCommand { get; set; }

        public TemperatureViewModel()
        {
            _temperature = new Temperature();
            ConvertToCelsiusCommand = new DelegateCommand(ConvertToCelsius);
            ConvertToFahrenheitCommand = new DelegateCommand(ConvertToFahrenheit);
        }

        public void ConvertToCelsius(object obj)
        {
            Celsius = _temperature.FahrenheitToCelsius(Fahrenheit);
        }

        public void ConvertToFahrenheit(object obj)
        {
            Fahrenheit = _temperature.CelsiusToFahrenheit(Celsius);
        }

        public double Celsius
        {
            get
            {
                return _celsius;
            }
            set
            {
                if (_celsius != value)
                {
                    _celsius = value;
                    OnPropertyChanged(nameof(Celsius));
                    OnPropertyChanged(nameof(Fahrenheit));
                }
            }
        }

        public double Fahrenheit
        {
            get
            {
                return _fahrenheit;
            }
            set
            {
                if (_fahrenheit != value)
                {
                    _fahrenheit = value;
                    OnPropertyChanged(nameof(Fahrenheit));
                    OnPropertyChanged(nameof(Celsius));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}