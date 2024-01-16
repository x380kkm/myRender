namespace myRender.pac;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Numerics;
public class Class1
{
    //绘制点
    public static void DrawPoint(Canvas canvas, int x, int y, int xs = 1, int ys = 1, Color color = default) =>
        canvas.Children.Add(new Rectangle { Fill = new SolidColorBrush(color == default ? Colors.Black : color), Width = xs, Height = ys, Margin = new Thickness(x - xs / 2, y - ys / 2, 0, 0) });
    //绘制线
    public static void DrawLine_Attempt1(Canvas canvas, Color color = default, Vector2 p0 = default, Vector2 p1 = default)
    {
        if (p0 == default || p1 == default) return;
        color = color == default ? Colors.Black : color;
        for (float t = 0; t < 1; t += 0.01f)
            DrawPoint(canvas, (int)(p0.X + (p1.X - p0.X) * t), (int)(p0.Y + (p1.Y - p0.Y) * t), color: color);
    }
    
}