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
        /// Creates a bounding box that contains all the given points.
        /// 创建一个包含所有给定点的包围盒。
        /// The bounding box is represented by the minimum and maximum x and y coordinates of the points.
        /// 包围盒由点的最小和最大x和y坐标表示。
        /// </summary>
        /// <param name="points">An array of 2D points. Each point is represented by a tuple of two floats, where the first float is the x coordinate and the second float is the y coordinate.</param>
        /// <returns>A tuple of four floats representing the minimum and maximum x and y coordinates of the bounding box.</returns>
        public (float MinX, float MaxX, float MinY, float MaxY) CreateBoundingBox((float x, float y)[] points)
        {
            float minX = points.Min(point => point.x);
            float maxX = points.Max(point => point.x);
            float minY = points.Min(point => point.y);
            float maxY = points.Max(point => point.y);

            return (minX, maxX, minY, maxY);
        }
    }
}