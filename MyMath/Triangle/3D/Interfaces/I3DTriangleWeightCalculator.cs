using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.Triangle._3D.Interfaces;

/// <summary>
/// Defines a method for calculating the weight of a 3D triangle.
/// 定义计算3D三角形权重的方法。
/// </summary>
public interface I3DTriangleWeightCalculator : ITriangleWeightCalculator<Vector3>
{
}