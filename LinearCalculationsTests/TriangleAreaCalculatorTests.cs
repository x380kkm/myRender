// LinearCalculationsTests/TriangleAreaCalculatorTests.cs
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath.Triangle._2D.Implementations;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests
{
    [TestClass]
    public class TriangleAreaCalculatorTests
    {
        private float CalculateExpectedArea2D(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            var ab = pointB - pointA;
            var ac = pointC - pointA;
            return 0.5f * System.Math.Abs(ab.X * ac.Y - ab.Y * ac.X);
        }

        private float CalculateExpectedArea3D(Vector3 pointA, Vector3 pointB, Vector3 pointC)
        {
            var ab = pointB - pointA;
            var ac = pointC - pointA;
            var crossProduct = Vector3.Cross(ab, ac);
            return 0.5f * crossProduct.Length();
        }

        [DataTestMethod]
        [DataRow(0, 0, 1, 0, 0, 1)]
        [DataRow(0, 0, 2, 0, 0, 2)]
        [DataRow(1, 1, 2, 2, 3, 3)]
        [DataRow(-1, -1, 1, -1, -1, 1)]
        [DataRow(0, 0, 0, 1, 1, 0)]
        public void TestCalculateArea2D(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            // Arrange
            var calculator = new TriangleAreaCalculator2D();
            var pointA = new Vector2(x1, y1);
            var pointB = new Vector2(x2, y2);
            var pointC = new Vector2(x3, y3);
            var expectedArea = CalculateExpectedArea2D(pointA, pointB, pointC);

            // Act
            var result = calculator.CalculateArea(pointA, pointB, pointC);

            // Assert
            Assert.AreEqual(expectedArea, result, 0.0001f);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0, 1, 0, 0, 0, 1, 0)]
        [DataRow(0, 0, 0, 2, 0, 0, 0, 2, 0)]
        [DataRow(1, 1, 1, 2, 2, 2, 3, 3, 3)]
        [DataRow(-1, -1, -1, 1, -1, -1, -1, 1, 0)]
        [DataRow(0, 0, 0, 0, 1, 0, 1, 0, 0)]
        public void TestCalculateArea3D(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
        {
            // Arrange
            var calculator = new TriangleAreaCalculator3D();
            var pointA = new Vector3(x1, y1, z1);
            var pointB = new Vector3(x2, y2, z2);
            var pointC = new Vector3(x3, y3, z3);
            var expectedArea = CalculateExpectedArea3D(pointA, pointB, pointC);

            // Act
            var result = calculator.CalculateArea(pointA, pointB, pointC);

            // Assert
            Assert.AreEqual(expectedArea, result, 0.0001f);
        }
    }
}