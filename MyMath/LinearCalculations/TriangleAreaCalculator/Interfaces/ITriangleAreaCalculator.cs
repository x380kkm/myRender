// MyMath/LinearCalculations/Interfaces/ITriangleAreaCalculator.cs
namespace MyMath.LinearCalculations.TriangleAreaCalculator.Interfaces;

/// <summary>
/// Interface for calculating the area of a triangle.
/// 用于计算三角形面积的接口。
/// </summary>
public interface ITriangleAreaCalculator<TPoint>
{
    /// <summary>
    /// Calculates the area of a triangle given its three vertices.
    /// 根据三角形的三个顶点计算其面积。
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <returns>The area of the triangle. 三角形的面积。</returns>
    float CalculateArea(TPoint pointA, TPoint pointB, TPoint pointC);
}