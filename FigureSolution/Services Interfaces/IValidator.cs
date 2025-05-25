using System;

namespace FigureSolution.Services_Interfaces
{
    internal interface IValidator
    {
        bool IsCircleValid(double radius);
        bool IsRectangleValid(double width, double height);
        bool IsTriangleValid(double firstside, double secondside, double thirdside);

    }
}
