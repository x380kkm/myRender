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
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <param name="targetPoint">The target point. 目标点。</param>
    /// <returns>The weights of the vertices. 顶点的权重。</returns>
    public abstract (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint);
}