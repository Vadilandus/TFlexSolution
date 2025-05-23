using FigureSolution.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FIgureSolutionTests.ModelTests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void CorrectRectangle()
        {
            //Create Fields
            var rectangle = new Rectangle(10,10,100,100, "CorrectRectangle");

            //Assert
            Assert.AreEqual(10,rectangle.x);
            Assert.AreEqual(10,rectangle.y);
            Assert.AreEqual(100,rectangle.width);
            Assert.AreEqual(100,rectangle.height);
            Assert.AreEqual("CorrectRectangle",rectangle.Name);
        }
    }
}
