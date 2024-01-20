using System.Numerics;

namespace Pac.Tool.Math
{
    public class Triangle
    {
        public Vector2 PointA { get; private set; }
        public Vector2 PointB { get; private set; }
        public Vector2 PointC { get; private set; }
        private Triangle3D _triangle3D;

        public Triangle(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            // 对三个顶点按照y坐标进行排序
            var points = new[] { pointA, pointB, pointC }
                .OrderBy(p => p.Y)
                .ToArray();

            PointA = points[0];
            PointB = points[1];
            PointC = points[2];
        }

        // 新增的构造函数，接受一个Triangle3D对象作为参数
        public Triangle(Triangle3D triangle3D)
        {
            _triangle3D = triangle3D;
            var triangle2D = triangle3D.ProjectTo2D(new Vector2(1, 1));
            // 对三个顶点按照y坐标进行排序
            var points = new[] { triangle2D.PointA, triangle2D.PointB, triangle2D.PointC }
                .OrderBy(p => p.Y)
                .ToArray();

            PointA = points[0];
            PointB = points[1];
            PointC = points[2];
        }

        // 根据给定的y值计算交点的x坐标
        public float IntersectX(float y)
        {
            // 找到与给定y值相交的两条边
            Vector2 p1, p2;
            if (y < PointB.Y)
            {
                p1 = PointA;
                p2 = PointB;
            }
            else
            {
                p1 = PointB;
                p2 = PointC;
            }

            // 在这两条边上进行插值计算x坐标
            float t = (y - p1.Y) / (p2.Y - p1.Y);
            return p1.X + t * (p2.X - p1.X);
        }

        // 判断一个点是否在三角形内
        public static bool Contains(Vector2 point, Triangle triangle)
        {
            Vector2 v0 = triangle.PointC - triangle.PointA;
            Vector2 v1 = triangle.PointB - triangle.PointA;
            Vector2 v2 = point - triangle.PointA;

            float dot00 = Vector2.Dot(v0, v0);
            float dot01 = Vector2.Dot(v0, v1);
            float dot02 = Vector2.Dot(v0, v2);
            float dot11 = Vector2.Dot(v1, v1);
            float dot12 = Vector2.Dot(v1, v2);

            float invDenom = 1 / (dot00 * dot11 - dot01 * dot01);
            float u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            float v = (dot00 * dot12 - dot01 * dot02) * invDenom;
            float epsilon = 0.05f; // 定义一个小的偏移量
            return (u >= -epsilon) && (v >= -epsilon) && (u + v <= 1 + epsilon);
        }

        // 重载的Contains方法，接受一个点和三个顶点作为参数
        public static bool Contains(Vector2 point, Vector2 vertexA, Vector2 vertexB, Vector2 vertexC)
        {
            Triangle triangle = new Triangle(vertexA, vertexB, vertexC);
            return Contains(point, triangle);
        }
        public bool Contains(Vector2 point)
        {
            return Contains(point, PointA, PointB, PointC);
        }

        // 新增的方法，返回三角形对应点的深度
        public float GetDepth()
        {
            return _triangle3D.GetDepth();
        }
    }
}