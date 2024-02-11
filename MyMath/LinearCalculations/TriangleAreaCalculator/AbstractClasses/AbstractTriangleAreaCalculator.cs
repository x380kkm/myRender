// MyMath/LinearCalculations/Implementations/AbstractTriangleAreaCalculator.cs

using MyMath.LinearCalculations.TriangleAreaCalculator.Interfaces;

namespace MyMath.LinearCalculations.TriangleAreaCalculator.AbstractClasses;

/// <summary>
/// Abstract class for calculating the area of a triangle.
/// 计算三角形面积的抽象类。
/// </summary>
public abstract class AbstractTriangleAreaCalculator<TPoint> : ITriangleAreaCalculator<TPoint>
{
    /// <summary>
    /// Abstract method for calculating the area of a triangle given its three vertices.
    /// 根据三角形的三个顶点计算其面积的抽象方法。
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <returns>The area of the triangle. 三角形的面积。</returns>
    public abstract float CalculateArea(TPoint pointA, TPoint pointB, TPoint pointC);
}