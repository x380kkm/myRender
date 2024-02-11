using System.Numerics;
namespace MyMath.Triangle._3D.Interfaces;
/// <summary>
/// Defines a method for calculating the normal of a triangle.
/// 定义计算三角形法线的方法。
/// </summary>
public interface ITriangleNormalCalculator
{
    /// <summary>
    /// Calculates the normal of a triangle given its three vertices.
    /// 根据三角形的三个顶点计算其法线。
    /// </summary>
    Vector3 CalculateNormal(Vector3 pointA, Vector3 pointB, Vector3 pointC);
}
