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
        const string RectangleModelName = "Rectangle";
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double x, double y, double height, double width, string Name) : base(x, y)
        {
            this.Name = Name != null && Name != string.Empty ? Name : RectangleModelName;
            this.Height = height;
            this.Width = width;
        }


        /// <summary>
        /// Метод создания объекта на основе этого класса в объект UIElement
        /// </summary>
        /// <returns>Возвращает объект класса UIElement</returns>
        public override UIElement CreateVisualUIElement()
        {
            int StrokeThickness = 1;
            return new System.Windows.Shapes.Rectangle
            {
                Width = Width,
                Height = Height,
                Stroke = Brushes.Black,
                StrokeThickness = StrokeThickness,
            };
        }
    }
}
