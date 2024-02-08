using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace LinearCalculationsTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestTriangle2D()
        {
            // Arrange
            var triangle = new Triangle2D(new Vertex2D(new Vector2(0, 0)), new Vertex2D(new Vector2(1, 0)), new Vertex2D(new Vector2(0, 1)));

            // Act
            var vertices = triangle.GetVertices();

            // Assert
            Assert.AreEqual(3, vertices.Count);
            Assert.AreEqual(new Vector2(0, 0), vertices[0].Coordinates);
            Assert.AreEqual(new Vector2(1, 0), vertices[1].Coordinates);
            Assert.AreEqual(new Vector2(0, 1), vertices[2].Coordinates);
        }

        [TestMethod]
        public void TestTriangle3D()
        {
            // Arrange
            var triangle = new Triangle3D(new Vertex3D(new Vector3(0, 0, 0)), new Vertex3D(new Vector3(1, 0, 0)), new Vertex3D(new Vector3(0, 1, 0)));

            // Act
            var vertices = triangle.GetVertices();

            // Assert
            Assert.AreEqual(3, vertices.Count);
            Assert.AreEqual(new Vector3(0, 0, 0), vertices[0].Coordinates);
            Assert.AreEqual(new Vector3(1, 0, 0), vertices[1].Coordinates);
            Assert.AreEqual(new Vector3(0, 1, 0), vertices[2].Coordinates);
        }
        
        
        
        
        
        
        
    }
}