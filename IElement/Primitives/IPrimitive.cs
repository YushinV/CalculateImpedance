#region using
using System.Collections.Generic;
using System.Drawing;
#endregion

namespace Elements
{
    /// <summary>
    /// Интерфейс представляющий примитивные электроческие элементы цепи
    /// </summary>
    public interface IPrimitive : IComponent
    {

        #region Свойства

        /// <summary>
        /// Тип компонента
        /// </summary>
        PrimitiveType PrimitiveType { get; }
        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Численное значение элемента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Получение рисунка
        /// </summary>
        Image Image { get; }
        #endregion
    }
}