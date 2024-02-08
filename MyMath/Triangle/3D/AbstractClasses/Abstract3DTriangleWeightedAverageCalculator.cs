using System.Numerics;
using MyMath.Triangle._3D.Interfaces;
using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.Triangle._3D.AbstractClasses
{
    public abstract class Abstract3DTriangleWeightedAverageCalculator<TData> : I3DTriangleWeightedAverageCalculator<TData>
    {
        protected IWeightedAverageCalculator<float, TData> weightedAverageCalculator;

        public abstract TData CalculateWeightedAverageAtVertex(IEnumerable<(Vector3 vertex, TData data)> vertexData, Vector3 targetVertex);

        public void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> calculator)
        {
            this.weightedAverageCalculator = calculator;
        }
    }
}