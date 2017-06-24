using System;
using System.Collections.Generic;
using System.Numerics;

namespace Elements
{
    /// <summary>
    /// Класс представляющий схему с элементами
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Список элементов, состоящие в схеме
        /// </summary>
        public List<IComponent> Elements;

        /// <summary>
        /// Расчет комплексного сопротивления цепи
        /// </summary>
        /// <param name="frequency">частота сигнала</param>
        /// <returns></returns>
        public Complex[] CalculateZ(double[] frequency)
        {
            Complex[] arrayImpedance = new Complex[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    arrayImpedance[i] += Elements[j].CalculateZ(frequency[i]);
                }
            }
            return arrayImpedance;
        }
    }
}