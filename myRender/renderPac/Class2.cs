using System.Numerics;
using System.Windows.Media;
using Pac.Tool.Math;

namespace myRender.renderPac
{
    public class Class2
    {
        private Renderer _renderer;
        private Class1 _class1;

        public Class2(Renderer renderer)
        {
            this._renderer = renderer;
            this._class1 = new Class1(_renderer);
        }

        public void FillTriangle3D(Triangle3D triangle3D, Color color, Vector2 max2D)
        {
            var triangle = triangle3D.ProjectTo2D(max2D);
            for (int y = (int)triangle.PointA.Y; y <= triangle.PointC.Y; y++)
            {
                if (y < triangle.PointB.Y)
                {
                    int xa = (int)Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);
                    int xb = (int)Interpolate(triangle.PointA.X, triangle.PointB.X, triangle.PointA.Y, triangle.PointB.Y, y);
                    DrawHorizontalLine(xa, xb, y, color, triangle3D);
                }
                else
                {
                    int xa = (int)Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);
                    int xb = (int)Interpolate(triangle.PointB.X, triangle.PointC.X, triangle.PointB.Y, triangle.PointC.Y, y);
                    DrawHorizontalLine(xa, xb, y, color, triangle3D);
                }
            }
        }

        private void DrawHorizontalLine(int x1, int x2, int y, Color color, Triangle3D triangle3D)
        {
            for (int x = x1; x <= x2; x++)
            {
                float depth = triangle3D.GetDepth(new Vector2(x, y));
                _renderer.DrawPoint(x, y, color, depth);
            }
        }

        private float Interpolate(float x1, float x2, float y1, float y2, float y)
        {
            if (System.Math.Abs(y1 - y2) < 1)
            {
                return x1;
            }
            else
            {
                return x1 + (x2 - x1) * (y - y1) / (y2 - y1);
            }
        }
    }
}