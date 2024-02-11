using System.Numerics;
using MyMath.Triangle._2D.Implementations;
using MyMath.Triangle._3D.Implementations;
using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class TriangleWeightDataProcessorTests
{
    [TestMethod]
    public void TestCalculateTargetData2DWithKnownData()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var vertices = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var data = new List<float> { 1f, 2f, 3f };
        var targetVertex = new Vector2(0.5f, 0.5f);
        var weightedAverageCalculator = new FloatWeightedAverageCalculator();

        // Act
        var average = processor.CalculateTargetData(vertices, data, targetVertex, weightedAverageCalculator);

        // Assert
        var expectedAverage = 0.5f * 2f + 0.5f * 3f;  // Replace with the actual expected average
        Assert.AreEqual(expectedAverage, average, 1e-6f);
    }

    [TestMethod]
    public void TestCalculateTargetData3DWithKnownData()
    {
        // Arrange
        var processor = new Vertex3DWeightDataProcessor(new TriangleWeightCalculator3D());
        var vertices = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};
        var data = new List<float> { 1f, 2f, 3f };
        var targetVertex = new Vector3(0.5f, 0.5f, 0);
        var weightedAverageCalculator = new FloatWeightedAverageCalculator();

        // Act
        var average = processor.CalculateTargetData(vertices, data, targetVertex, weightedAverageCalculator);

        // Assert
        var expectedAverage = 0.5f * 2f + 0.5f * 3f;  // Replace with the actual expected average
        Assert.AreEqual(expectedAverage, average, 1e-6f);
    }
}