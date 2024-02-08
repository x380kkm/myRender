// MyMath/Triangle/3D/Implementations/TriangleAreaCalculator3D.cs
using System.Numerics;
using MyMath.LinearCalculations.TriangleAreaCalculator.AbstractClasses;
using MyMath.Triangle._3D.Interfaces;

namespace MyMath.Triangle._3D.Implementations
{
    public class TriangleAreaCalculator3D : AbstractTriangleAreaCalculator<Vector3>, I3DTriangleAreaCalculator
    {
        public override float CalculateArea(Vector3 pointA, Vector3 pointB, Vector3 pointC)
        {
            var ab = pointB - pointA;
            var ac = pointC - pointA;
            var crossProduct = Vector3.Cross(ab, ac);
            return 0.5f * crossProduct.Length();
        }
    }
}