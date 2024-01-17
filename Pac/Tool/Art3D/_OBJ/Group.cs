namespace Pac.Tool.Art3D._OBJ;

public class Group
{
    public string? Name { get; set; }
    public List<Vertex> Vertices { get; set; } = new();
    public List<VertexNormal> VertexNormals { get; set; } = new();
    public List<Face> Faces { get; set; } = new();
    public List<VertexTexture> VertexTextures { get; set; } = new();
    public  Group (string name)
    {
        Name = name;
    }
    
    
}
