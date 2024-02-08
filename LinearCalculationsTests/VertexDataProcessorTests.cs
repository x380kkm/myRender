using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Numerics;

namespace LinearCalculationsTests
{
    [TestClass]
    public class TriangleTests
    {
        private class Vertex2D
        {
            public Vector2 Coordinates { get; }

            public Vertex2D(Vector2 coordinates)
            {
                Coordinates = coordinates;
            }
        }

        private class Vertex3D
        {
            public Vector3 Coordinates { get; }

            public Vertex3D(Vector3 coordinates)
            {
                Coordinates = coordinates;
            }
        }

        private class Triangle2D
        {
            private readonly Vertex2D _vertex1;
            private readonly Vertex2D _vertex2;
            private readonly Vertex2D _vertex3;

            public Triangle2D(Vertex2D vertex1, Vertex2D vertex2, Vertex2D vertex3)
            {
                _vertex1 = vertex1;
                _vertex2 = vertex2;
                _vertex3 = vertex3;
            }

            public List<Vertex2D> GetVertices()
            {
                return new List<Vertex2D> { _vertex1, _vertex2, _vertex3 };
            }
        }

        private class Triangle3D
        {
            private readonly Vertex3D _vertex1;
            private readonly Vertex3D _vertex2;
            private readonly Vertex3D _vertex3;

            public Triangle3D(Vertex3D vertex1, Vertex3D vertex2, Vertex3D vertex3)
            {
                _vertex1 = vertex1;
                _vertex2 = vertex2;
                _vertex3 = vertex3;
            }

            public List<Vertex3D> GetVertices()
            {
                return new List<Vertex3D> { _vertex1, _vertex2, _vertex3 };
            }
        }

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