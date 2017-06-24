#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
#endregion

namespace Elements
{
    /// <summary>
    /// Интерфейс представляющий примитивные электричесие компоненты, 
    /// и схемы состоящие из примитивных компонентов 
    /// </summary>
    public interface IComponent
    {
        #region методы
        /// <summary>
        /// Расчет импеданса
        /// </summary
        /// <param name="frequency">Частота сигнала </param>
        /// <returns> Комплексное сопротивление </returns>
        Complex CalculateZ(double frequency);
        #endregion
    }
}
