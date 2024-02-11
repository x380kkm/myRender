// 文件：MyMath/Triangle/2D/Interfaces/IVertex2DWeightDataProcessor.cs
using System.Numerics;
using MyMath.Vertex.Interfaces;

namespace MyMath.Triangle._2D.Interfaces;

/// <summary>
/// Defines methods for processing 2D vertex weight data.
/// 定义处理2D顶点权重数据的方法。
/// </summary>
public interface IVertex2DWeightDataProcessor<TData> : IVertexWeightDataProcessor<Vector2, TData>
{
}