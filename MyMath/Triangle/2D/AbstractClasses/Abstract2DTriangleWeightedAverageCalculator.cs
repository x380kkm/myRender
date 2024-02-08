using System.Numerics;
using MyMath.Triangle._2D.Interfaces;
using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.Triangle._2D.AbstractClasses
{
    public abstract class Abstract2DTriangleWeightedAverageCalculator<TData> : I2DTriangleWeightedAverageCalculator<TData>
    {
        protected IWeightedAverageCalculator<float, TData> weightedAverageCalculator;

        public abstract TData CalculateWeightedAverageAtVertex(IEnumerable<(Vector3 vertex, TData data)> vertexData, Vector3 targetVertex);

        public void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> calculator)
        {
            this.weightedAverageCalculator = calculator;
        }
    }
}