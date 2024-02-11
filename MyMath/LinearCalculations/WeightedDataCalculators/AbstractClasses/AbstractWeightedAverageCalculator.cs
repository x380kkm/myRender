using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces;

namespace MyMath.LinearCalculations.WeightedDataCalculators.AbstractClasses;

/// <summary>
/// Abstract class for calculating the weighted average of data.
/// 用于计算数据的加权平均值的抽象类。
/// </summary>
public abstract class AbstractWeightedAverageCalculator<TWeight, TData> : IWeightedAverageCalculator<TWeight, TData>
    where TWeight : struct, IComparable, IComparable<TWeight>, IConvertible, IEquatable<TWeight>, IFormattable
{
    /// <summary>
    /// Calculates the weighted average of the given data.
    /// 计算给定数据的加权平均值。
    /// </summary>
    public abstract TData CalculateWeightedAverage(IEnumerable<(TWeight weight, TData data)> weightedData);

    /// <summary>
    /// Converts the given data to a list.
    /// 将给定的数据转换为列表。
    /// </summary>
    protected IList<(TWeight weight, TData data)> ConvertToIList(IEnumerable<(TWeight weight, TData data)> weightedData)
    {
        return weightedData as IList<(TWeight weight, TData data)> ?? weightedData.ToList();
    }
    /// <summary>
    /// Calculates the total weight of the given data.
    /// 计算给定数据的总权重。
    /// </summary>
    protected TWeight CalculateTotalWeight(IList<(TWeight weight, TData data)> weightedDataList)
    {
        return (TWeight)Convert.ChangeType(weightedDataList.Sum(wd => Convert.ToDouble(wd.weight)), typeof(TWeight));
    }
}