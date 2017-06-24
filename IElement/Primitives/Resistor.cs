#region using
using System;
using System.Numerics;
#endregion

namespace Elements
{
    /// <summary>
    /// Класс резистора
    /// </summary>
    public class Resistor : IPrimitive
    {
        #region конструкторы
        /// <summary>
        /// Конструктор резистора
        /// </summary>
        /// <param name="name">уникальное имя конденсатора</param>
        /// <param name="value">емкость конденсатора</param>
        public Resistor(string name, double value)
        {
            Name = name;
            Value = value;
        }
        #endregion

        #region локальные переменные класса

        /// <summary>
        /// Уникальное имя резистора
        /// </summary>
        private string _name;

        /// <summary>
        /// Сопротивление резистора
        /// </summary>
        private double _value;

        #endregion

        #region свойства класса
        /// <summary>
        /// Аксессор получения имени резистора
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
        /// Аксессор получения сопротивления резистора
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
                    throw new ArgumentException("Некорректно введено сопротивление резистора");
                }
                _value = value;
            }
        }
        #endregion

        #region методы класса
        /// <summary>
        /// Расчет комплексного сопротивления резистора
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            Complex resistance = new Complex(_value, 0);
            return resistance;
        }
        #endregion
    }
}