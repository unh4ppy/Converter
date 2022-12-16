using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    public class Speed : IValue
    {
        private string _valueName = "Скорость";
        public string GetValueName()
        {
            return _valueName;
        }

        private Dictionary<string, double> _coef = new Dictionary<string, double>()
        {
            {"Км в час", 3600 },
            {"Метры в секунду", 1 },
            {"Километры в секунду", 1000 },
        };

        public Dictionary<string, double> GetCoefficients()
        {
            return _coef;
        }
    }
}
