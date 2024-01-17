namespace myRender.Pac.Tool.Art3D._OBJ;

public class VertexIndex
{
    public int Vertex { get; set; } // Vertex index
    public int? Texture { get; set; } // Texture index
    public int? Normal { get; set; } // Normal index
    
    public VertexIndex(int vertex, int? texture, int? normal)
    {
        Vertex = vertex;
        Texture = texture;
        Normal = normal;
    }
    
    
}