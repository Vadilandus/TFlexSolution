using FigureSolution.Services_Interfaces;

namespace FigureSolution.Services
{
    /// <summary>
    /// Класс Проверки перед созданием объектов фигур
    /// </summary>
    public class Validator : IValidator
    {
        /// <summary>
        /// Проверяет на правило для создания Круга
        /// </summary>
        /// <param name="radius">Радиус окружности</param>
        /// <returns>true в случае успеха</returns>
        public bool IsCircleValid(double radius)
        {
            return radius > 0;
        }


        /// <summary>
        /// Проверяет на правило для создания Прямоугольника
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns>true в случае успеха</returns>
        public bool IsRectangleValid(double width, double height)
        {
            return height > 0 || width > 0;
        }


        /// <summary>
        /// Проверяет на правила для создания треугольника
        /// </summary>
        /// <param name="firstside"></param>
        /// <param name="secondside"></param>
        /// <param name="thirdside"></param>
        /// <returns>true в случае успеха</returns>
        public bool IsTriangleValid(double firstside, double secondside, double thirdside)
        {
            return (firstside > 0 && secondside > 0 && thirdside > 0) && (firstside + secondside > thirdside && secondside + thirdside > firstside && thirdside + secondside > thirdside);
        }
    }
}
