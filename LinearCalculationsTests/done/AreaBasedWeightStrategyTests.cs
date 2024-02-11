using System.Numerics;
using MyMath.Triangle._2D.Implementations;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class AreaBasedWeightStrategyTests
{
    // Existing tests...

    [TestMethod]
    public void CalculateWeight2D_ReturnsNormalizedWeights()
    {
        // Arrange
        var strategy = new AreaBasedWeightStrategy2D();
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
    public void CalculateWeight3D_ReturnsNormalizedWeights()
    {
        // Arrange
        var strategy = new AreaBasedWeightStrategy3D();
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
    public void CalculateWeight2D_ReturnsCorrectWeights_WhenTargetPointIsOnEdgeOfTriangle()
    {
        // Arrange
        var strategy = new AreaBasedWeightStrategy2D();
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
    public void CalculateWeight3D_ReturnsCorrectWeights_WhenTargetPointIsOnEdgeOfTriangle()
    {
        // Arrange
        var strategy = new AreaBasedWeightStrategy3D();
        var pointA = new Vector3(0, 0, 0);
        var pointB = new Vector3(1, 0, 0);
        var pointC = new Vector3(0.5f, 1, 0);
        var targetPoint = new Vector3(0.5f, 0, 0);

        // Act
        var (weightA, weightB, weightC) = strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);

        // Assert
        Assert.AreEqual(0.5f, weightA, 0.0001);
        Assert.AreEqual(0.5f, weightB, 0.0001);
        Assert.AreEqual(0, weightC);
    }
}