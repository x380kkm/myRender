using System.Numerics;
using MyMath.LinearCalculations.WeightedAverageCalculators.Interfaces;

namespace MyMath.Vertex.Interfaces
{
    public interface IVertexWeightedAverageCalculator<TData>
    {
        TData CalculateWeightedAverageAtVertex(IEnumerable<(Vector3 vertex, TData data)> vertexData, Vector3 targetVertex);
        void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> weightedAverageCalculator);
    }
}