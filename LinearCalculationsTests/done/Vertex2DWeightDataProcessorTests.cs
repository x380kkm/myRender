using System.Numerics;
using MyMath.Triangle._2D.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class Vertex2DWeightDataProcessorTests
{
    [TestMethod]
    public void TestCalculateWeights()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var vertices = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var targetVertex = new Vector2(0.5f, 0.5f);

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);

        // Assert
        // The expected weights depend on your specific implementation of CalculateWeights
        // Here we just assert that the weights add up to 1
        Assert.AreEqual(1, weights.Sum(), 1e-6f);
    }
        
        
    [TestMethod]
    public void TestCalculateWeightsWithKnownData()
    {
        // Arrange
        var processor = new Vertex2DWeightDataProcessor(new TriangleWeightCalculator2D());
        var vertices = new List<Vector2> { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        var targetVertex = new Vector2(0.5f, 0.5f);
        var expectedWeights = new List<float> { 0f, 0.5f, 0.5f };  // Replace with the actual expected weights

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);

        // Assert
        CollectionAssert.AreEqual(expectedWeights, weights.ToList());
    }
        
        
        
        
        
        
}