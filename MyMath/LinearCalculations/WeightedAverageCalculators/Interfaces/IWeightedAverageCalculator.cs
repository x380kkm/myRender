namespace MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces
{
    public interface IWeightedAverageCalculator<TWeight, TData>
    {
        TData CalculateWeightedAverage(IEnumerable<(TWeight weight, TData data)> weightedData);
    }
}