using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversao
{
    public static class Converte
    {
        public static double ConverterCelsiusParaFarenheit(double celsius)
        {
            return celsius * 1.8 + 32;
        }
        public static double ConverterFarenheitParaCelsius(double farenheit)
        {
            return (farenheit - 32) / 1.8;
        }
    }
}

