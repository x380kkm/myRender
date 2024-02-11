// MyMath/Triangle/2D/Implementations/TriangleAreaCalculator2D.cs
using System.Numerics;
using MyMath.LinearCalculations.TriangleAreaCalculator.AbstractClasses;
using MyMath.Triangle._2D.Interfaces;

namespace MyMath.Triangle._2D.Implementations;

/// <summary>
/// Implements the I2DTriangleAreaCalculator interface for calculating the area of a 2D triangle.
/// 实现I2DTriangleAreaCalculator接口，用于计算2D三角形的面积。
/// </summary>
public class TriangleAreaCalculator2D : AbstractTriangleAreaCalculator<Vector2>, I2DTriangleAreaCalculator
{
    /// <summary>
    /// Calculates the area of a triangle given its three vertices.
    /// 根据三角形的三个顶点计算其面积。
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <param name="targetPoint">The target point. 目标点。</param>
    /// <returns>The weights of the vertices. 顶点的权重。</returns>
    public override float CalculateArea(Vector2 pointA, Vector2 pointB, Vector2 pointC)
    {
        var ab = pointB - pointA;
        var ac = pointC - pointA;
        return 0.5f * Math.Abs(ab.X * ac.Y - ab.Y * ac.X);
    }
}