using FigureSolution.Interfaces;
using System.Windows;

namespace FigureSolution.Model
{
    /// <summary>
    /// Асбтрактный класс Геометрической фигуры.
    /// </summary>
    abstract public class BaseFigure : IDrawable
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public bool IsSelected { get; set; }
        public int Priority { get; set; }


        public BaseFigure (double x, double y)
        {
            this.X = x;
            this.Y = y;
        }


        /// <summary>
        /// передвижения фигуры
        /// </summary>
        /// <param name="deltaX">На какое число по оси X</param>
        /// <param name="deltaY">На какое число по оси Y</param>
        public virtual void MoveTo(double deltaX, double deltaY)
        {
            this.X += deltaX;
            this.Y += deltaY;
        }


        /// <summary>
        /// Абстрактный метод создания объекта на основе этого класса в объект UIElement
        /// </summary>
        /// <returns>Возвращает объект класса UIElement</returns>
        abstract public UIElement CreateVisualUIElement();
    }
}
