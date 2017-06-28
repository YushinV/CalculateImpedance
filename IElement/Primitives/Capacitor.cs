#region using
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;
#endregion

namespace Elements
{
    /// <summary>
    /// Класс конденсатора
    /// </summary>
    public class Capacitor : IPrimitive
    {
        #region конструкторы
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
        #endregion

        #region локальные переменные класса

        /// <summary>
        /// Уникальное имя конденсатора 
        /// </summary>
        private string _name;

        /// <summary>
        /// Емкость конденсатора
        /// </summary>
        private double _value;

        private Image _image = Image.FromFile(@"C:\Users\akun9\Documents\Visual Studio 2017\" + 
            @"Projects\IElement\IElement\Primitives\Image\Capacitor.bmp");

        #endregion

        #region свойства класса

        /// <summary>
        /// Аксессор получения типа компонента
        /// </summary>
        public PrimitiveType PrimitiveType
        {
            get
            {
                return PrimitiveType.Capacitor;
            }
        }

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

        public Image Image
        {
            get
            {
                return _image;
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