namespace MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

/// <summary>
/// Interface for calculating the weight of a triangle's vertices.
/// 用于计算三角形顶点权重的接口。
/// </summary>
public interface ITriangleWeightCalculator<TPoint>
{
    /// <summary>
    /// Calculates the weight of the given triangle's vertices.
    /// 计算给定三角形顶点的权重。
    /// </summary>
    (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint);
}