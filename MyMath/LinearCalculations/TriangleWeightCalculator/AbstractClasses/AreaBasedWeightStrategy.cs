using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;

/// <summary>
/// Abstract class for defining a strategy to calculate the weight of a triangle's vertices based on area.
/// 定义基于面积计算三角形顶点权重策略的抽象类。
/// </summary>
public abstract class AbstractAreaBasedWeightStrategy<TPoint> : IWeightCalculationStrategy<TPoint>
{
    /// <summary>
    /// Abstract method for calculating the weight of the given triangle's vertices using the defined strategy.
    /// 使用定义的策略计算给定三角形顶点的权重的抽象方法。
    /// </summary>
    public abstract (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint);
}