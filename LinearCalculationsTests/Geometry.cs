using System.Numerics;

namespace LinearCalculationsTests;

public class Vertex2D
{
    public Vector2 Coordinates { get; }

    public Vertex2D(Vector2 coordinates)
    {
        Coordinates = coordinates;
    }
}

public class Vertex3D
{
    public Vector3 Coordinates { get; }

    public Vertex3D(Vector3 coordinates)
    {
        Coordinates = coordinates;
    }
}

public class Triangle2D
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

public class Triangle3D
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