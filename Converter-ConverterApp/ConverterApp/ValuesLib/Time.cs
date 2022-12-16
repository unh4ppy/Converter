using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    public class Time : IValue
    {
        /// <summary>
        /// Список единиц измерения
        /// </summary>
        private List<string> _measureList = new List<string>()
        {
            "Секунды",
            "Минуты",
            "Часы",
            "Милисекунды"
        };
        private string _valueName = "Время";
        private double _value;
        private string _from;
        private string _to;

     /// <summary>
     /// Вщзвращает конвертированное значение
     /// </summary>
     /// <param name="physicValue">Физическая величина</param>
     /// <param name="value">значение</param>
     /// <param name="from">из каких ед измерения</param>
     /// <param name="to">в какие ед измерения</param>
     /// <returns>конвертированное значение</returns>
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
        /// Перевод в СИ
        /// </summary>
        public void ToSI()
        {
            switch(_from)
            {
                case "Минуты":
                    _value *= 60;
                    break;

                case "Часы":
                    _value *= 3600;
                    break;

                case "Милисекунды":
                    _value /=1000 ;
                    break;

                case "Секунды":
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
                case "Минуты":
                    _value /= 60;
                    break;
                case "Часы":
                    _value /= 3600;
                    break;

                case "Милисекунды":
                    _value *= 1000;
                    break;
                case "Cекунды":
                    _value += 0;
                    break;

            }
            
        }
        /// <summary>
        /// Возвращает список единиц измерения
        /// </summary>
        /// <returns>Список единиц измерения</returns>
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
