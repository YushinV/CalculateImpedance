using System;
using System.Numerics;

namespace Elements
{
    /// <summary>
    /// Класс конденсатора
    /// </summary>
    public class Capacitor : IComponent
    {
        /// <summary>
        /// Конструктор конденсатора
        /// </summary>
        /// <param name="name">уникальное имя конденсатора</param>
        /// <param name="value">емкость конденсатора</param>
        public Capacitor(string name, double value)
        {
            Name = name;
            Value = value;
        }
        #region локальные переменные класса

        /// <summary>
        /// Уникальное имя конденсатора 
        /// </summary>
        private string _name;

        /// <summary>
        /// Емкость конденсатора
        /// </summary>
        private double _value;

        #endregion

        #region свойства класса
        /// <summary>
        /// Аксессор получения имени конденсатора
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
        /// Аксессор получения емкости конденсатора
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

        #endregion

        #region методы класса

        /// <summary>
        /// Расчет комплексного сопротивления конденсатора
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            Complex result = new Complex(0, -1 / (2 * Math.PI * frequency * _value));
            return result;
        }

        #endregion
    }
}