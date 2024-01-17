using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace myRender.renderPac;

public class Class1
{
    //绘制点
    #region PointDrawing
    public static void DrawPoint(Canvas canvas, int x, int y, int xs = 1, int ys = 1, Color color = default) =>
        canvas.Children.Add(new Rectangle { Fill = new SolidColorBrush(color == default ? Colors.Black : color), Width = xs, Height = ys, Margin = new Thickness(x - xs / 2, y - ys / 2, 0, 0) });
    #endregion
    //绘制线
    #region lineDrawing
    /*
    //逐点直线
    public static void DrawLine_Attempt(Canvas canvas, Color color = default, Vector2 p0 = default, Vector2 p1 = default, float step = 0.01f)
    {
        if (p0 == default || p1 == default) return;
        color = color == default ? Colors.Black : color;
        if (p0.X > p1.X) { (p0, p1) = (p1, p0); }
        for (float t = 0; t < 1; t += step)
            DrawPoint(canvas, (int)(p0.X + (p1.X - p0.X) * t), (int)(p0.Y + (p1.Y - p0.Y) * t), color: color);
    }
    */
    //Bresenham算法
    public static void DrawLine(Canvas canvas, Color color = default, Vector2 p0 = default, Vector2 p1 = default)
    {
        if (p0 == default || p1 == default) return;
        color = color == default ? Colors.Black : color;
        int x0 = (int)p0.X, y0 = (int)p0.Y, x1 = (int)p1.X, y1 = (int)p1.Y, dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0), sx = x0 < x1 ? 1 : -1, sy = y0 < y1 ? 1 : -1, err = dx - dy;
        while (x0 != x1 || y0 != y1) { DrawPoint(canvas, x0, y0, color: color); int e2 = 2 * err; if (e2 > -dy) { err -= dy; x0 += sx; } if (e2 < dx) { err += dx; y0 += sy; } }
    }
    #endregion


    
}