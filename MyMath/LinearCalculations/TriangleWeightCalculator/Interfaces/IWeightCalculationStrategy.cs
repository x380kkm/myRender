namespace MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

/// <summary>
/// Interface for defining a strategy to calculate the weight of a triangle's vertices.
/// 用于定义计算三角形顶点权重策略的接口。
/// </summary>
public interface IWeightCalculationStrategy<TPoint>
{   
    /// <summary>
    /// Calculates the weight of the given triangle's vertices using the defined strategy.
    /// 使用定义的策略计算给定三角形顶点的权重。
    /// </summary>
    (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint);
}