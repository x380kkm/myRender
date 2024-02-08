using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Implementations;

namespace LinearCalculationsTests
{
    [TestClass]
    public class AreaBasedWeightStrategyTests
    {
        [TestMethod]
        public void CalculateWeight_ReturnsEqualWeights_WhenGivenEquilateralTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(0, 0);
            var pointB = new Vector2(1, 0);
            var pointC = new Vector2(0.5f, (float)Math.Sqrt(3) / 2);
            var targetPoint = new Vector2(0.5f, (float)Math.Sqrt(3) / 6);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.AreEqual(weightA, weightB);
            Assert.AreEqual(weightB, weightC);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenGivenIsoscelesTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(0, 0);
            var pointB = new Vector2(1, 0);
            var pointC = new Vector2(0.5f, 1);
            var targetPoint = new Vector2(0.5f, 0);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.AreEqual(0.5f, weightA);
            Assert.AreEqual(0.5f, weightB);
            Assert.AreEqual(0, weightC);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenGiven2DTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(0, 0);
            var pointB = new Vector2(1, 0);
            var pointC = new Vector2(0.5f, 1);
            var targetPoint = new Vector2(0.5f, 0.5f);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.IsTrue(Math.Abs(weightA + weightB + weightC - 1) < 0.0001);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenGiven3DTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector3(0, 0, 0);
            var pointB = new Vector3(1, 0, 0);
            var pointC = new Vector3(0.5f, 1, 0);
            var targetPoint = new Vector3(0.5f, 0.5f, 0);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.IsTrue(Math.Abs(weightA + weightB + weightC - 1) < 0.0001);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenGiven2DTriangleAndDifferentOrder()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(1, 0);
            var pointB = new Vector2(0, 0);
            var pointC = new Vector2(0.5f, 1);
            var targetPoint = new Vector2(0.5f, 0.5f);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.AreEqual(0.25f, weightA, 0.0001);
            Assert.AreEqual(0.25f, weightB, 0.0001);
            Assert.AreEqual(0.5f, weightC, 0.0001);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenGiven3DTriangleAndDifferentOrder()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector3(1, 0, 0);
            var pointB = new Vector3(0, 0, 0);
            var pointC = new Vector3(0.5f, 1, 0);
            var targetPoint = new Vector3(0.5f, 0.5f, 0);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.AreEqual(0.25f, weightA, 0.0001);
            Assert.AreEqual(0.25f, weightB, 0.0001);
            Assert.AreEqual(0.5f, weightC, 0.0001);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenTargetPointIsVertexOfTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(0, 0);
            var pointB = new Vector2(1, 0);
            var pointC = new Vector2(0.5f, 1);
            var targetPoint = pointA;

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.AreEqual(1, weightA);
            Assert.AreEqual(0, weightB);
            Assert.AreEqual(0, weightC);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenTargetPointIsOnEdgeOfTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(0, 0);
            var pointB = new Vector2(1, 0);
            var pointC = new Vector2(0.5f, 1);
            var targetPoint = new Vector2(0.5f, 0);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.AreEqual(0.5f, weightA, 0.0001);
            Assert.AreEqual(0.5f, weightB, 0.0001);
            Assert.AreEqual(0, weightC);
        }

        [TestMethod]
        public void CalculateWeight_ReturnsCorrectWeights_WhenTargetPointIsInsideTriangle()
        {
            // Arrange
            var strategy = new AreaBasedWeightStrategy();
            var pointA = new Vector2(0, 0);
            var pointB = new Vector2(1, 0);
            var pointC = new Vector2(0.5f, 1);
            var targetPoint = new Vector2(0.5f, 0.5f);

            // Act
            var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

            // Assert
            Assert.IsTrue(weightA > 0);
            Assert.IsTrue(weightB > 0);
            Assert.IsTrue(weightC > 0);
        }
    }
}