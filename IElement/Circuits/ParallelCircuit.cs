#region
using System;
using System.Numerics;
using System.Collections.Generic;
#endregion

namespace Elements
{
    /// <summary>
    /// Класс в котором хранятся компоненты соединенные параллельно
    /// </summary>
    public class ParallelCircuit : ICircuit
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

        /// <summary>
        /// Возвращает примитивы содержащиеся в схеме
        /// </summary>
        public List<IPrimitive> Primitives
        {
            get
            {
                List<IPrimitive> listPrimitive = new List<IPrimitive>();
                foreach (var component in _components)
                {
                    if (component is IPrimitive)
                    {
                        listPrimitive.Add((IPrimitive)component);
                    }
                    if (component is ICircuit)
                    {
                        ICircuit circuit = (ICircuit)component;
                        foreach (var comp in circuit.Primitives)
                        {
                            listPrimitive.Add(comp);
                        }
                    }
                }
                return listPrimitive;
            }
        }

        #endregion

        #region методы

        /// <summary>
        /// Расчет комплексного сопротивления при параллельном соединении компонентов
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            foreach (var comp in _components)
            {
                _resultCalculationZ += 1 / comp.CalculateZ(frequency);
            }
            return 1 / _resultCalculationZ;
        }
        #endregion
    }
}