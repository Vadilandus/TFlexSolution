using System.Windows;

namespace FigureSolution.Interfaces
{
    public interface IDrawable
    {
        /// <summary>
        /// Создает UIElement геометрической фигуры для использования в WPF.
        /// </summary>
        UIElement CreateVisualUIElement();
    }
}
