using FigureSolution.Services;
using FigureSolution.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
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
            Messenger.Default.Register<ShowDialogMessage>(this, message =>
            {
                var result = MessageBox.Show(message.Text);
            });
        }

    }

    internal class ShowDialogMessage
    {
        public string Text { get; }
        public string Caption { get; }
        public Action<bool> Callback { get; }

        public ShowDialogMessage(string text)
        {
            Text = text;
        }
    }
}
