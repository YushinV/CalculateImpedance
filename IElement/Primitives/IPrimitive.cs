﻿namespace Elements
{
    /// <summary>
    /// Интерфейс представляющий примитивные электроческие элементы цепи
    /// </summary>
    public interface IPrimitive : IComponent
    {
        #region Свойства
        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Численное значение элемента
        /// </summary>
        double Value { get; set; }
        #endregion
    }
}