using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses
{
    public abstract class AbstractAreaBasedWeightStrategy<TPoint> : IWeightCalculationStrategy<TPoint>
    {
        public abstract (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint);
    }
}