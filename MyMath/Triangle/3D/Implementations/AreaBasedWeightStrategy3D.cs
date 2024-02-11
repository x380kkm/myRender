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