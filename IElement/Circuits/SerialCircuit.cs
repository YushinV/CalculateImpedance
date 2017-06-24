#region using
using System;
using System.Numerics;
using System.Collections.Generic;
#endregion

namespace Elements
{
    /// <summary>
    /// Класс в котором хранятся компоненты соединенные последовательно
    /// </summary>
    public class SerialCircuit : ICircuit
    {
        #region локальные переменные класса

        /// <summary>
        /// Список для хранения элементов схемы
        /// </summary>
        private List<IComponent> _components = new List<IComponent>();

        /// <summary>
        /// Переменная для хранения резальтата расчета комплексного сопротивления
        /// </summary>
        Complex _resultCalculationZ;

        #endregion

        #region свойства класса

        /// <summary>
        /// Метод для добавления компонента в схему
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        /// <summary>
        /// Метод для удаления компонента из схемы
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        #endregion

        #region методы 
        
        /// <summary>
        /// Расчет комплексного сопротивления при последовательном соединении компонентов
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            foreach (var comp in _components)
            {
                _resultCalculationZ += comp.CalculateZ(frequency);
            }
            return _resultCalculationZ;
        }

        #endregion
    }
}