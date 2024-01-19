using System.Globalization;

namespace Pac.Tool.Art3D._OBJ;

public class ObjFileReader
{
    public ObjModel ReadFile(string filePath)
    {
        
        var model = new ObjModel();
        var currentGroup = new Group("default");
        var currentSmoothGroup = new SmoothGroup();
        model.Groups.Add(currentGroup);
        model.SmoothGroups.Add(currentSmoothGroup);
        // ReSharper disable once ConvertToUsingDeclaration
        using (var reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    switch (parts[0])
                    {
                        case "v":
                            model.Vertices.Add(ParseVertex(parts));
                            break;
                        case "vt":
                            model.VertexTextures.Add(ParseVertexTexture(parts));
                            break;
                        case "vn":
                            model.VertexNormals.Add(ParseVertexNormal(parts));
                            break;
                        case "f":
                            currentGroup.Faces.Add(ParseFace(parts));
                            break;
                        case "g":
                            currentGroup = new Group(parts[1]);
                            model.Groups.Add(currentGroup);
                            break;
                        case "s":
                            // Handle smooth group
                            break;
                        // Other cases 
                    }
                }
            }
        }

        Vertex ParseVertex(string[] parts)
        {
            return new Vertex(
                -float.Parse(parts[1], CultureInfo.InvariantCulture),
                -float.Parse(parts[2], CultureInfo.InvariantCulture),
                -float.Parse(parts[3], CultureInfo.InvariantCulture));
        }

        VertexTexture ParseVertexTexture(string[] parts)
        {
            var u = float.Parse(parts[1], CultureInfo.InvariantCulture);
            var v = float.Parse(parts[2], CultureInfo.InvariantCulture);
            var w = parts.Length > 3 ? float.Parse(parts[3], CultureInfo.InvariantCulture) : 0f; // 默认为0

            return new VertexTexture(u, v, w);
        }

        VertexNormal ParseVertexNormal(string[] parts)
        {
            return new VertexNormal(
                float.Parse(parts[1], CultureInfo.InvariantCulture),
                float.Parse(parts[2], CultureInfo.InvariantCulture),
                float.Parse(parts[3], CultureInfo.InvariantCulture));
        }

        Face ParseFace(string[] parts)
        {
            var vertices = new List<VertexIndex>();
            for (var i = 1; i < parts.Length; i++)
            {
                var indices = parts[i].Split('/');
                var vertexIndex = int.Parse(indices[0]);
                int? textureIndex = indices.Length > 1 && !string.IsNullOrEmpty(indices[1]) ? int.Parse(indices[1]) : null;
                int? normalIndex = indices.Length > 2 && !string.IsNullOrEmpty(indices[2]) ? int.Parse(indices[2]) : null;
                vertices.Add(new VertexIndex(vertexIndex, textureIndex, normalIndex));
            }
            return new Face(vertices);
        }


        return model;
    }

}
