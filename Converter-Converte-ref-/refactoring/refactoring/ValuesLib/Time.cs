using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    public class Time : IValue
    {
        private string _valueName = "Время";
        public string GetValueName()
        {
            return _valueName;
        }

        private Dictionary<string, double> _coef = new Dictionary<string, double>()
        {
            {"Секунды", 1},
            {"Милиекунды", 0.001},
            {"Минуты", 60},
            {"Часы", 3600}
        };

        public Dictionary<string, double> GetCoefficients()
        {
            return _coef;
        }
    }
}
