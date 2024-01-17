using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
using Pac.Tool.Art3D._OBJ;
namespace myRender.renderPac;
public class ModelRenderer
{
    private Canvas _canvas;
    
    public ModelRenderer(Canvas canvas)
    {
        this._canvas = canvas;
        _canvas.Background = new SolidColorBrush(Colors.Black);
    }

    public void Draw3DModel(string filePath,int xSize = 1,int ySize = 1)
    {
        var objFileReader = new ObjFileReader();
        var model = objFileReader.ReadFile(filePath);

        float dX =  model.Vertices.Max(v => v.X) - model.Vertices.Min(v => v.X);
        float dY =  model.Vertices.Max(v => v.Y) - model.Vertices.Min(v => v.Y);
        _canvas.MaxWidth =  dX * xSize;
        _canvas.MaxHeight = dY * ySize;
        
        foreach (var face in model.Groups.SelectMany(group => group.Faces))
        {
            for (var i = 0; i < face.Vertices.Count; i++)
            {
                var startVertexIndex = face.Vertices[i].Vertex - 1;
                var endVertexIndex = face.Vertices[(i + 1) % face.Vertices.Count].Vertex - 1;

                var startVertex = model.Vertices[startVertexIndex];
                var endVertex = model.Vertices[endVertexIndex];

                Class1.DrawLine(_canvas,Colors.White,new Vector2((int)((0.5*dX-startVertex.X) * xSize),(int) ((0.5*dY-startVertex.Y) * ySize)), new Vector2((int)((0.5*dX-endVertex.X) * xSize),(int) ((0.5*dY-endVertex.Y) * ySize)));
            }
        }
    }
}