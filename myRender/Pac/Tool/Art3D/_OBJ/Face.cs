namespace myRender.Pac.Tool.Art3D._OBJ;

public class Face
{
    public List<VertexIndex> Vertices { get; set; } = new();
    public Face(List<VertexIndex> vertices)
    {
        Vertices = vertices;
    }
    public Face(VertexIndex vertex1, VertexIndex vertex2, VertexIndex vertex3)
    {
        Vertices.Add(vertex1);
        Vertices.Add(vertex2);
        Vertices.Add(vertex3);
    }
    
    public Face(VertexIndex vertex1, VertexIndex vertex2, VertexIndex vertex3, VertexIndex vertex4)
    {
        Vertices.Add(vertex1);
        Vertices.Add(vertex2);
        Vertices.Add(vertex3);
        Vertices.Add(vertex4);
    }
    
    public Face(int vertex1, int vertex2, int vertex3)
    {
        Vertices.Add(new VertexIndex(vertex1, null, null));
        Vertices.Add(new VertexIndex(vertex2, null, null));
        Vertices.Add(new VertexIndex(vertex3, null, null));
    }
    
    public Face(int vertex1, int vertex2, int vertex3, int vertex4)
    {
        Vertices.Add(new VertexIndex(vertex1, null, null));
        Vertices.Add(new VertexIndex(vertex2, null, null));
        Vertices.Add(new VertexIndex(vertex3, null, null));
        Vertices.Add(new VertexIndex(vertex4, null, null));
    }
    
    public Face(int vertex1, int vertex2, int vertex3, int vertex4, int texture1, int texture2, int texture3, int texture4)
    {
        Vertices.Add(new VertexIndex(vertex1, texture1, null));
        Vertices.Add(new VertexIndex(vertex2, texture2, null));
        Vertices.Add(new VertexIndex(vertex3, texture3, null));
        Vertices.Add(new VertexIndex(vertex4, texture4, null));
    }
    
    public Face(int vertex1, int vertex2, int vertex3, int vertex4, int texture1, int texture2, int texture3, int texture4, int normal1, int normal2, int normal3, int normal4)
    {
        Vertices.Add(new VertexIndex(vertex1, texture1, normal1));
        Vertices.Add(new VertexIndex(vertex2, texture2, normal2));
        Vertices.Add(new VertexIndex(vertex3, texture3, normal3));
        Vertices.Add(new VertexIndex(vertex4, texture4, normal4));
    }

    public Face(int vertex1, int vertex2, int vertex3, int texture1, int texture2, int texture3)
    {
        Vertices.Add(new VertexIndex(vertex1, texture1, null));
        Vertices.Add(new VertexIndex(vertex2, texture2, null));
        Vertices.Add(new VertexIndex(vertex3, texture3, null));
    }

    public Face()
    {
        throw new NotImplementedException();
    }
}
