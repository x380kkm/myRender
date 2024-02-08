using System.Collections.Generic;
using System.Numerics;
using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.Vertex.Interfaces
{
    public interface IVertexWeightedAverageCalculator<TData>
    {
        IEnumerable<float> CalculateWeights(IEnumerable<Vector3> vertices, Vector3 targetVertex);
        TData CalculateWeightedAverage(IEnumerable<(float weight, TData data)> weightedData);
        void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> weightedAverageCalculator);
    }
}