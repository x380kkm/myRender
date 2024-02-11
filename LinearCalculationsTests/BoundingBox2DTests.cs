using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath.Coordinates._2D.Point.Implementations;
using System.Linq;

namespace LinearCalculationsTests
{
    [TestClass]
    public class BoundingBox2DTests
    {
        [TestMethod]
        public void TestCreateBoundingBox()
        {
            // Arrange
            var boundingBox2D = new BoundingBox2D();
            var points = new (float, float)[] { (1, 1), (2, 2), (3, 3), (4, 4) };

            // Act
            var result = boundingBox2D.CreateBoundingBox(points);

            // Assert
            Assert.AreEqual(1, result.MinX);
            Assert.AreEqual(4, result.MaxX);
            Assert.AreEqual(1, result.MinY);
            Assert.AreEqual(4, result.MaxY);
        }

        [TestMethod]
        public void TestCreateBoundingBoxWithSamePoints()
        {
            // Arrange
            var boundingBox2D = new BoundingBox2D();
            var points = new (float, float)[] { (2, 2), (2, 2), (2, 2), (2, 2) };

            // Act
            var result = boundingBox2D.CreateBoundingBox(points);

            // Assert
            Assert.AreEqual(2, result.MinX);
            Assert.AreEqual(2, result.MaxX);
            Assert.AreEqual(2, result.MinY);
            Assert.AreEqual(2, result.MaxY);
        }
    }
}