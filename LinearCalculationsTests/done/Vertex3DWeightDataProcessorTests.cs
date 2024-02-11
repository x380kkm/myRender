using System.Numerics;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class Vertex3DWeightDataProcessorTests
{
    [TestMethod]
    public void TestCalculateWeightsWithKnownData()
    {
        // Arrange
        var processor = new Vertex3DWeightDataProcessor(new TriangleWeightCalculator3D());
        var vertices = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};
        var targetVertex = new Vector3(0.5f, 0.5f, 0);
        var expectedWeights = new List<float> { 0f, 0.5f, 0.5f};  // Replace with the actual expected weights

        // Act
        var weights = processor.CalculateWeights(vertices, targetVertex);

        // Assert
        CollectionAssert.AreEqual(expectedWeights, weights.ToList());
            
    }
}