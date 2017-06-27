#region using
using System;
using System.Numerics;
#endregion

namespace Elements
{
    /// <summary>
    /// Класс катушки индуктивности
    /// </summary>
    public class Inductor : IPrimitive
    {
        #region конструкторы
        /// <summary>
        /// Конструктор катушки
        /// </summary>
        /// <param name="name">уникальное имя катушки</param>
        /// <param name="value">индуктивность катушки</param>
        public Inductor(string name, double value)
        {
            Name = name;
            Value = value;
        }
        #endregion

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
        /// Аксессор получения типа компонента
        /// </summary>
        public PrimitiveType PrimitiveType
        {
            get
            {
                return PrimitiveType.Inductor;
            }
        }

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