// MyMath/Triangle/2D/Implementations/TriangleAreaCalculator2D.cs
using System.Numerics;
using MyMath.LinearCalculations.TriangleAreaCalculator.AbstractClasses;
using MyMath.Triangle._2D.Interfaces;

namespace MyMath.Triangle._2D.Implementations
{
    public class TriangleAreaCalculator2D : AbstractTriangleAreaCalculator<Vector2>, I2DTriangleAreaCalculator
    {
        public override float CalculateArea(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            var ab = pointB - pointA;
            var ac = pointC - pointA;
            return 0.5f * System.Math.Abs(ab.X * ac.Y - ab.Y * ac.X);
        }
    }
}