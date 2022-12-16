using ConverterLib.Values;
using System.Reflection;

namespace ConverterLib
{
    public class Converter
    {
        public Converter()
        {
            SetValuesList();
        }
        /// <summary>
        /// Список физических величин
        /// </summary>
        private static List<IValue> _physicValues = new List<IValue>();
        
        private static void SetValuesList()
        {
            Assembly asm = Assembly.LoadFrom("ValuesLib.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if ((type.IsInterface == false) && (type.IsAbstract == false) && (type.GetInterface("IValue") != null))
                {
                    IValue value = (IValue)Activator.CreateInstance(type);
                    _physicValues.Add(value);
                }
            }
        }
        /// <summary>
        /// Метод возвращает список физических величин, реализованных в приложении
        /// </summary>
        /// <returns>Списко физических величин</returns>
        public List<string> GetPhysicValuesList()
        {
            List<string> physicValueList = new List<string>();
            foreach (IValue value in _physicValues)
            {
                physicValueList.Add(value.GetValueName());
            }
            return physicValueList;
        }
        private void SetIValue(string valueName)
        {
            foreach (var value in _physicValues)
            {
                if (value.GetValueName() == valueName)
                {
                    _value = value;
                }
                if (_value == null)
                {
                    throw new Exception("Ошибка! В библиотеки нет такой величины");
                }
            }
        }
        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <param name="physicValue">Наименовани физической величены</param>
        /// <returns>список единиц измерения</returns>
        public List<string> GetMeassureList(string physicValue)
        {
            SetIValue(physicValue);
            return _value.GetMeassureList();
        }
        private IValue _value;
        /// <summary>
        /// Возвращает конвертированное значение
        /// </summary>
        /// <param name="physicValue">Физическая величина</param>
        /// <param name="value">Значение</param>
        /// <param name="from">Из каких ед измерения</param>
        /// <param name="to">в какие ед измерения</param>
        /// <returns>конвертированное значение</returns>
        public double GetConvertedValue(string physicValue,double value, string from, string to)
        {
            
            return _value.GetConvertedValue(physicValue, value, from, to); 
        }
       
    }
}