using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;
using MyMath.Triangle._2D.Interfaces;

namespace MyMath.Triangle._2D.Implementations;

/// <summary>
/// Calculates the target data for a collection of 2D vertices and data.
/// 计算一组2D顶点和数据的目标数据。
/// </summary>
public class TriangleWeightCalculator2D : AbstractTriangleWeightCalculator<Vector2>, I2DTriangleWeightCalculator
{
    /// <summary>
    /// Constructor that initializes the weight calculation strategy.
    /// 初始化权重计算策略的构造函数。
    /// </summary>
    public TriangleWeightCalculator2D()
    {
        SetStrategy(new AreaBasedWeightStrategy2D());
    }
}