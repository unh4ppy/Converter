using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    public class Weight : IValue
    {
        private string _valueName = "Вес";
        public string GetValueName()
        {
            return _valueName;
        }

        private Dictionary<string, double> _coef = new Dictionary<string, double>()
        {
            {"Килограммы", 1},
            {"граммы", 0.001},
            {"Тонны", 1000},
            {"Центнеры", 100},
        };

        public Dictionary<string, double> GetCoefficients()
        {
            return _coef;
        }
    }
}
