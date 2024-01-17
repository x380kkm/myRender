namespace myRender.Pac.Tool.Art3D._OBJ;
using System.Collections.Generic;
public class ObjModel
{
        public List<Vertex> Vertices { get; set; }
        public List<VertexTexture> VertexTextures { get; set; }
        public List<VertexNormal> VertexNormals { get; set; }
        public List<Face> Faces { get; set; }
        public List<Group> Groups { get; set; }
        public List<SmoothGroup> SmoothGroups { get; set; }

        #region MyRegion
 
        public ObjModel()
        {
            Vertices = new List<Vertex>();
            VertexTextures = new List<VertexTexture>();
            VertexNormals = new List<VertexNormal>();
            Faces = new List<Face>();
            Groups = new List<Group>();
            SmoothGroups = new List<SmoothGroup>();
        }

        public ObjModel(List<Vertex> vertices, List<VertexTexture> vertexTextures, List<VertexNormal> vertexNormals,
            List<Face> faces, List<Group> groups, List<SmoothGroup> smoothGroups)
        {
            Vertices = vertices;
            VertexTextures = vertexTextures;
            VertexNormals = vertexNormals;
            Faces = faces;
            Groups = groups;
            SmoothGroups = smoothGroups;
        }

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddVertexTexture(VertexTexture vertexTexture)
        {
            VertexTextures.Add(vertexTexture);
        }

        public void AddVertexNormal(VertexNormal vertexNormal)
        {
            VertexNormals.Add(vertexNormal);
        }

        public void AddFace(Face face)
        {
            Faces.Add(face);
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void AddSmoothGroup(SmoothGroup smoothGroup)
        {
            SmoothGroups.Add(smoothGroup);
        }
        
        public void AddVertex(int x, int y, int z)
        {
            Vertices.Add(new Vertex(x, y, z));
        }
        
        public void AddVertexTexture(int x, int y, int z)
        {
            VertexTextures.Add(new VertexTexture(x, y, z));
        }
        
        public void AddVertexNormal(int x, int y, int z)
        {
            VertexNormals.Add(new VertexNormal(x, y, z));
        }
        
        public void AddFace(VertexIndex vertex1, VertexIndex vertex2, VertexIndex vertex3)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3));
        }
        
        public void AddFace(VertexIndex vertex1, VertexIndex vertex2, VertexIndex vertex3, VertexIndex vertex4)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3, vertex4));
        }
        
        public void AddFace(int vertex1, int vertex2, int vertex3)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3));
        }
        
        public void AddFace(int vertex1, int vertex2, int vertex3, int vertex4)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3, vertex4));
        }
        
        public void AddFace(int vertex1, int vertex2, int vertex3, int vertex4, int texture1, int texture2, int texture3, int texture4)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3, vertex4, texture1, texture2, texture3, texture4));
        }
        
        public void AddFace(int vertex1, int vertex2, int vertex3, int vertex4, int texture1, int texture2, int texture3, int texture4, int normal1, int normal2, int normal3, int normal4)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3, vertex4, texture1, texture2, texture3, texture4, normal1, normal2, normal3, normal4));
        }
        
        public void AddFace(int vertex1, int vertex2, int vertex3, int texture1, int texture2, int texture3)
        {
            Faces.Add(new Face(vertex1, vertex2, vertex3, texture1, texture2, texture3));
        }
        
        public void AddGroup(string name)
        {
            Groups.Add(new Group(name));
        }
        #endregion
        

}