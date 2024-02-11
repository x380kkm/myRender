using System.Numerics;
using MyMath.Triangle._3D.Interfaces;
namespace MyMath.Triangle._3D.Implementations;

/// <summary>
/// Constructor that initializes the weight calculation strategy.
/// 初始化权重计算策略的构造函数。
/// </summary>
public class TriangleNormalCalculatorMath : ITriangleNormalCalculator
{
    /// <summary>
    /// Calculates the normal of a triangle given its three vertices.
    /// 根据三角形的三个顶点计算其法线。
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <returns>The normal of the triangle. 三角形的法线。</returns>
    public Vector3 CalculateNormal(Vector3 pointA, Vector3 pointB, Vector3 pointC)
    {
        Vector3 ab = pointB - pointA;
        Vector3 ac = pointC - pointA;
        Vector3 normal = Vector3.Cross(ab, ac);
        return Vector3.Normalize(normal);
    }
}