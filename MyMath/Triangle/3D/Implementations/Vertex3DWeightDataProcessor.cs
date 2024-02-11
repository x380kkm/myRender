// 文件：MyMath/Triangle/3D/Implementations/Vertex3DWeightDataProcessor.cs

using System.Numerics;
using MyMath.Vertex.AbstractClasses;
using MyMath.Triangle._3D.Interfaces;
using MyMath.LinearCalculations.WeightedDataCalculators.Interfaces; // 添加这行
using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;

namespace MyMath.Triangle._3D.Implementations;

/// <summary>
/// Implements the IWeightCalculationStrategy interface for calculating the weight of a 3D triangle based on its area.
/// 实现IWeightCalculationStrategy接口，根据3D三角形的面积计算其权重。
/// </summary>
public class Vertex3DWeightDataProcessor : AbstractVertexWeightDataProcessor<Vector3, float>, IVertex3DWeightDataProcessor<float>
{
     
    private readonly I3DTriangleWeightCalculator _triangleWeightCalculator;
    /// <summary>
    /// Constructor that initializes the triangle weight calculator.
    /// 初始化三角形权重计算器的构造函数。
    /// </summary>
    public Vertex3DWeightDataProcessor(I3DTriangleWeightCalculator triangleWeightCalculator)
        : base(new FloatWeightedAverageCalculator())
    {
        _triangleWeightCalculator = triangleWeightCalculator;
    }
    /// <summary>
    /// Calculates the weights for a collection of 3D vertices.
    /// 计算一组3D顶点的权重。
    /// </summary>
    public override IEnumerable<float> CalculateWeights(IEnumerable<Vector3> vertices, Vector3 targetVertex)
    {
        var verticesList = new List<Vector3>(vertices);
        for (int i = 0; i < verticesList.Count; i++)
        {
            var weights = _triangleWeightCalculator.CalculateWeight(verticesList[i], verticesList[(i + 1) % verticesList.Count], verticesList[(i + 2) % verticesList.Count], targetVertex);
            yield return weights.Item1;
        }
    }
    /// <summary>
    /// Calculates the target data for a collection of 3D vertices and data.
    /// 计算一组3D顶点和数据的目标数据。
    /// </summary>
    public override float CalculateTargetData(IEnumerable<Vector3> vertices, IEnumerable<float> data, Vector3 targetVertex, IWeightedAverageCalculator<float, float> weightedAverageCalculator)
    {
        var weights = CalculateWeights(vertices, targetVertex);
        var weightedData = new List<(float weight, float data)>();
        using (var dataEnumerator = data.GetEnumerator())
        {
            foreach (var weight in weights)
            {
                dataEnumerator.MoveNext();
                weightedData.Add((weight, dataEnumerator.Current));
            }
        }
        return weightedAverageCalculator.CalculateWeightedAverage(weightedData);
    }
}