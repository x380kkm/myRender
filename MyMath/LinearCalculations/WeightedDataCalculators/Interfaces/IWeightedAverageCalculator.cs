namespace MyMath.LinearCalculations.WeightedDataCalculators.Interfaces;

/// <summary>
/// Interface for calculating the weighted average of data.
/// 用于计算数据的加权平均值的接口。
/// </summary>
public interface IWeightedAverageCalculator<TWeight, TData>
{
    /// <summary>
    /// Calculates the weighted average of the given data.
    /// 计算给定数据的加权平均值。
    /// </summary>
    TData CalculateWeightedAverage(IEnumerable<(TWeight weight, TData data)> weightedData);
}