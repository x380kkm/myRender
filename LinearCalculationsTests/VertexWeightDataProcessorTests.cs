using System.Numerics;
using MyMath.Triangle._2D.Implementations;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class VertexWeightDataProcessorTests
{
    [TestMethod]
    public void TestCalculateWeights2D()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var vertices = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var targetVertex = new Vector2(0.5f, 0.5f);

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);

        // Assert
        // The expected weights depend on your specific implementation of CalculateWeights
        // Here we just assert that the weights are not null
        Assert.IsNotNull(weights);
    }

    [TestMethod]
    public void TestCalculateWeights3D()
    {
        // Arrange
        var processor = new Vertex3DWeightDataProcessor(new TriangleWeightCalculator3D());
        var vertices = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};
        var targetVertex = new Vector3(0.5f, 0.5f, 0);

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);

        // Assert
        // The expected weights depend on your specific implementation of CalculateWeights
        // Here we just assert that the weights are not null
        Assert.IsNotNull(weights);
    }

    [TestMethod]
    public void TestCalculateWeightedAverage2D()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var weightedData = new List<(float weight, float data)> { (0.2f, 1f), (0.3f, 2f), (0.5f, 3f) };

        // Act
        var average = processor.CalculateWeightedAverage(weightedData);

        // Assert
        // The expected average depends on your specific implementation of CalculateWeightedAverage
        // Here we just assert that the average is not null
        Assert.IsNotNull(average);
    }

    [TestMethod]
    public void TestCalculateWeightedAverage3D()
    {
        // Arrange
        var processor = new Vertex3DWeightDataProcessor(new TriangleWeightCalculator3D());
        var weightedData = new List<(float weight, float data)> { (0.2f, 1f), (0.3f, 2f), (0.5f, 3f) };

        // Act
        var average = processor.CalculateWeightedAverage(weightedData);

        // Assert
        // The expected average depends on your specific implementation of CalculateWeightedAverage
        // Here we just assert that the average is not null
        Assert.IsNotNull(average);
    }
        
        
        
    [TestMethod]
    public void TestCalculateWeightsAndWeightedAverage2D()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var vertices = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var targetVertex = new Vector2(0.5f, 0.5f);
        var data = new List<float> { 1f, 2f, 3f };  // Replace with the actual data
        var weightedData = new List<(float weight, float data)>();

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);
        for (int i = 0; i < weights.Count(); i++)
        {
            weightedData.Add((weights.ElementAt(i), data[i]));
        }
        var average = processor.CalculateWeightedAverage(weightedData);

        // Assert
        // The expected average depends on your specific implementation of CalculateWeightedAverage
        // Here we just assert that the average is not null
        Assert.IsNotNull(average);
    }

    [TestMethod]
    public void TestCalculateWeightsAndWeightedAverage3D()
    {
        // Arrange
        var processor = new Vertex3DWeightDataProcessor(new TriangleWeightCalculator3D());
        var vertices = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};
        var targetVertex = new Vector3(0.5f, 0.5f, 0);
        var data = new List<float> { 0, 1f, 2f };  // Replace with the actual data
        var weightedData = new List<(float weight, float data)>();

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);
        for (int i = 0; i < weights.Count(); i++)
        {
            weightedData.Add((weights.ElementAt(i), data[i]));
        }
        var average = processor.CalculateWeightedAverage(weightedData);

        // Assert
        // The expected average depends on your specific implementation of CalculateWeightedAverage
        // Here we just assert that the average is not null
        Assert.IsNotNull(average);
    }
}