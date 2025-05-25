using FigureSolution.Model;

namespace FigureSolution.Interfaces
{
    public interface IRemovable
    {
        /// <summary>
        /// Удаление объекта геометрической фигуры с полотна canvas
        /// </summary>
        /// <param name="figure">Объект геометрической фигуры</param>
        void Remove(BaseFigure figure);
    }
}
