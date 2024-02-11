// MyMath/Triangle/3D/Implementations/TriangleAreaCalculator3D.cs
using System.Numerics;
using MyMath.LinearCalculations.TriangleAreaCalculator.AbstractClasses;
using MyMath.Triangle._3D.Interfaces;

namespace MyMath.Triangle._3D.Implementations;

/// <summary>
/// Implements the I3DTriangleAreaCalculator interface for calculating the area of a 3D triangle.
/// 实现I3DTriangleAreaCalculator接口，用于计算3D三角形的面积。
/// </summary>
public class TriangleAreaCalculator3D : AbstractTriangleAreaCalculator<Vector3>, I3DTriangleAreaCalculator
{
    /// <summary>
    /// Calculates the area of a triangle given its three vertices.
    /// 根据三角形的三个顶点计算其面积。
    /// </summary>
    public override float CalculateArea(Vector3 pointA, Vector3 pointB, Vector3 pointC)
    {
        var ab = pointB - pointA;
        var ac = pointC - pointA;
        var crossProduct = Vector3.Cross(ab, ac);
        return 0.5f * crossProduct.Length();
    }
}