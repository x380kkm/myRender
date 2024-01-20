using System.Numerics;
using System.Windows.Media;
using Pac.Tool.Math;

namespace myRender.renderPac
{
    public class Class2
    {
        private Renderer _renderer;
        private Vector3 _lightVector;
       //private Class1 _class1;

        public Class2(Renderer renderer,Vector3 lightVector)
        {
            this._renderer = renderer;
            this._lightVector = lightVector;
            //this._class1 = new Class1(_renderer);
        }

        public void FillTriangle3D(Triangle3D triangle3D, Vector2 max2D)
        {
            var triangle = triangle3D.ProjectTo2D(max2D);
            int yStart = (int)Math.Floor(triangle.PointA.Y);
            int yEnd = (int)Math.Ceiling(triangle.PointC.Y);

            for (int y = yStart; y <= yEnd; y++)
            {
                if (y < triangle.PointB.Y - 2)
                {
                    int xa = (int)Interpolate(triangle.PointA.X, triangle.PointB.X, triangle.PointA.Y, triangle.PointB.Y, y);
                    int xb = (int)Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);

                    DrawHorizontalLine(xa, xb, y, triangle3D, max2D);
                }
                else if (y > triangle.PointB.Y + 2)
                {
                    int xa = (int)Interpolate(triangle.PointB.X, triangle.PointC.X, triangle.PointB.Y, triangle.PointC.Y, y);
                    int xb = (int)Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);

                    DrawHorizontalLine(xa, xb, y, triangle3D, max2D);
                }
                else // y is in the range of PointB.Y +- 2
                {
                    // Method 1
                    int xa1 = (int)Interpolate(triangle.PointA.X, triangle.PointB.X, triangle.PointA.Y, triangle.PointB.Y, y);
                    int xb1 = (int)Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);

                    DrawHorizontalLine(xa1, xb1, y, triangle3D, max2D);

                    // Method 2
                    int xa2 = (int)Interpolate(triangle.PointB.X, triangle.PointC.X, triangle.PointB.Y, triangle.PointC.Y, y);
                    int xb2 = (int)Interpolate(triangle.PointA.X, triangle.PointC.X, triangle.PointA.Y, triangle.PointC.Y, y);

                    DrawHorizontalLine(xa2, xb2, y, triangle3D, max2D);
                }
            }
        }

        private void DrawHorizontalLine(int x1, int x2, int y, Triangle3D triangle3D, Vector2 max2D)
        {
            // 根据x1和x2的相对大小进行互换
            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
            }

            // 小值向下
            x1 = x1 - 1;
            // 大值向上
            x2 = x2 + 1;

            // 创建一个二维三角形
            Triangle triangle = triangle3D.ProjectTo2D(max2D);

            for (int x = x1; x <= x2; x++)
            {
                // 检查点是否在三角形内
                if (Triangle.Contains(new Vector2(x, y), triangle))
                {
                    float depth = triangle3D.GetDepth();
                    _renderer.DrawPoint(x, y, depth,triangle3D.GetNormal(),_lightVector);
                }
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