using System.Linq;

namespace MyMath.Coordinates._2D.Point.Interfaces
{
    /// <summary>
    /// The IBoundingBox2D interface defines a method for creating a bounding box in 2D space.
    /// IBoundingBox2D接口定义了一个在二维空间中创建包围盒的方法。
    /// The bounding box is created from any number of points, and it represents the smallest rectangle that contains all the points.
    /// 包围盒是由任意数量的点创建的，它代表包含所有点的最小矩形。
    /// </summary>
    public interface IBoundingBox2D
    {
        /// <summary>
        /// Creates a bounding box that contains all the given points.
        /// 创建一个包含所有给定点的包围盒。
        /// The bounding box is represented by the minimum and maximum x and y coordinates of the points.
        /// 包围盒由点的最小和最大x和y坐标表示。
        ///  </summary>
        (float MinX, float MaxX, float MinY, float MaxY) CreateBoundingBox((float x, float y)[] points);
    }
}