using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.Triangle._2D.Interfaces;

/// <summary>
/// Defines methods for processing 2D vertex weight data.
/// 定义处理2D顶点权重数据的方法。
/// </summary>
public interface I2DTriangleWeightCalculator : ITriangleWeightCalculator<Vector2>
{
}