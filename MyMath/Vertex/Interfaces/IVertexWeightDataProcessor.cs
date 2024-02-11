// 文件：MyMath/Vertex/Interfaces/IVertexWeightDataProcessor.cs

using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces;

namespace MyMath.Vertex.Interfaces;

/// <summary>
/// Defines methods for processing vertex weight data.
/// 定义处理顶点权重数据的方法。
/// </summary>
public interface IVertexWeightDataProcessor<TVertex, TData>
{
    /// <summary>
    /// Calculates the weights for a collection of vertices.
    /// 计算一组顶点的权重。
    /// </summary>
    IEnumerable<float> CalculateWeights(IEnumerable<TVertex> vertices, TVertex targetVertex);

    /// <summary>
    /// Calculates the weighted average for a collection of weighted data.
    /// 计算一组加权数据的加权平均值。
    /// </summary>
    TData CalculateWeightedAverage(IEnumerable<(float weight, TData data)> weightedData);

    /// <summary>
    /// Sets the weighted average calculator.
    /// 设置加权平均值计算器。
    /// </summary>
    void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> weightedAverageCalculator);

    /// <summary>
    /// Calculates the target data for a collection of vertices and data.
    /// 计算一组顶点和数据的目标数据。
    /// </summary>
    TData CalculateTargetData(IEnumerable<TVertex> vertices, IEnumerable<TData> data, TVertex targetVertex, IWeightedAverageCalculator<float, TData> weightedAverageCalculator);
}