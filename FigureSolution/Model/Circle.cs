using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FigureSolution.Model
{
    /// <summary>
    /// Класс Круга, наследует Базовую геом. Фигуру
    /// </summary>
    public class Circle : BaseFigure
    {
        public double Radius { get; set; }
        public override string Name { get; set; }

        public Circle(double x, double y, double radius, string Name) : base(x, y)
        {
            this.Radius = radius;
            this.Name = Name == null ? "Circle" : Name;
        }


        /// <summary>
        /// Абстрактный метод создания объекта на основе этого класса в объект UIElement
        /// </summary>
        /// <returns>Возвращает объект класса UIElement</returns>
        public override UIElement CreateVisualUIElement()
        {
            double Diametr = Radius * 2;
            int StrokeThickness = 1;

            return new Ellipse
            {
                Width = Diametr,
                Height = Diametr,
                Stroke = Brushes.Black,
                StrokeThickness = StrokeThickness,
            };
        }
    }
}
