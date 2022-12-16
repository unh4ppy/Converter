using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    public interface IValue
    {

        #region Методы для API
        /// <summary>
        /// Получение на стороне API конвертированной величины
        /// </summary>
        /// <param name="physicValue">Физическая величина</param>
        /// <param name="value">значение</param>
        /// <param name="from">из каких ед измерения</param>
        /// <param name="to">в какие ед измерения</param>
        /// <returns>конвертированное значение</returns>
        double GetConvertedValue(string physicValue, double value, string from, string to);
        /// <summary>
        /// Получение на стороне API списка единиц измерения
        /// </summary>
        /// <returns>Список единиц измерения</returns>
        List<string> GetMeassureList();
        #endregion
        #region Методы для реализации конвертации
        /// <summary>
        /// Перевод значений в систему СИ
        /// </summary>
        string GetValueName();
        void ToSI();
        /// <summary>
        /// Перевод значений в необходимые единицы измерения
        /// </summary>
        void ToRequired();
        #endregion
    }
}
