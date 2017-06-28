#region using
using System.Collections.Generic;
#endregion

namespace Elements
{
    /// <summary>
    /// Интерфейс подсхем
    /// </summary>
    public interface ICircuit: IComponent
    {
        #region свойства

        /// <summary>
        /// Свойство возвращающее примитивы схемы
        /// </summary>
        List<IPrimitive> Primitives { get; }

        List<IComponent> Components { get; set; }

        #endregion

        #region методы

        /// <summary>
        /// Добавление компонента
        /// </summary>
        /// <param name="component"></param>
        void AddComponent(IComponent component);

        /// <summary>
        /// Удаление компонента
        /// </summary>
        /// <param name="component"></param>
        void RemoveComponent(IComponent component);

        /// <summary>
        /// Метод для изменения компонента цепи
        /// </summary>
        /// <param name="oldComponent">элемент который нужно заменить</param>
        /// <param name="newComponent">элмент на который заменяют</param>
        void InsertComponent(IPrimitive oldComponent, IPrimitive newComponent);

        #endregion
    }

}