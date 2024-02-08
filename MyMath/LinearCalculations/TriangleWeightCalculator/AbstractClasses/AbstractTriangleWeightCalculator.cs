using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses
{
    public abstract class AbstractTriangleWeightCalculator<TPoint> : ITriangleWeightCalculator<TPoint>
    {
        private IWeightCalculationStrategy<TPoint> _strategy;

        public void SetStrategy(IWeightCalculationStrategy<TPoint> strategy)
        {
            _strategy = strategy;
        }

        public (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint)
        {
            return _strategy.CalculateWeight(pointA, pointB, pointC, targetPoint);
        }
    }
}