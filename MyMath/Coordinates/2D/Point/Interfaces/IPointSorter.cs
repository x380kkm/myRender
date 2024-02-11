using System.Collections.Generic;
namespace MyMath.Coordinates._2D.Point.Interfaces;
/// <summary>
/// Defines a method for sorting a sequence of points in 2D space.
/// 定义了一个在二维空间中对一系列点进行排序的方法。
/// Points are sorted primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
/// 点主要按照它们的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
/// </summary>
public interface IPointSorter
{
    /// <summary>
    /// Sorts the given points primarily by their Y-coordinate, and secondarily (in case of ties) by their X-coordinate.
    /// 主要按照给定点的Y坐标排序，其次（如果Y坐标相同）按照它们的X坐标排序。
    /// </summary>
    IEnumerable<(float x, float y)> SortPoints(IEnumerable<(float x, float y)> points);
}