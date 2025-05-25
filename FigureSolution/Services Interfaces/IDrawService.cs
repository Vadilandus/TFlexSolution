using FigureSolution.Model;
using System.Windows;

namespace FigureSolution.Services
{
    public interface IDrawService
    {
        /// <summary>
        /// Отрисовка UIElement в canvas.
        /// </summary>
        /// <param name="Figure">Объект геометрической фигуры</param>
        /// <returns>Возвращает отрисованный UIElement</returns>
        void Draw(BaseFigure Figure);
    }
}
