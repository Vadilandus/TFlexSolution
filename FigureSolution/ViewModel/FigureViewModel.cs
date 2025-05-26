using FigureSolution.Model;
using FigureSolution.Services;
using FigureSolution.Utils;
using GalaSoft.MvvmLight.Messaging;
using NLog;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Rectangle = FigureSolution.Model.Rectangle;

namespace FigureSolution.ViewModel
{
    /// <summary>
    /// Класс описывающий логику работы с XAML разметкой
    /// </summary>
    public class FigureViewModel : INotifyPropertyChanged
    {
        static private Logger logger = LogManager.GetCurrentClassLogger();
        #region Fields
        private readonly IRenderService renderService;
        private BaseFigure selectedFigure;
        private string figureName;
        private double x;
        private double y;
        private double width;
        private double height;
        private double firstSide;
        private double secondSide;
        private double thirdSide;

        public BaseFigure SelectedFigure
        {
            get => selectedFigure; 
            set => SetProperty(ref selectedFigure, value);
        }

        public double FirstSide
        {
            get => firstSide;
            set => SetProperty(ref firstSide, value);
        }
        public double SecondSide
        {
            get => secondSide;
            set => SetProperty(ref secondSide, value);
        }
        public double ThirdSide
        {
            get => thirdSide;
            set => SetProperty(ref thirdSide, value);
        }

        public string FigureName
        {
            get => figureName;
            set => SetProperty(ref figureName, value);
        }

        public double X
        {
            get => x;
            set => SetProperty(ref x, value);
        }

        public double Y
        {
            get => y;
            set => SetProperty(ref y, value);
        }

        public double Width
        {
            get => width;
            set => SetProperty(ref width, value);
        }

        public double Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }

        public ObservableCollection<BaseFigure> BaseFigures { get; set; } = new ObservableCollection<BaseFigure>();

        public Validator validator = new Validator();
        #endregion

        public FigureViewModel(IRenderService renderService)
        {
            logger.Info("Запустился конструктор ViewModel");
            this.renderService = renderService;

            AddCircleCommand = new RelayCommand(AddCircle);
            AddRectangleCommand = new RelayCommand(AddRectangle);
            AddTriangleCommand = new RelayCommand(AddTriangle);
            RemoveFigureCommand = new RelayCommand(RemoveFigure, CanRemoveFigure);
            logger.Info("Конструктор закончил работу");
        }


        #region Commands

        public ICommand AddCircleCommand { get; }
        public ICommand AddRectangleCommand { get; }
        public ICommand AddTriangleCommand { get; }
        public ICommand RemoveFigureCommand { get; }

        #endregion

        #region Methods


        /// <summary>
        /// Подходит ли по условиям объект геометрической фигуры
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        /// <returns>Булевое значение, в случае, если поле != null</returns>
        private bool CanRemoveFigure(object parameter) => SelectedFigure != null;


        /// <summary>
        /// Метод реализации объекта геом фигуры Круг, а также отрисовки его в Canvas
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        private void AddCircle(object parameter)
        {
            if (validator.IsCircleValid(Width))
            {
                Circle circle = new Circle(X, Y, Width, FigureName);
                BaseFigures.Add(circle);
                renderService.Draw(circle);
            }
            else
            {
                Messenger.Default.Send(new ShowDialogMessage("Значение радиуса не назначено или равно 0. \nЗаполните или замените значение."));
            }

        }


        /// <summary>
        /// Метод реализации объекта геом. фигуры Треугольник, а также отрисовки его в Canvas
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        private void AddTriangle(object parameter)
        {
            if (validator.IsTriangleValid(FirstSide,SecondSide,ThirdSide))
            {
                Triangle triangle = new Triangle(X, Y, FirstSide, SecondSide, ThirdSide, FigureName);
                BaseFigures.Add(triangle);
                renderService.Draw(triangle);
            }
            else
            {
                Messenger.Default.Send(new ShowDialogMessage("Заполните значения для сторон треугольника, \nучитывая правила его создания. \nПравило: чтобы суммы двух любых сторон были больше !другой! третьей стороны"));
            }
        }


        /// <summary>
        /// Метод реализации объекта геом. фигуры Квадрат, а также отрисовки его в Canvas
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        private void AddRectangle(object parameter)
        {
            if (validator.IsRectangleValid(Width,Height))
            {
                Rectangle rectangle = new Rectangle(X, Y, Height, Width, FigureName);
                BaseFigures.Add(rectangle);
                renderService.Draw(rectangle);
            }
            else
            {
                Messenger.Default.Send(new ShowDialogMessage("Заполните значения ширины и длины реальными существующими значениями."));
            }
        }


        /// <summary>
        /// Метод удаления объекта геом. фигуры
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        private void RemoveFigure(object parameter)
        {
            if (SelectedFigure != null)
            {
                renderService.Remove(SelectedFigure);
                BaseFigures.Remove(SelectedFigure);
                SelectedFigure = null;
            }
        }
        #endregion

        #region Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
