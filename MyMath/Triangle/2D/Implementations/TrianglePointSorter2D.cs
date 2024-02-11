using MyMath.Coordinates._2D.Point.Implementations;
using MyMath.Triangle._2D.Interfaces;

namespace MyMath.Triangle._2D.Implementations;
/// <summary>
/// Provides a method for sorting the vertices of a triangle in 2D space.
/// 提供了一个在二维空间中对三角形的顶点进行排序的方法。
/// Vertices are sorted primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
/// 顶点主要按照它们的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
/// This method only accepts three points.
/// 这个方法只接受三个点。
/// </summary>
public class TrianglePointSorter2D : PointSorter, ITrianglePointSorter2D
{
    
    /// <summary>
    /// Sorts the given points primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
    /// 主要按照给定点的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
    /// This method only accepts three points.
    /// 这个方法只接受三个点。
    /// </summary>
    /// <param name="points">The points to sort. 需要排序的点。</param>
    /// <returns>The sorted points. 排序后的点。</returns>
    /// <exception cref="ArgumentException">Thrown when the number of points is not three. 当点的数量不是三个时抛出。</exception>
    public new (float x, float y)[] SortPoints((float x, float y)[] points)
    {
        if (points.Length != 3)
        {
            throw new ArgumentException("The number of points must be three.", nameof(points));
        }

        return base.SortPoints(points as IEnumerable<(float x, float y)>).ToArray();
    }
}