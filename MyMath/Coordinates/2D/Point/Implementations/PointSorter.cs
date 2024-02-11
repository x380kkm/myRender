using MyMath.Coordinates._2D.Point.Interfaces;
namespace MyMath.Coordinates._2D.Point.Implementations;
/// <summary>
/// Provides a method for sorting a sequence of points in 2D space.
/// 提供了一个在二维空间中对一系列点进行排序的方法。
/// Points are sorted primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
/// 点主要按照它们的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
/// </summary>
public class PointSorter : IPointSorter
{
    /// <summary>
    /// Sorts the given points primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
    /// 主要按照给定点的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
    /// </summary>
    /// <param name="points">The points to sort. 需要排序的点。</param>
    /// <returns>The sorted points. 排序后的点。</returns>
    public IEnumerable<(float x, float y)> SortPoints(IEnumerable<(float x, float y)> points)
    {
        return points.OrderBy(point => point.y).ThenBy(point => point.x);
    }
}