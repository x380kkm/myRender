using System.Collections.Generic;
using System.Numerics;
using MyMath.Vertex.AbstractClasses;
using MyMath.Triangle._3D.Interfaces;
using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;

namespace MyMath.Triangle._3D.Implementations
{
    public class Vertex3DWeightDataProcessor : AbstractVertexWeightDataProcessor<Vector3, float>, IVertex3DWeightDataProcessor<float>
    {
        private readonly I3DTriangleWeightCalculator _triangleWeightCalculator;

        public Vertex3DWeightDataProcessor(I3DTriangleWeightCalculator triangleWeightCalculator)
            : base(new FloatWeightedAverageCalculator())
        {
            _triangleWeightCalculator = triangleWeightCalculator;
        }

        public override IEnumerable<float> CalculateWeights(IEnumerable<Vector3> vertices, Vector3 targetVertex)
        {
            var verticesList = new List<Vector3>(vertices);
            for (int i = 0; i < verticesList.Count; i++)
            {
                var weights = _triangleWeightCalculator.CalculateWeight(verticesList[i], verticesList[(i + 1) % verticesList.Count], verticesList[(i + 2) % verticesList.Count], targetVertex);
                yield return weights.Item1;
            }
        }
    }
}