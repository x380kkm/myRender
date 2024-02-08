using System.Collections.Generic;
using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces;
using MyMath.Vertex.Interfaces;

namespace MyMath.Vertex.AbstractClasses
{
    public abstract class AbstractVertexWeightDataProcessor<TVertex, TData> : IVertexWeightDataProcessor<TVertex, TData>
    {
        protected IWeightedAverageCalculator<float, TData> WeightedAverageCalculator;

        public AbstractVertexWeightDataProcessor(IWeightedAverageCalculator<float, TData> weightedAverageCalculator)
        {
            this.WeightedAverageCalculator = weightedAverageCalculator;
        }

        public abstract IEnumerable<float> CalculateWeights(IEnumerable<TVertex> vertices, TVertex targetVertex);

        public TData CalculateWeightedAverage(IEnumerable<(float weight, TData data)> weightedData)
        {
            return this.WeightedAverageCalculator.CalculateWeightedAverage(weightedData);
        }

        public void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> weightedAverageCalculator)
        {
            this.WeightedAverageCalculator = weightedAverageCalculator;
        }
    }
}