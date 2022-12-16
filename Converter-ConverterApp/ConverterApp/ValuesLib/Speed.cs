using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    public class Speed : IValue
    {
        /// <summary>
        /// Список единиц измерения
        /// </summary>
        private List<string> _measureList = new List<string>()
        {
            "Км в час",
            "Метры в секунду",
            "Км в секунду",
        };
        private string _valueName = "Скорость";

        private double _value;
        private string _from;
        private string _to;

        /// <summary>
        /// Возвращает конвертированное значение
        /// </summary>
        /// <param name="physicValue">Физическая величина</param>
        /// <param name="value">значение</param>
        /// <param name="from">из каких ед измерения</param>
        /// <param name="to">в какие ед измерения</param>
        /// <returns>конвертированое значение</returns>
        public double GetConvertedValue(string physicValue, double value, string from, string to)
        {
            foreach (string item in _measureList)
            {
                if (item == from || item == to)
                {
                    _value = value;
                    _from = from;
                    _to = to;
                    ToSI();
                    ToRequired();
                    return _value;

                }
            }

            return 00000;
        }
        /// <summary>
        /// Перевод в си
        /// </summary>
        public void ToSI()
        {
            switch (_from)
            {
                case "Километров в час":
                    _value /= 3.6;
                    break;

                case "Километров в секунду":
                    _value *= 1000;
                    break;

                case "Метров в секунду":
                    _value = _value;
                    break;

            }



        }
        /// <summary>
        /// Перевод в необходимые ед измерения
        /// </summary>
        public void ToRequired()
        {
            //преобразовать в необходимое
            switch (_to)
            {
                case "Километров в час":
                    _value *= 3.6;
                    break;

                case "Километров в секунду":
                    _value /= 1000;
                    break;

                case "Метров в секунду":
                    _value = _value;
                    break;


            }

        }
        /// <summary>
        /// Возвращает список единиц измерения
        /// </summary>
        /// <returns>список единиц измерения</returns>
        public List<string> GetMeassureList()
        {
            return _measureList;
        }
        public string GetValueName()
        {
            return _valueName;
        }
    }
}
