using FigureSolution.Interfaces;
using System.Windows;

namespace FigureSolution.Model
{
    /// <summary>
    /// Асбтрактный класс Геометрической фигуры.
    /// </summary>
    abstract public class BaseFigure : IDrawable
    {
        abstract public string Name { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public bool IsSelected { get; set; }
        public int Priority { get; set; }
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
