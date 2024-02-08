// 文件：MyMath/Triangle/3D/Interfaces/IVertex3DWeightDataProcessor.cs
using System.Numerics;
using MyMath.Vertex.Interfaces;

namespace MyMath.Triangle._3D.Interfaces
{
    public interface IVertex3DWeightDataProcessor<TData> : IVertexWeightDataProcessor<Vector3, TData>
    {
    }
}