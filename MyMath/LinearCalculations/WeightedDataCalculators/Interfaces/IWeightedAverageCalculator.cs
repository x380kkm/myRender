namespace MyMath.LinearCalculations.WeightedDataCalculators.Interfaces
{
    public interface IWeightedAverageCalculator<TWeight, TData>
    {
        TData CalculateWeightedAverage(IEnumerable<(TWeight weight, TData data)> weightedData);
    }
}