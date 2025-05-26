using System;
using System.Windows;
using System.Windows.Media;

namespace FigureSolution.Model
{
    /// <summary>
    /// Класс Треугольника, наследует Базовую геом. Фигуру
    /// </summary>
    public class Triangle : BaseFigure
    {
        public override string Name { get; set; }
        public double FirstSide { get; set; } 
        public double SecondSide { get; set; } 
        public double ThirdSide { get; set; }


        public Triangle(double x, double y, double firstSide, double secondSide, double thirdSide, string Name) : base(x, y)
        {
            this.Name = Name == null ? "Triangle" : Name;
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
            this.ThirdSide = thirdSide;
        }


        /// <summary>
        /// Метод создания объекта на основе этого класса в объект UIElement
        /// </summary>
        /// <returns>Возвращает объект класса UIElement</returns>
        public override UIElement CreateVisualUIElement()
        {
            var points = CalculateTrianglePoints();
            int StrokeThickness = 1;
            return new System.Windows.Shapes.Polygon
            {
                Points = points,
                Stroke = Brushes.Black,
                StrokeThickness = StrokeThickness,
            };
        }

        
        /// <summary>
        /// Рассчет вершин треугольника в Canvas
        /// </summary>
        /// <returns>Коллекция PointCollection</returns>
        private PointCollection CalculateTrianglePoints()
        {
            double p = (FirstSide + SecondSide + ThirdSide) / 2;
            double area = Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
            double height = (2 * area) / FirstSide;

            return new PointCollection
        {
            // Левая вершина основания
            new Point(x, y),          
            // Правая вершина основания
            new Point(FirstSide, y),          
            // Верхняя вершина
            new Point(FirstSide / 2, height)  
        };
        }
    }
}
