using MyMath.LinearCalculations.WeightedAverageCalculators.AbstractClasses;
namespace MyMath.LinearCalculations.WeightedAverageCalculators.Implementations
{
    public class FloatWeightedAverageCalculator : AbstractWeightedAverageCalculator<float, float>
    {
        public override float CalculateWeightedAverage(IEnumerable<(float weight, float data)> weightedData)
        {
            var weightedDataList = ConvertToIList(weightedData);
            var totalWeight = CalculateTotalWeight(weightedDataList);
            return weightedDataList.Aggregate(0f, (acc, wd) => acc + wd.weight * wd.data) / totalWeight;
        }
    }
}