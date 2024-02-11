using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath.Triangle._2D.Implementations;

namespace LinearCalculationsTests
{
    [TestClass]
    public class BoundingBoxFromTriangleVertices2DTests
    {
        [TestMethod]
        public void CreateBoundingBoxFromTriangleVertices_ValidPoints_ReturnsCorrectBoundingBox()
        {
            // Arrange
            var boundingBoxFromTriangleVertices2D = new BoundingBoxFromTriangleVertices2D();
            var points = new (float x, float y)[] { (1, 1), (2, 2), (3, 3) };

            // Act
            var result = boundingBoxFromTriangleVertices2D.CreateBoundingBox(points);

            // Assert
            Assert.AreEqual((1, 3, 1, 3), result);
        }

        [TestMethod]
        public void CreateBoundingBoxFromTriangleVertices_InvalidNumberOfPoints_ThrowsArgumentException()
        {
            // Arrange
            var boundingBoxFromTriangleVertices2D = new BoundingBoxFromTriangleVertices2D();
            var points = new (float x, float y)[] { (1, 1), (2, 2) };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => boundingBoxFromTriangleVertices2D.CreateBoundingBox(points));
        }
    }
}