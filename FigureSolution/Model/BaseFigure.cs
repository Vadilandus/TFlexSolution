using FigureSolution.Interfaces;
using System.Windows;

namespace FigureSolution.Model
{
    /// <summary>
    /// Асбтрактный класс Геометрической фигуры.
    /// </summary>
    abstract public class BaseFigure : IDrawable
    {
        abstract public string Name { get; protected set; }
        public double x { get; protected set; } = 0;
        public double y { get; protected set; } = 0;
        public bool IsSelected { get; protected set; } = false;
        public int Priority { get; protected set; }
        protected BaseFigure (double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        /// <summary>
        /// передвижения фигуры
        /// </summary>
        /// <param name="newX">На какое число по оси X</param>
        /// <param name="newY">На какое число по оси Y</param>
        public virtual void MoveTo(double newX, double newY)
        {
            this.x += newX;
            this.y += newY;
        }


        /// <summary>
        /// Абстрактный метод создания UIElement
        /// </summary>
        /// <returns>Возвращается объект класса UIElement</returns>
        abstract public UIElement Draw();
    }
}
