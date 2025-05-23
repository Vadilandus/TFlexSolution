using FigureSolution.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FigureSolution.Services
{
    /// <summary>
    /// Класс который реализует инициализацию Canvas и действие в нем (Рисование и удаление нарисованных фигур)
    /// </summary>
    internal class RenderService : IRenderService
    {
        protected Canvas canvas;
        protected Dictionary<BaseFigure, UIElement> FigureMap = new Dictionary<BaseFigure, UIElement>();
        

        /// <summary>
        /// Отрисовка UIElement в canvas.
        /// </summary>
        /// <param name="Figure">Объект геометрической фигуры</param>
        /// <returns>Возвращает отрисованный UIElement</returns>
        public UIElement Draw(BaseFigure Figure)
        {
            UIElement DrawedFigure = Figure.Draw();

            Canvas.SetLeft(DrawedFigure, Figure.x);
            Canvas.SetTop(DrawedFigure, Figure.y);
            canvas.Children.Add(DrawedFigure);

            FigureMap[Figure] = DrawedFigure;

            return DrawedFigure;
        }


        /// <summary>
        /// Инициализация полотна(canvas)
        /// </summary>
        /// <param name="canvas">полотно для отрисовки</param>
        /// <exception cref="ArgumentNullException">Пустое значение ссылки - отсутствие canvas</exception>
        public void Initialize(Canvas canvas) => this.canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));


        /// <summary>
        /// Удаление геометрической фигуры с полотна
        /// </summary>
        /// <param name="figure">объект геометрической фигуры</param>
        public void Remove(BaseFigure figure)
        {
            if (FigureMap.TryGetValue(figure, out var uIElement))
            {
                canvas.Children.Remove(uIElement);
                FigureMap.Remove(figure);
            }
        }
    }
}
