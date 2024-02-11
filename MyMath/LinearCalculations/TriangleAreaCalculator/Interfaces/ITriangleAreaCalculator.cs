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
    float CalculateArea(TPoint pointA, TPoint pointB, TPoint pointC);
}