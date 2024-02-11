using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces;
using MyMath.Vertex.Interfaces;

namespace MyMath.Vertex.AbstractClasses;

/// <summary>
/// Abstract base class for vertex weight data processors.
/// 顶点权重数据处理器的抽象基类。
/// </summary>
public abstract class AbstractVertexWeightDataProcessor<TVertex, TData> : IVertexWeightDataProcessor<TVertex, TData>
{
    protected IWeightedAverageCalculator<float, TData> WeightedAverageCalculator;

    /// <summary>
    /// Constructor that initializes the weighted average calculator.
    /// 初始化加权平均值计算器的构造函数。
    /// </summary>
    public AbstractVertexWeightDataProcessor(IWeightedAverageCalculator<float, TData> weightedAverageCalculator)
    {
        this.WeightedAverageCalculator = weightedAverageCalculator;
    }

    /// <summary>
    /// Calculates the weights for a collection of vertices.
    /// 计算一组顶点的权重。
    /// </summary>
    public abstract IEnumerable<float> CalculateWeights(IEnumerable<TVertex> vertices, TVertex targetVertex);

    /// <summary>
    /// Calculates the weighted average for a collection of weighted data.
    /// 计算一组加权数据的加权平均值。
    /// </summary>
    public TData CalculateWeightedAverage(IEnumerable<(float weight, TData data)> weightedData)
    {
        return this.WeightedAverageCalculator.CalculateWeightedAverage(weightedData);
    }

    /// <summary>
    /// Sets the weighted average calculator.
    /// 设置加权平均值计算器。
    /// </summary>
    public void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> weightedAverageCalculator)
    {
        this.WeightedAverageCalculator = weightedAverageCalculator;
    }

    /// <summary>
    /// Calculates the target data for a collection of vertices and data.
    /// 从一组顶点和数据计算目标数据。
    /// </summary>
    public virtual TData CalculateTargetData(IEnumerable<TVertex> vertices, IEnumerable<TData> data, TVertex targetVertex, IWeightedAverageCalculator<float, TData> weightedAverageCalculator)
    {
        var weights = CalculateWeights(vertices, targetVertex);
        var weightedData = new List<(float weight, TData data)>();
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