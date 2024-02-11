using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.Triangle._3D.Implementations;

/// <summary>
/// Implements the IWeightCalculationStrategy interface for calculating the weight of a 3D triangle based on its area.
/// 实现IWeightCalculationStrategy接口，根据3D三角形的面积计算其权重。
/// </summary>
public class AreaBasedWeightStrategy3D : IWeightCalculationStrategy<Vector3>
{
    /// <summary>
    /// Calculates the weight of a triangle given its three vertices and a target point.
    /// 根据三角形的三个顶点和一个目标点计算其权重。
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <param name="targetPoint">The target point. 目标点。</param>
    /// <returns>The weights of the vertices. 顶点的权重。</returns>
    public (float, float, float) CalculateWeight(Vector3 pointA, Vector3 pointB, Vector3 pointC, Vector3 targetPoint)
    {
        var calculator = new TriangleAreaCalculator3D();
        float weightA = calculator.CalculateArea(targetPoint, pointB, pointC);
        float weightB = calculator.CalculateArea(targetPoint, pointA, pointC);
        float weightC = calculator.CalculateArea(targetPoint, pointA, pointB);

        float totalWeight = weightA + weightB + weightC;

        return (weightA / totalWeight, weightB / totalWeight, weightC / totalWeight);
    }
}