using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.LinearCalculations.WeightedAverageCalculators.AbstractClasses
{
    public abstract class AbstractWeightedAverageCalculator<TWeight, TData> : IWeightedAverageCalculator<TWeight, TData>
        where TWeight : struct, IComparable, IComparable<TWeight>, IConvertible, IEquatable<TWeight>, IFormattable
    {
        public abstract TData CalculateWeightedAverage(IEnumerable<(TWeight weight, TData data)> weightedData);

        protected IList<(TWeight weight, TData data)> ConvertToIList(IEnumerable<(TWeight weight, TData data)> weightedData)
        {
            return weightedData as IList<(TWeight weight, TData data)> ?? weightedData.ToList();
        }

        protected TWeight CalculateTotalWeight(IList<(TWeight weight, TData data)> weightedDataList)
        {
            return (TWeight)Convert.ChangeType(weightedDataList.Sum(wd => Convert.ToDouble(wd.weight)), typeof(TWeight));
        }
    }
}