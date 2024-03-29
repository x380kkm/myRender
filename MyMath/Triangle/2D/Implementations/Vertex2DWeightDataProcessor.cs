﻿// 文件：MyMath/Triangle/2D/Implementations/Vertex2DWeightDataProcessor.cs

using System.Numerics;
using MyMath.Vertex.AbstractClasses;
using MyMath.Triangle._2D.Interfaces;
using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces; // 添加这行
using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;

namespace MyMath.Triangle._2D.Implementations;

/// <summary>
/// Implements the IVertex2DWeightDataProcessor interface for processing 2D vertex weight data.
/// 实现IVertex2DWeightDataProcessor接口，用于处理2D顶点权重数据。
/// </summary>
public class Vertex2DWeightDataProcessor : AbstractVertexWeightDataProcessor<Vector2, float>, IVertex2DWeightDataProcessor<float>
{
    private readonly I2DTriangleWeightCalculator _triangleWeightCalculator;
    /// <summary>
    /// Implements the IVertex2DWeightDataProcessor interface for processing 2D vertex weight data.
    /// 实现IVertex2DWeightDataProcessor接口，用于处理2D顶点权重数据。
    /// </summary>
    ///  <param name="triangleWeightCalculator">The 2D triangle weight calculator. 2D三角形权重计算器。</param>
    public Vertex2DWeightDataProcessor(I2DTriangleWeightCalculator triangleWeightCalculator)
        : base(new FloatWeightedAverageCalculator())
    {
        _triangleWeightCalculator = triangleWeightCalculator;
    }
    /// <summary>
    /// Calculates the weights for a collection of 2D vertices.
    /// 计算一组2D顶点的权重。
    /// </summary>
    /// <param name="vertices">The collection of 2D vertices. 2D顶点的集合。</param>
    /// <param name="targetVertex">The target vertex. 目标顶点。</param>
    /// <returns>The weights of the vertices. 顶点的权重。</returns>
    public override IEnumerable<float> CalculateWeights(IEnumerable<Vector2> vertices, Vector2 targetVertex)
    {
        var verticesList = new List<Vector2>(vertices);
        for (int i = 0; i < verticesList.Count; i++)
        {
            var weights = _triangleWeightCalculator.CalculateWeight(verticesList[i], verticesList[(i + 1) % verticesList.Count], verticesList[(i + 2) % verticesList.Count], targetVertex);
            yield return weights.Item1;
        }
    }
    /// <summary>
    /// Calculates the target data for a collection of 2D vertices and data.
    /// 计算一组2D顶点和数据的目标数据。
    /// </summary>
    /// <param name="vertices">The collection of 2D vertices. 2D顶点的集合。</param>
    /// <param name="data">The data associated with the vertices. 与顶点相关联的数据。</param>
    /// <param name="targetVertex">The target vertex. 目标顶点。</param>
    /// <param name="weightedAverageCalculator">The weighted average calculator. 加权平均计算器。</param>
    /// <returns>The target data. 目标数据。</returns>
    public override float CalculateTargetData(IEnumerable<Vector2> vertices, IEnumerable<float> data, Vector2 targetVertex, IWeightedAverageCalculator<float, float> weightedAverageCalculator)
    {
        var weights = CalculateWeights(vertices, targetVertex);
        var weightedData = new List<(float weight, float data)>();
        using (var dataEnumerator = data.GetEnumerator())
        {
            foreach (var weight in weights)
            {
                dataEnumerator.MoveNext();
                weightedData.Add((weight, dataEnumerator.Current));
            }
        }
        return weightedAverageCalculator.CalculateWeightedAverage(weightedData);
    }
}