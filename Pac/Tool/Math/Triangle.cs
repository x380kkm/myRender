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
        public bool Contains(Vector2 point)
        {
            // 计算向量的叉积
            float Cross(Vector2 a, Vector2 b, Vector2 c)
            {
                return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            }

            // 判断点与三角形的三个顶点构成的三个向量的叉积是否都在同一方向
            var crossA = Cross(PointA, PointB, point);
            var crossB = Cross(PointB, PointC, point);
            var crossC = Cross(PointC, PointA, point);
            return crossA >= 0 && crossB >= 0 && crossC >= 0 || crossA <= 0 && crossB <= 0 && crossC <= 0;
        }

        // 新增的方法，返回三角形对应点的深度
        public float GetDepth(Vector2 point)
        {
            return _triangle3D.GetDepth(point);
        }
    }
}