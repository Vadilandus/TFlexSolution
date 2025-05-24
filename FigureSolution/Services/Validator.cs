using FigureSolution.Services_Interfaces;

namespace FigureSolution.Services
{
    /// <summary>
    /// Класс Проверки перед созданием объектов фигур
    /// </summary>
    public class Validator : IValidator
    {
        /// <summary>
        /// наследуемый метод без параметров
        /// </summary>
        /// <returns>Значение false</returns>
        public bool IsValid()
        {
            return false;
        }


        /// <summary>
        /// Проверяет, чтобы значение радиуса было >= 0
        /// </summary>
        /// <param name="radius">Радиус окружности</param>
        /// <returns>true или false</returns>
        public bool IsValid(double radius)
        {
            return radius <= 0;
        }


        /// <summary>
        /// Проверяет, чтобы значения прямоугольника были>= 0.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool IsValid(double height, double width)
        {
            return height <= 0 || width <= 0;
        }

        internal bool IsValid(double firstSide, double secondSide, double thirdSide)
        {
            return (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0) || (firstSide + secondSide <= thirdSide || secondSide + thirdSide <= firstSide || thirdSide + firstSide <= secondSide);
        }
    }
}
