using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;
using MyMath.Triangle._3D.Interfaces;

namespace MyMath.Triangle._3D.Implementations;

/// <summary>
/// Implements the I3DTriangleWeightCalculator interface for calculating the weight of a 3D triangle.
/// 实现I3DTriangleWeightCalculator接口，用于计算3D三角形的权重。
/// </summary>
public class TriangleWeightCalculator3D : AbstractTriangleWeightCalculator<Vector3>, I3DTriangleWeightCalculator
{
    /// <summary>
    /// Constructor that initializes the weight calculation strategy.
    /// 初始化权重计算策略的构造函数。
    /// </summary>
    public TriangleWeightCalculator3D()
    {
        SetStrategy(new AreaBasedWeightStrategy3D());
    }
}