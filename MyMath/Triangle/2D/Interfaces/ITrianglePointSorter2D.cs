using MyMath.Coordinates._2D.Point.Interfaces;
namespace MyMath.Triangle._2D.Interfaces;
/// <summary>
/// Defines a method for sorting the vertices of a triangle in 2D space.
/// 定义了一个在二维空间中对三角形的顶点进行排序的方法。
/// Vertices are sorted primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
/// 顶点主要按照它们的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
/// This method only accepts three points.
/// 这个方法只接受三个点。
/// </summary>
public interface ITrianglePointSorter2D : IPointSorter
{
    new (float x, float y)[] SortPoints((float x, float y)[] points);
}