using MyMath.Coordinates._2D.Point.Interfaces;

namespace MyMath.Triangle._2D.Interfaces
{
    /// <summary>
    /// The IBoundingBoxFromTriangleVertices interface defines a method for creating a bounding box from the vertices of a triangle in 2D space.
    /// IBoundingBoxFromTriangleVertices接口定义了一个在二维空间中从三角形的顶点创建包围盒的方法。
    /// The bounding box is created from exactly three points, and it represents the smallest rectangle that contains all the points.
    /// 包围盒是由恰好三个点创建的，它代表包含所有点的最小矩形。
    /// </summary>
    public interface IBoundingBoxFromTriangleVertices2D : IBoundingBox2D
    {
    }
}