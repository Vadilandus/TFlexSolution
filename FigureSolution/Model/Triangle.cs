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
        public override string Name { get; protected set; }
        public Triangle(double x, double y, double firstSide, double secondSide, double thirdSide,string Name) : base(x, y)
        {
            this.Name = Name == null ? "Triangle" : Name;
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
            this.ThirdSide = thirdSide;
        }

        public double FirstSide { get; protected set; } = 3;
        public double SecondSide { get; protected set; } = 4;
        public double ThirdSide { get; protected set; } = 5;


        /// <summary>
        /// Абстрактный метод создания UIElement
        /// </summary>
        /// <returns>Возвращается объект класса UIElement</returns>
        public override UIElement Draw()
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
