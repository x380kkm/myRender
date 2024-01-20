using System.Numerics;
using System.Windows.Media;

namespace myRender.renderPac
{
    public class Class1
    {
        private Renderer _renderer;

        public Class1(Renderer renderer)
        {
            this._renderer = renderer;
        }

        public void DrawLine(Color color, Vector2 p0, Vector2 p1)
        {
            int x0 = (int)p0.X, y0 = (int)p0.Y, x1 = (int)p1.X, y1 = (int)p1.Y;
            int dx = System.Math.Abs(x1 - x0), dy = System.Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1, sy = y0 < y1 ? 1 : -1;
            var err = dx - dy;

            while (true)
            {
                _renderer.DrawPoint(x0, y0, 0);

                if (x0 == x1 && y0 == y1) break;

                var e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }
    }
}