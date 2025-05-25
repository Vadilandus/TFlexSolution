using FigureSolution.Model;
using FigureSolution.Services;
using FigureSolution.Utils;
using NLog;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
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
        private BaseFigure _selectedFigure;
        private string _figureName;
        private double _x;
        private double _y;
        private double _width;
        private double _height;
        public double _FirstSide;
        public double _SecondSide;
        public double _ThirdSide;

        public BaseFigure SelectedFigure
        {
            get => _selectedFigure;
            set
            {   
                _selectedFigure = value;
                OnPropertyChanged(nameof(SelectedFigure));
            }
        }

        public double FirstSide
        {
            get => _FirstSide;
            set { _FirstSide = value; OnPropertyChanged(); }
        }
        public double SecondSide
        {
            get => _SecondSide;
            set { _SecondSide = value; OnPropertyChanged(); }
        }
        public double ThirdSide
        {
            get => _ThirdSide;
            set { _ThirdSide = value; OnPropertyChanged(); }
        }

        public string FigureName
        {
            get => _figureName;
            set { _figureName = value; OnPropertyChanged(); }
        }

        public double X
        {
            get => _x;
            set { _x = value; OnPropertyChanged(); }
        }

        public double Y
        {
            get => _y;
            set { _y = value; OnPropertyChanged(); }
        }

        public double Width
        {
            get => _width;
            set { _width = value; OnPropertyChanged(); }
        }

        public double Height
        {
            get => _height;
            set { _height = value; OnPropertyChanged(); }
        }

        public ObservableCollection<BaseFigure> baseFigures { get; set; } = new ObservableCollection<BaseFigure>();

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
            if (validator.IsValid(Width))
            {
                Circle circle = new Circle(X, Y, Width, FigureName);
                baseFigures.Add(circle);
                renderService.Draw(circle);
            }
            else
            {
                MessageBox.Show("Значение радиуса не назначено или равно 0. \nЗаполните или замените значение.");
            }

        }


        /// <summary>
        /// Метод реализации объекта геом. фигуры Треугольник, а также отрисовки его в Canvas
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        private void AddTriangle(object parameter)
        {
            if (validator.IsValid(FirstSide,SecondSide,ThirdSide))
            {
                Triangle triangle = new Triangle(X, Y, FirstSide, SecondSide, ThirdSide, FigureName);
                baseFigures.Add(triangle);
                renderService.Draw(triangle);
            }
            else
            {
                MessageBox.Show("Заполните значения для сторон треугольника, \nучитывая правила его создания. \nПравило: чтобы суммы двух любых сторон были больше !другой! третьей стороны");
            }
        }


        /// <summary>
        /// Метод реализации объекта геом. фигуры Квадрат, а также отрисовки его в Canvas
        /// </summary>
        /// <param name="parameter">параметры полотна</param>
        private void AddRectangle(object parameter)
        {
            if (validator.IsValid(Width,Height))
            {
                Rectangle rectangle = new Rectangle(X, Y, Height, Width, FigureName);
                baseFigures.Add(rectangle);
                renderService.Draw(rectangle);
            }
            else
            {
                MessageBox.Show("Заполните значения ширины и длины реальными существующими значениями.");
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
                baseFigures.Remove(SelectedFigure);
                SelectedFigure = null;
            }
        }
        #endregion

        #region Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
