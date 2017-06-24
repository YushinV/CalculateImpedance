using System;
using System.Numerics;
using System.Collections.Generic;

//TODO: переделать, value set
namespace Elements
{
    /// <summary>
    /// Класс в котором хранятся компоненты соединенные параллельно
    /// </summary>
    public class ParallelCircuit : ICircuit
    {
        #region локальные переменные класса

        /// <summary>
        /// Уникальное имя подсхемы
        /// </summary>
        private string _name;

        /// <summary>
        /// Значение подсхемы
        /// </summary>
        private double _value;

        private List<IComponent> _components;

        #endregion

        #region свойства класса
        /// <summary>
        /// Аксессор получения имени подсхемы
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Аксессор получения значения
        /// </summary>
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Некорректно введена емкость конденсатора");
                }
                _value = value;
            }
        }

        public List<IComponent> Components
        {
            get
            {
                return _components;
            }
            set
            {
                _components = value;
            }
        }

        #endregion

        Complex result = new Complex(0,0);
        /// <summary>
        /// Расчет комплексного сопротивления при параллельном соединении компонентов
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            foreach (var comp in Components)
            {
                result += 1 / comp.CalculateZ(frequency);
            }
            return 1 / result;
        }
    }
}