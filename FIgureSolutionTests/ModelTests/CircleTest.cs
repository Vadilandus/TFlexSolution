using FigureSolution.Model;
using FigureSolution.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FIgureSolutionTests.ModelTests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void CorrectCircle()
        {

            // Create Fields
            Circle circle;

            // Act
            circle = new Circle(100, 100, 10, "CorrectCircle"); 


            // Assert
            Assert.AreEqual(10, circle.Radius);
            Assert.AreEqual(100, circle.x);
            Assert.AreEqual(100, circle.y);
            Assert.AreEqual("CorrectCircle", circle.Name);
        }
    }
}
