using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.Triangle._2D.Implementations;

/// <summary>
/// Class for calculating the weight of a triangle's vertices.
/// 用于计算三角形顶点权重的类。
/// </summary>
public class AreaBasedWeightStrategy2D : IWeightCalculationStrategy<Vector2>
{
    /// <summary>
    /// Calculates the weight of the given triangle's vertices.
    /// 计算给定三角形顶点的权重。
    /// </summary>
    public (float, float, float) CalculateWeight(Vector2 pointA, Vector2 pointB, Vector2 pointC, Vector2 targetPoint)
    {
            
            
        var calculator = new TriangleAreaCalculator2D();
        float weightA = calculator.CalculateArea(targetPoint, pointB, pointC);
        float weightB = calculator.CalculateArea(targetPoint, pointA, pointC);
        float weightC = calculator.CalculateArea(targetPoint, pointA, pointB);

        float totalWeight = weightA + weightB + weightC;

        return (weightA / totalWeight, weightB / totalWeight, weightC / totalWeight);
    }
}