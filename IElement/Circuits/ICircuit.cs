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
        #region Свойства
    
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

        #endregion
    }   

}