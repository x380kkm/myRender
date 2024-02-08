// 文件：MyMath/Triangle/2D/Interfaces/IVertex2DWeightDataProcessor.cs
using System.Numerics;
using MyMath.Vertex.Interfaces;

namespace MyMath.Triangle._2D.Interfaces
{
    public interface IVertex2DWeightDataProcessor<TData> : IVertexWeightDataProcessor<Vector2, TData>
    {
    }
}