using System.Numerics;
using System.Windows.Media;
using Pac.Tool.Art3D._OBJ;
using Pac.Tool.Math;
using myRender.renderPac.myColor;

namespace myRender.renderPac
{
    public class ModelRenderer
    {
        private Class2 _class2;
        private Vector2 _screenSize;
        private ObjModel _model;

        public ModelRenderer(Renderer renderer, int screenWidth, int screenHeight)
        {
            _class2 = new Class2(renderer);
            _screenSize = new Vector2(screenWidth, screenHeight);
        }

        public void RenderModel(ObjModel model)
        {
            _model = model; // 设置_model字段的值
            foreach (var face in model.Groups[1].Faces)
            {
                var vertices = face.Vertices.Select(v => model.Vertices[v.Vertex - 1]).ToList();
                var triangle3D = new Triangle3D(
                    new Vector3(vertices[0].X, vertices[0].Y, vertices[0].Z),
                    new Vector3(vertices[1].X, vertices[1].Y, vertices[1].Z),
                    new Vector3(vertices[2].X, vertices[2].Y, vertices[2].Z)
                );

                _class2.FillTriangle3D(triangle3D, _screenSize);
            }
        }

        
    }
}