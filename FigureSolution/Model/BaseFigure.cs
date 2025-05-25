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
        /// <param name="deltaX">На какое число по оси X</param>
        /// <param name="deltaY">На какое число по оси Y</param>
        public virtual void MoveTo(double deltaX, double deltaY)
        {
            this.x += deltaX;
            this.y += deltaY;
        }


        /// <summary>
        /// Абстрактный метод создания UIElement
        /// </summary>
        /// <returns>Возвращается объект класса UIElement</returns>
        abstract public UIElement CreateVisualUIElement();
    }
}
