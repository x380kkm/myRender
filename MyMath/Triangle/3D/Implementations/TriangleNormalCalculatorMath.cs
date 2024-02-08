using System.Numerics;
using MyMath.Triangle._3D.Interfaces;
namespace MyMath.Triangle._3D.Implementations
{

    public class TriangleNormalCalculatorMath : ITriangleNormalCalculator
    {
        public Vector3 CalculateNormal(Vector3 pointA, Vector3 pointB, Vector3 pointC)
        {
            Vector3 ab = pointB - pointA;
            Vector3 ac = pointC - pointA;
            Vector3 normal = Vector3.Cross(ab, ac);
            return Vector3.Normalize(normal);
        }
    }
}