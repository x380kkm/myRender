using System.Numerics;
using System.Windows.Media;
using Pac.Tool.Math;

namespace myRender.renderPac
{
    public class rendererTest
    {
        private Renderer _renderer;

        public rendererTest(Renderer renderer)
        {
            this._renderer = renderer;
        }

        public void FillTriangle3D(Triangle3D triangle3D, Vector2 max2D)
        {
            var triangle = triangle3D.ProjectTo2D(max2D);
            FillTriangle2D(triangle);
        }

        public void FillTriangle2D(Triangle triangle)
        {
            for (int y = (int)triangle.PointA.Y; y <= triangle.PointC.Y; y++)
            {
                if (y < triangle.PointB.Y)
                {
                    float xa = Interpolate(triangle.PointA.X, triangle.PointB.X, triangle.PointA.Y, triangle.PointB.Y, y);
                    float xb = Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);
                    DrawHorizontalLine((int)System.Math.Round(xa), (int)System.Math.Round(xb), y);
                }
                else
                {
                    float xa = Interpolate(triangle.PointB.X, triangle.PointC.X, triangle.PointB.Y, triangle.PointC.Y, y);
                    float xb = Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);
                    DrawHorizontalLine((int)System.Math.Round(xa), (int)System.Math.Round(xb), y);
                }
            }
        }

        private void DrawHorizontalLine(int x1, int x2, int y)
        {
            for (int x = x1; x <= x2; x++)
            {
                _renderer.DrawPoint(x, y, 0);
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