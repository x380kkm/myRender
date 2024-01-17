namespace myRender.renderPac;
using System;
using myRender.renderPac;
using Pac.Tool.Math;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;

public class Class2
{
    public static void DrawTriangle(Canvas canvas, Color color, Vector2 pointA, Vector2 pointB, Vector2 pointC )
    {
        
            var triangle = new Triangle(pointA, pointB, pointC);
            Triangle? nextTriangle;
            int iterationCount = 0;
            const int maxIterations = 5000; // 设置最大迭代次数以防止无限循环
            do
            {
                Class1.DrawLine(canvas, color, triangle.PointA, triangle.PointB);
                Class1.DrawLine(canvas, color, triangle.PointB, triangle.PointC);
                Class1.DrawLine(canvas, color, triangle.PointA, triangle.PointC);
                nextTriangle = triangle.NextTriangle(1, 1.0f);
                iterationCount++;
                if (nextTriangle == null)
                    break;
                triangle = nextTriangle;

            } while (iterationCount < maxIterations); 
            /*

            else
            {
                Class1.DrawLine(canvas, color, pointA, pointB);
                Class1.DrawLine(canvas, color, pointB, pointC);
                Class1.DrawLine(canvas, color, pointC, pointA);
            }
            */
        
    }
}