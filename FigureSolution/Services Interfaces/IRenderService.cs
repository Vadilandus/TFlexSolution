using FigureSolution.Interfaces;
using System.Windows.Controls;

namespace FigureSolution.Services
{
    public interface IRenderService : IRemovable, IDrawService
    {
        /// <summary>
        /// Инициализация полотна Canvas
        /// </summary>
        /// <param name="canvas">Возвращает объект Canvas</param>
        void Initialize(Canvas canvas);
    }
}
