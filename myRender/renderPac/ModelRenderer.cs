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

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public ModelRenderer(Renderer renderer, int screenWidth, int screenHeight, Vector3 lightVector, TGADealer tgaDealer)
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
            _class2 = new Class2(renderer, lightVector, tgaDealer);
            _screenSize = new Vector2(screenWidth, screenHeight);
        }

        public void RenderModel(ObjModel model)
        {
            _model = model; // 设置_model字段的值
            foreach (var face in model.Groups[1].Faces)
            {
                var vertices = face.Vertices.Select(v => model.Vertices[v.Vertex - 1]).ToList();
                var textures = face.Vertices.Select(v => model.VertexTextures[v.Texture.Value - 1]).ToList();
                var triangle3D = new Triangle3D(
                    new Vector3(vertices[0].X, vertices[0].Y, vertices[0].Z),
                    new Vector3(vertices[1].X, vertices[1].Y, vertices[1].Z),
                    new Vector3(vertices[2].X, vertices[2].Y, vertices[2].Z),
                    new Vector3(textures[0].U, textures[1].U,textures[2].U),
                    new Vector3(textures[0].V, textures[1].V,textures[2].V)
                );

                _class2.FillTriangle3D(triangle3D, _screenSize);
            }
        }

        
    }
}