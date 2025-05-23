using FigureSolution.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Shapes;

namespace FIgureSolutionTests.ModelTests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void PointsTriangle()
        {
            // Create Fields
            Triangle triangle = new Triangle(10,10,3,4,5,"Test");

            // Action
            var TestTriangle = triangle.Draw() as Polygon;
            var points = TestTriangle.Points;

            // Assert
            Assert.IsNotNull(TestTriangle);
            Assert.AreEqual(new Point(10,10), points[0]);
            Assert.AreEqual(new Point(3, 10), points[1]);
            Assert.AreEqual(new Point(1.5, 4), points[2]);
        }
        [TestMethod]
        public void CorrectTriangle()
        {
            //Create Fields
            Triangle triangle = new Triangle(10, 10, 8, 9, 10, "CorrectTriangle");
            var TestTriangle = triangle.Draw() as Polygon;

            //Action
            Assert.IsNotNull(TestTriangle);
            Assert.AreEqual(triangle.FirstSide, 8);
            Assert.AreEqual(triangle.SecondSide, 9);
            Assert.AreEqual(triangle.ThirdSide, 10);
        }
    }
}
