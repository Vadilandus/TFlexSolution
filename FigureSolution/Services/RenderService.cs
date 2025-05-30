﻿using FigureSolution.Interfaces;
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
        protected Dictionary<IDrawable, UIElement> FigureMap = new Dictionary<IDrawable, UIElement>();
        

        /// <summary>
        /// Отрисовка UIElement в canvas.
        /// </summary>
        /// <param name="Figure">Объект геометрической фигуры</param>
        /// <returns>Возвращает отрисованный UIElement</returns>
        void IDrawService.Draw(IDrawable drawable)
        {
            UIElement DrawedFigure = drawable.CreateVisualUIElement();

            Canvas.SetLeft(DrawedFigure, drawable.X);
            Canvas.SetTop(DrawedFigure, drawable.Y);
            canvas.Children.Add(DrawedFigure);

            FigureMap[drawable] = DrawedFigure;
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
        void IRemovable.Remove(IDrawable drawable)
        {
            if (FigureMap.TryGetValue(drawable, out var uIElement))
            {
                canvas.Children.Remove(uIElement);
                FigureMap.Remove(drawable);
            }
        }
    }
}
