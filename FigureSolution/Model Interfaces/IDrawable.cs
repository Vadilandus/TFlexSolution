using System.Windows;

namespace FigureSolution.Interfaces
{
    public interface IDrawable
    {
        double X { get; }
        double Y { get; }
        /// <summary>
        /// Создает UIElement геометрической фигуры для использования в WPF.
        /// </summary>
        UIElement CreateVisualUIElement();
    }
}
