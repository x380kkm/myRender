using MyMath.Coordinates._2D.Point.Implementations;

namespace MyMath.Triangle._2D.Implementations
{
    /// <summary>
    /// The BoundingBoxFromTriangleVertices2D class provides a method for creating a bounding box from the vertices of a triangle in 2D space.
    /// BoundingBoxFromTriangleVertices2D类提供了一个在二维空间中从三角形的顶点创建包围盒的方法。
    /// The bounding box is created from exactly three points, and it represents the smallest rectangle that contains all the points.
    /// 包围盒是由恰好三个点创建的，它代表包含所有点的最小矩形。
    /// </summary>
    public class BoundingBoxFromTriangleVertices2D : BoundingBox2D
    {
        /// <summary>
        /// Creates a bounding box that contains all the given points of a triangle.
        /// 创建一个包含三角形所有给定点的包围盒。
        /// The bounding box is represented by the minimum and maximum x and y coordinates of the points.
        /// 包围盒由点的最小和最大x和y坐标表示。
        /// </summary>
        /// <param name="points">An array of 2D points. Each point is represented by a tuple of two floats, where the first float is the x coordinate and the second float is the y coordinate.</param>
        /// <returns>
        /// A tuple of four floats representing the minimum and maximum x and y coordinates of the bounding box.
        /// 返回一个由四个浮点数组成的元组，代表包围盒的最小和最大x和y坐标。
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the number of points is not three.</exception>
        public override (float MinX, float MaxX, float MinY, float MaxY) CreateBoundingBox((float x, float y)[] points)
        {
            if (points.Length != 3)
            {
                throw new ArgumentException("The number of points must be three.", nameof(points));
            }

            return base.CreateBoundingBox(points);
        }
    }
}