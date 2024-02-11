using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;

/// <summary>
/// Calculates the weight of the given triangle's vertices.
/// 计算给定三角形顶点的权重。
/// </summary>
public abstract class AbstractTriangleWeightCalculator<TPoint> : ITriangleWeightCalculator<TPoint>
{
    private IWeightCalculationStrategy<TPoint>? _strategy;
    /// <summary>
    /// Sets the strategy for calculating the weight of a triangle's vertices.
    /// 设置计算三角形顶点权重的策略。
    /// </summary>
    /// <param name="strategy">The weight calculation strategy. 权重计算策略。</param>
    public void SetStrategy(IWeightCalculationStrategy<TPoint>? strategy)
    {
        _strategy = strategy;
    }
    /// <summary>
    /// Calculates the weight of the given triangle's vertices using the set strategy.
    /// 使用设置的策略计算给定三角形顶点的权重。
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle. 三角形的第一个顶点。</param>
    /// <param name="pointB">The second vertex of the triangle. 三角形的第二个顶点。</param>
    /// <param name="pointC">The third vertex of the triangle. 三角形的第三个顶点。</param>
    /// <param name="targetPoint">The target point. 目标点。</param>
    /// <returns>The weights of the vertices. 顶点的权重。</returns>
    public (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint)
    {
        if (_strategy != null) return _strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);
        else throw new Exception("No strategy set for weight calculation.");
    }
}