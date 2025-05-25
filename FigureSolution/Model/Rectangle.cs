using System;
using System.Windows;
using System.Windows.Media;

namespace FigureSolution.Model
{
    /// <summary>
    /// Класс Квадрата, наследует Базовую геом. Фигуру
    /// </summary>
    public class Rectangle : BaseFigure
    {
        public override string Name { get; set; }
        public double width { get; set; }
        public double height { get; set; }

        public Rectangle(double x, double y, double height, double width, string Name) : base(x, y)
        {
            this.Name = Name == null ? "Circle" : Name;
            this.height = height;
            this.width = width;
        }


        /// <summary>
        /// Абстрактный метод создания UIElement
        /// </summary>
        /// <returns>Возвращается объект класса UIElement</returns>
        public override UIElement CreateUIElement()
        {
            int StrokeThickness = 1;
            return new System.Windows.Shapes.Rectangle
            {
                Width = width,
                Height = height,
                Stroke = Brushes.Black,
                StrokeThickness = StrokeThickness,
            };
        }
    }
}
