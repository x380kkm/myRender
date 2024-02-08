using System.Numerics;
namespace MyMath.Triangle._3D.Interfaces;
public interface ITriangleNormalCalculator
{
    Vector3 CalculateNormal(Vector3 pointA, Vector3 pointB, Vector3 pointC);
}
