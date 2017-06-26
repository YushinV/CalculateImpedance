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
        /// <param name="replacedComponent"></param>
        /// <param name="index"></param>
        void InsertComponent(IPrimitive replacedComponent, int index);



        #endregion

        #region свойства

        /// <summary>
        /// Свойство возвращающее примитивы схемы
        /// </summary>
        List<IPrimitive> Primitives { get; }
        #endregion



    }   

}