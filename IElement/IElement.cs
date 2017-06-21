using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Elements
{
    public interface IElement
    {
        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Численное значение элемента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Расчет импеданса элемента
        /// </summary
        /// <param name="frequency">Частота сигнала </param>
        /// <returns> Комплексное сопротивление </returns>
        Complex CalculateZ(double frequency);
    }
}
