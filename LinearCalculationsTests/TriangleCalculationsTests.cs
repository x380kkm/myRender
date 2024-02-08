using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using MyMath.Triangle._3D.Implementations;

namespace LinearCalculationsTests
{
    [TestClass]
    public class TriangleCalculationsTests
    {
        [TestMethod]
        public void TestTriangleAreaCalculation3D()
        {
            // Arrange
            var triangle = new Triangle3D(new Vertex3D(new Vector3(0, 0, 0)), new Vertex3D(new Vector3(1, 0, 0)), new Vertex3D(new Vector3(0, 1, 0)));
            var calculator = new TriangleAreaCalculator3D();

            // Act
            var area = calculator.CalculateArea(triangle.GetVertices()[0].Coordinates, triangle.GetVertices()[1].Coordinates, triangle.GetVertices()[2].Coordinates);

            // Assert
            Assert.AreEqual(0.5f, area);
        }


        [TestMethod]
        public void TestAreaBasedWeightCalculation3D_2()
        {
            // Arrange
            var triangle = new Triangle3D(new Vertex3D(new Vector3(0, 0, 0)), new Vertex3D(new Vector3(1, 0, 0)), new Vertex3D(new Vector3(0, 1, 0)));
            var calculator = new AreaBasedWeightStrategy3D();

            // Act
            var centroid = (triangle.GetVertices()[0].Coordinates + triangle.GetVertices()[1].Coordinates + triangle.GetVertices()[2].Coordinates) / 3;
            var weights = calculator.CalculateWeight(triangle.GetVertices()[0].Coordinates, triangle.GetVertices()[1].Coordinates, triangle.GetVertices()[2].Coordinates, centroid);

            // Assert
            Assert.AreEqual((1/3f, 1/3f, 1/3f), weights);
            
        }
        [TestMethod]
        public void TestAreaBasedWeightCalculation3D_NotCentroid()
        {
            // Arrange
            var triangle = new Triangle3D(new Vertex3D(new Vector3(0, 0, 0)), new Vertex3D(new Vector3(1, 0, 0)), new Vertex3D(new Vector3(0, 1, 0)));
            var calculator = new AreaBasedWeightStrategy3D();

            // Act
            var targetPoint = new Vector3(0.5f, 0.2f, 0);
            var weights = calculator.CalculateWeight(triangle.GetVertices()[0].Coordinates, triangle.GetVertices()[1].Coordinates, triangle.GetVertices()[2].Coordinates, targetPoint);

            // Assert
            // The expected weights depend on your specific implementation of CalculateWeight
            // Here we just assert that the weights add up to 1
            Assert.AreEqual(1, weights.Item1 + weights.Item2 + weights.Item3, 1e-6f);
        }
        
    }
}