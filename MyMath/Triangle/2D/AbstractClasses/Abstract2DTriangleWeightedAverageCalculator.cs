// Abstract2DTriangleWeightedAverageCalculator.cs
using System.Numerics;
using MyMath.Triangle._2D.Interfaces;
using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.Triangle._2D.AbstractClasses
{
    public abstract class Abstract2DTriangleWeightedAverageCalculator<TData> : I2DTriangleWeightedAverageCalculator<TData>
    {
        protected IWeightedAverageCalculator<float, TData> weightedAverageCalculator;

        public abstract IEnumerable<float> CalculateWeights(IEnumerable<Vector3> vertices, Vector3 targetVertex);
        public abstract TData CalculateWeightedAverage(IEnumerable<(float weight, TData data)> weightedData);

        public void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> calculator)
        {
            this.weightedAverageCalculator = calculator;
        }
    }
}