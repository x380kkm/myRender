using System.Numerics;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class TriangleNormalCalculatorMathTests
{
    [TestMethod]
    public void TestCalculateNormal()
    {
        // Arrange
        var triangle = new Triangle3D(new Vertex3D(new Vector3(0, 0, 0)), new Vertex3D(new Vector3(1, 0, 0)), new Vertex3D(new Vector3(0, 1, 0)));
        var calculator = new TriangleNormalCalculatorMath();

        // Act
        var normalVector = calculator.CalculateNormal(triangle.GetVertices()[0].Coordinates, triangle.GetVertices()[1].Coordinates, triangle.GetVertices()[2].Coordinates);

        // Assert
        Assert.AreEqual(new Vector3(0, 0, 1), normalVector);
    }
}