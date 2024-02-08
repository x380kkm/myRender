// Abstract3DTriangleWeightedAverageCalculator.cs
using System.Numerics;
using MyMath.Triangle._3D.Interfaces;
using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.Triangle._3D.AbstractClasses
{
    public abstract class Abstract3DTriangleWeightedAverageCalculator<TData> : I3DTriangleWeightedAverageCalculator<TData>
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