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
            // 计算模型的中心
            Vector3 center = (Min3D + Max3D) / 2;

            // 将模型的原点移动到其几何中心
            point -= center;

            // 将模型的尺寸缩放到单位立方体
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
                return new Vector2((point.X ) * max2D.X, (point.Y ) * max2D.Y);
            }

            return new Triangle(Project(PointA), Project(PointB), Project(PointC));
        }

        public float GetDepth(Vector2 point)
        {
            // 计算三角形的中点
            Vector3 center = (PointA + PointB + PointC) / 3;

            // 获取中点的Z坐标
            float z = center.Z;

            // 将Z坐标在模型空间的最大Z和最小Z之间进行归一化
            float normalizedZ = (z - Min3D.Z) / (Max3D.Z - Min3D.Z);

            return normalizedZ;
        }
    }
}