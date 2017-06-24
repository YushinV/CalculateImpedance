using System.Collections.Generic;

namespace Elements
{
    /// <summary>
    /// Интерфейс подсхем
    /// </summary>
    public interface ICircuit: IComponent

    {
        /// <summary>
        /// Лист компонентов
        /// </summary>
        List<IComponent> Components { get; set; }

    }
}