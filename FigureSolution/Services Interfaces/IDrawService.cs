using FigureSolution.Interfaces;
using FigureSolution.Model;
using System.Windows;

namespace FigureSolution.Services
{
    public interface IDrawService
    {
        /// <summary>
        /// Отрисовка UIElement в canvas.
        /// </summary>
        /// <param name="drawable">Контракт, отрисовывающий UIElement для добавления в канвас</param>
        /// <returns>Возвращает отрисованный UIElement</returns>
        void Draw(IDrawable drawable);
    }
}
