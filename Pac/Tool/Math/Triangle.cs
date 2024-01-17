using System;
using System.Numerics;
namespace Pac.Tool.Math;

public class Triangle
{
    public Vector2 PointA { get; set; }
    public Vector2 PointB { get; set; }
    public Vector2 PointC { get; set; }
    public Triangle(Vector2 a, Vector2 b, Vector2 c)
    {
        PointA = a;
        PointB = b;
        PointC = c;
    }

    Triangle? NextTriangle()
    {
        var center = (PointA + PointB + PointC) / 3;
        var deltaX = PointA-center;
        var deltaY = PointB-center;
        var deltaZ = PointC-center;
        var nextA = PointA;
        var nextB = PointB;
        var nextC = PointC;
        var fg = false;
        if (System.Math.Abs(deltaX.X-center.X)>0.9)
        {
            fg = true;
            if (deltaX.X > center.X)
            {
                nextA.X--;
            }
            else
            {
                nextA.X++;
            }
        }
        if (System.Math.Abs(deltaX.Y-center.Y)>0.9)
        {
            fg = true;
            if (deltaX.Y > center.Y)
            {
                nextA.Y--;
            }
            else
            {
                nextA.Y++;
            }
        }
        if (System.Math.Abs(deltaY.X-center.X)>0.9)
        {
            fg = true;
            if (deltaY.X > center.X)
            {
                nextB.X--;
            }
            else
            {
                nextB.X++;
            }
        }
        if (System.Math.Abs(deltaY.Y-center.Y)>0.9)
        {
            fg = true;
            if (deltaY.Y > center.Y)
            {
                nextB.Y--;
            }
            else
            {
                nextB.Y++;
            }
        }
        if (System.Math.Abs(deltaZ.X-center.X)>0.9)
        {
            fg = true;
            if (deltaZ.X > center.X)
            {
                nextC.X--;
            }
            else
            {
                nextC.X++;
            }
        }
        
        if (System.Math.Abs(deltaZ.Y-center.Y)>0.9)
        {
            fg = true;
            if (deltaZ.Y > center.Y)
            {
                nextC.Y--;
            }
            else
            {
                nextC.Y++;
            }
        }

        if (!fg)
            return null; 
        return new Triangle(nextA,nextB,nextC);
    
    }







}