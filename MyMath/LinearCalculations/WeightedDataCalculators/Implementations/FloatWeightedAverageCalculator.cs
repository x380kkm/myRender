using MyMath.LinearCalculations.WeightedDataCalculators.AbstractClasses;

namespace MyMath.LinearCalculations.WeightedDataCalculators.Implementations;
/// <summary>
/// Implements the IWeightedAverageCalculator interface for calculating the weighted average of float data.
/// 实现IWeightedAverageCalculator接口，用于计算浮点数据的加权平均值。
/// </summary>
public class FloatWeightedAverageCalculator : AbstractWeightedAverageCalculator<float, float>
{
    /// <summary>
    /// Implements the IWeightedAverageCalculator interface for calculating the weighted average of float data.
    /// 实现IWeightedAverageCalculator接口，用于计算浮点数据的加权平均值。
    /// </summary>
    public override float CalculateWeightedAverage(IEnumerable<(float weight, float data)> weightedData)
    {
        var weightedDataList = ConvertToIList(weightedData);
        var totalWeight = CalculateTotalWeight(weightedDataList);
        return weightedDataList.Aggregate(0f, (acc, wd) => acc + wd.weight * wd.data) / totalWeight;
    }
}