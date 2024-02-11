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
    public abstract float CalculateArea(TPoint pointA, TPoint pointB, TPoint pointC);
}