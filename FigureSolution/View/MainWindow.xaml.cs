using FigureSolution.Services;
using FigureSolution.ViewModel;
using System.Windows;

namespace FigureSolution
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var renderService = new RenderService();
            renderService.Initialize(MainCanvas);

            DataContext = new FigureViewModel(renderService);
        }
    }
}
