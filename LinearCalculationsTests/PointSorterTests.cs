using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath.Coordinates._2D.Point.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace LinearCalculationsTests
{
    [TestClass]
    public class PointSorterTests
    {
        [TestMethod]
        public void TestSortPoints()
        {
            // Arrange
            var pointSorter = new PointSorter();
            var points = new List<(float x, float y)>
            {
                (1, 2),
                (3, 1),
                (2, 2),
                (1, 1),
                (2, 1)
            };

            // Act
            var sortedPoints = pointSorter.SortPoints(points);

            // Assert
            var expectedPoints = new List<(float x, float y)>
            {
                (1, 1),
                (2, 1),
                (3, 1),
                (1, 2),
                (2, 2)
            };
            Assert.IsTrue(sortedPoints.SequenceEqual(expectedPoints));
        }
    }
}