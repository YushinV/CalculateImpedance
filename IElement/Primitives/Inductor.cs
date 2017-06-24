using System;
using System.Numerics;

namespace Elements
{
    /// <summary>
    /// Класс катушки индуктивности
    /// </summary>
    public class Inductor : IComponent
    {
        /// <summary>
        /// Конструктор конденсатора
        /// </summary>
        /// <param name="name">уникальное имя конденсатора</param>
        /// <param name="value">емкость конденсатора</param>
        public Inductor(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #region локальные переменные класса

        /// <summary>
        /// Уникальное имя катушки 
        /// </summary>
        private string _name;

        /// <summary>
        /// Индуктивность катушки
        /// </summary>
        private double _value;

        #endregion

        #region свойства класса
        /// <summary>
        /// Аксессор получения имени катушки
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
        /// Аксессор получения индуктивности катушки
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
                    throw new ArgumentException("Некорректно введена индуктивность катушки");
                }
                _value = value;
            }
        }

        #endregion

        #region методы класса
        
        /// <summary>
        /// Расчет комплексного сопротивления катушки индуктивности
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            Complex resistance = new Complex(0, 2 * Math.PI * frequency * _value);
            return resistance;
        }

        #endregion
    }
}