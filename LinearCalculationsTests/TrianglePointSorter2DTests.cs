using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath.Triangle._2D.Implementations;
using System;
using System.Linq;

namespace LinearCalculationsTests
{
    [TestClass]
    public class TrianglePointSorter2DTests
    {
        [TestMethod]
        public void TestSortPoints()
        {
            // Arrange
            var trianglePointSorter2D = new TrianglePointSorter2D();
            var points = new (float x, float y)[]
            {
                (1, 2),
                (3, 1),
                (2, 2)
            };

            // Act
            var sortedPoints = trianglePointSorter2D.SortPoints(points);

            // Assert
            var expectedPoints = new (float x, float y)[]
            {
                (3, 1),
                (1, 2),
                (2, 2)
            };
            Assert.IsTrue(sortedPoints.SequenceEqual(expectedPoints));
        }

        [TestMethod]
        public void TestSortPoints_ThrowsException_WhenNotThreePoints()
        {
            // Arrange
            var trianglePointSorter2D = new TrianglePointSorter2D();
            var points = new (float x, float y)[]
            {
                (1, 2),
                (3, 1)
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => trianglePointSorter2D.SortPoints(points));
        }
    }
}