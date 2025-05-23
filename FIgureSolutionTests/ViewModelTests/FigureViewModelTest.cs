using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureSolution.ViewModel;
using FigureSolution.Services;
using System;
using System.Linq;
using FigureSolution.Model;
using Moq;

namespace FIgureSolutionTests
{
    [TestClass]
    public class FigureViewModelTest
    {

        /// <summary>
        /// Тесты в этом блоке направлены на Создание геом. фигур и их обнаружение,
        /// Проверка корректности полей созданных объекотв геом. фигур.
        /// </summary>

        [TestMethod]
        public void AddCircleCommandTest()
        {
            //Moq заглушка
            var mockRenderService = new Mock<IRenderService>();
 
            //Create Fields
            var ViewModel = new FigureViewModel(mockRenderService.Object)
            {
                FigureName = "Test",
                X = 10,
                Y = 20,
                Width = 10,
            };


            // Action
            ViewModel.AddCircleCommand.Execute(null);
            Circle newcircle = (Circle)ViewModel.baseFigures.First();


            // Assert
            Assert.AreEqual(10, newcircle.x);
            Assert.AreEqual(20, newcircle.y);
            Assert.AreEqual(10, newcircle.Radius);
            Assert.AreEqual("Test", newcircle.Name);
        }
        [TestMethod]
        public void AddRectabgleCommandTest()
        {
            //Moq заглушка
            var mockRenderService = new Mock<IRenderService>();

            //Create Fields
            var ViewModel = new FigureViewModel(mockRenderService.Object)
            {
                FigureName = "Test",
                X = 10,
                Y = 20,
                Width = 100,
                Height = 100,
            };


            //Action
            ViewModel.AddRectangleCommand.Execute(null);
            Rectangle newrectangle = (Rectangle)ViewModel.baseFigures.First();

            // Assert
            Assert.AreEqual(10, newrectangle.x);
            Assert.AreEqual(20, newrectangle.y);
            Assert.AreEqual(100, newrectangle.width);
            Assert.AreEqual(100, newrectangle.height);
            Assert.AreEqual("Test", newrectangle.Name);
        }


        [TestMethod]
        public void AddTriangleCommandTest()
        {
            //Moq заглушка
            var mockRenderService = new Mock<IRenderService>();

            //Create Fields
            var ViewModel = new FigureViewModel(mockRenderService.Object)
            {
                FigureName = "Test",
                X = 10,
                Y = 20,
                FirstSide = 3,
                SecondSide = 4,
                ThirdSide = 5
            };


            //Action
            ViewModel.AddTriangleCommand.Execute(null);
            Triangle newtriangle = (Triangle)ViewModel.baseFigures.First();

            // Assert
            Assert.AreEqual(10, newtriangle.x);
            Assert.AreEqual(20, newtriangle.y);
            Assert.AreEqual(3, newtriangle.FirstSide);
            Assert.AreEqual(4, newtriangle.SecondSide);
            Assert.AreEqual(5, newtriangle.ThirdSide);
            Assert.AreEqual("Test", newtriangle.Name);


        }
    }
}
