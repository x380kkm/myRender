using System.Collections.Generic;
using System.Numerics;
using MyMath.Vertex.AbstractClasses;
using MyMath.Triangle._2D.Interfaces;
using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;

namespace MyMath.Triangle._2D.Implementations
{
    public class Vertex2DWeightDataProcessor : AbstractVertexWeightDataProcessor<Vector2, float>, IVertex2DWeightDataProcessor<float>
    {
        private readonly I2DTriangleWeightCalculator _triangleWeightCalculator;

        public Vertex2DWeightDataProcessor(I2DTriangleWeightCalculator triangleWeightCalculator)
            : base(new FloatWeightedAverageCalculator())
        {
            _triangleWeightCalculator = triangleWeightCalculator;
        }

        public override IEnumerable<float> CalculateWeights(IEnumerable<Vector2> vertices, Vector2 targetVertex)
        {
            var verticesList = new List<Vector2>(vertices);
            for (int i = 0; i < verticesList.Count; i++)
            {
                var weights = _triangleWeightCalculator.CalculateWeight(verticesList[i], verticesList[(i + 1) % verticesList.Count], verticesList[(i + 2) % verticesList.Count], targetVertex);
                yield return weights.Item1;
            }
        }
    }
}