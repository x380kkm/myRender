// 文件：MyMath/Vertex/Interfaces/IVertexWeightDataProcessor.cs
using System.Collections.Generic;
using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces;

namespace MyMath.Vertex.Interfaces
{
    public interface IVertexWeightDataProcessor<TVertex, TData>
    {
        IEnumerable<float> CalculateWeights(IEnumerable<TVertex> vertices, TVertex targetVertex);
        TData CalculateWeightedAverage(IEnumerable<(float weight, TData data)> weightedData);
        void SetWeightedAverageCalculator(IWeightedAverageCalculator<float, TData> weightedAverageCalculator);
    }
}