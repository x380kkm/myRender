// 文件：MyMath/Triangle/3D/Interfaces/IVertex3DWeightDataProcessor.cs
using System.Numerics;
using MyMath.Vertex.Interfaces;

namespace MyMath.Triangle._3D.Interfaces;

/// <summary>
/// Defines methods for processing 3D vertex weight data.
/// 定义处理3D顶点权重数据的方法。
/// </summary>
public interface IVertex3DWeightDataProcessor<TData> : IVertexWeightDataProcessor<Vector3, TData>
{
}