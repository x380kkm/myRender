using System.Linq;
using MyMath.Coordinates._2D.Point.Interfaces;

namespace MyMath.Coordinates._2D.Point.Implementations
{
    /// <summary>
    /// The BoundingBox2D class provides a method for creating a bounding box in 2D space.
    /// BoundingBox2D类提供了一个在二维空间中创建包围盒的方法。
    /// The bounding box is created from any number of points, and it represents the smallest rectangle that contains all the points.
    /// 包围盒是由任意数量的点创建的，它代表包含所有点的最小矩形。
    /// </summary>
    public class BoundingBox2D : IBoundingBox2D
    {
        /// <summary>
        /// Creates a bounding box from given points.
        /// 从给定点创建包围盒。
        /// </summary>
        /// <param name="points">An array of 2D points.</param>
        /// <returns>
        /// A tuple of four floats (MinX, MaxX, MinY, MaxY) representing the bounding box.
        /// 一个由四个浮点数组成的元组（MinX，MaxX，MinY，MaxY）代表包围盒。
        /// </returns>
        public virtual (float MinX, float MaxX, float MinY, float MaxY) CreateBoundingBox((float x, float y)[] points)
        {
            float minX = points.Min(point => point.x);
            float maxX = points.Max(point => point.x);
            float minY = points.Min(point => point.y);
            float maxY = points.Max(point => point.y);

            return (minX, maxX, minY, maxY);
        }
    }
}