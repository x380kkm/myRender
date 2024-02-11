using System.Numerics;
using MyMath.Triangle._2D.Implementations;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class UvCoordinateTests
{
    private class UvWeightedAverageCalculator : MyMath.LinearCalculations.WeightedDataCalculators.Interfaces.IWeightedAverageCalculator<float, float>
    {
        public float CalculateWeightedAverage(IEnumerable<(float weight, float data)> weightedData)
        {
            float totalWeight = 0;
            float totalValue = 0;
            foreach (var (weight, data) in weightedData)
            {
                totalWeight += weight;
                totalValue += weight * data;
            }
            return totalValue / totalWeight;
        }
    }

    [TestMethod]
    public void TestCalculateTargetData2DWithUvCoordinates()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var vertices = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var uvCoordinates = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var targetVertex = new Vector2(0.5f, 0.5f);
        var weightedAverageCalculator = new UvWeightedAverageCalculator();

        // Act
        var uAverage = processor.CalculateTargetData(vertices, uvCoordinates.Select(uv => uv.X), targetVertex, weightedAverageCalculator);
        var vAverage = processor.CalculateTargetData(vertices, uvCoordinates.Select(uv => uv.Y), targetVertex, weightedAverageCalculator);

        // Assert
        // Replace with the actual expected averages
        var expectedUAverage = 0.5f;
        var expectedVAverage = 0.5f;
        Assert.AreEqual(expectedUAverage, uAverage, 1e-6f);
        Assert.AreEqual(expectedVAverage, vAverage, 1e-6f);
    }

    [TestMethod]
    public void TestCalculateTargetData3DWithUvCoordinates()
    {
        // Arrange
        var processor = new Vertex3DWeightDataProcessor(new TriangleWeightCalculator3D());
        var vertices = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};
        var uvCoordinates = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var targetVertex = new Vector3(0.5f, 0.5f, 0);
        var weightedAverageCalculator = new UvWeightedAverageCalculator();

        // Act
        var uAverage = processor.CalculateTargetData(vertices, uvCoordinates.Select(uv => uv.X), targetVertex, weightedAverageCalculator);
        var vAverage = processor.CalculateTargetData(vertices, uvCoordinates.Select(uv => uv.Y), targetVertex, weightedAverageCalculator);

        // Assert
        // Replace with the actual expected averages
        var expectedUAverage = 0.5f;
        var expectedVAverage = 0.5f;
        Assert.AreEqual(expectedUAverage, uAverage, 1e-6f);
        Assert.AreEqual(expectedVAverage, vAverage, 1e-6f);
    }
}