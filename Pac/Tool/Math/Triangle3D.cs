using System.Numerics;

namespace Pac.Tool.Math
{
    public class Triangle3D
    {
        private Vector3 PointA { get; set; }
        private Vector3 PointB { get; set; }
        private Vector3 PointC { get; set; }
        public static Vector3 Min3D { get; set; }
        public static Vector3 Max3D { get; set; }

        public Triangle3D(Vector3 pointA, Vector3 pointB, Vector3 pointC)
        {
            PointA = TransformToUnitCube(pointA);
            PointB = TransformToUnitCube(pointB);
            PointC = TransformToUnitCube(pointC);
            // 对三个顶点按照y坐标进行排序
            var points = new[] { pointA, pointB, pointC }
                .OrderBy(p => p.Y)
                .ToArray();

            PointA = TransformToUnitCube(points[0]);
            PointB = TransformToUnitCube(points[1]);
            PointC = TransformToUnitCube(points[2]);
        
        }

        private Vector3 TransformToUnitCube(Vector3 point)
        {
            return new Vector3(
                (point.X - Min3D.X) / (Max3D.X - Min3D.X),
                (point.Y - Min3D.Y) / (Max3D.Y - Min3D.Y),
                (point.Z - Min3D.Z) / (Max3D.Z - Min3D.Z)
            );
        }

        public Triangle ProjectTo2D(Vector2 max2D)
        {
            Vector2 Project(Vector3 point)
            {
                return new Vector2(point.X * max2D.X, point.Y * max2D.Y);
            }

            return new Triangle(Project(PointA), Project(PointB), Project(PointC));
        }

        public float GetDepth(Vector2 point)
        {
            // 计算三角形的面积
            float Area(Vector2 a, Vector2 b, Vector2 c)
            {
                return System.Math.Abs((a.X*(b.Y-c.Y) + b.X*(c.Y-a.Y) + c.X*(a.Y-b.Y)) / 2.0f);
            }

            // 计算屏幕空间的点与三角形的三个顶点构成的三个小三角形的面积
            var triangle2D = ProjectTo2D(new Vector2(1, 1));
            var a1 = Area(point, triangle2D.PointB, triangle2D.PointC);
            var a2 = Area(triangle2D.PointA, point, triangle2D.PointC);
            var a3 = Area(triangle2D.PointA, triangle2D.PointB, point);

            // 计算三角形的面积
            var totalArea = Area(triangle2D.PointA, triangle2D.PointB, triangle2D.PointC);

            // 计算深度
            float depth = (a1 * PointA.Z + a2 * PointB.Z + a3 * PointC.Z) / totalArea;

            // 将深度值限制在 [0, 1] 范围内
            return System.Math.Max(0, System.Math.Min(1, depth));
        }
    }
}