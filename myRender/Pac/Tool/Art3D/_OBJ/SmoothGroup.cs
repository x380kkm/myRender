namespace myRender.Pac.Tool.Art3D._OBJ;

public class SmoothGroup
{
    public List<Vertex> Vertices { get; set; } = new();
    public List<VertexNormal> Normals { get; set; } = new();
    public List<VertexTexture> Textures { get; set; } = new();
    public List<Face> Faces { get; set; } = new();
}