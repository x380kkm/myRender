namespace myRender.renderPac;
using System;
using myRender.renderPac;
using Pac.Tool.Math;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
public class Class2
{
    public static void DrawTriangle(Canvas canvas, Color color, Vector2 pointA, Vector2 pointB, Vector2 pointC, bool full = true)
    {
        if (full)
        {
            var triangle = new Triangle(pointA, pointB, pointC);
            
            while (triangle != null)
            {
                DrawTriangle(canvas, color, triangle.PointA, triangle.PointB, triangle.PointC);
                triangle = triangle.NextTriangle(1, 1.0f);
            }
        }
        else
        {
            Class1.DrawLine(canvas, color, pointA, pointB);
            Class1.DrawLine(canvas, color, pointB, pointC);
            Class1.DrawLine(canvas, color, pointC, pointA);
        }
    }
}