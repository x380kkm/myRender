using System.Numerics;
using System.Linq; // 确保包含这个来使用 OrderBy

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
            // 先对三个顶点按照y坐标进行排序
            var points = new[] { pointA, pointB, pointC }
                .OrderBy(p => p.Y)
                .ToArray();

            // 对排序后的点应用变换
            PointA = TransformToUnitCube(points[0]);
            PointB = TransformToUnitCube(points[1]);
            PointC = TransformToUnitCube(points[2]);
        }

        private Vector3 TransformToUnitCube(Vector3 point)
        {
            // 计算模型的中心
           //Vector3 center = (Min3D + Max3D) / 2;
           //point -= center;

            // 计算模型在X、Y和Z轴上的长度
            float sizeX = Max3D.X - Min3D.X;
            float sizeY = Max3D.Y - Min3D.Y;
            float sizeZ = Max3D.Z - Min3D.Z;

            // 找到最长轴
            float maxSize = System.Math.Max(sizeX, System.Math.Max(sizeY, sizeZ));

            // 将模型的尺寸等比例缩放到单位立方体
            return new Vector3(
                point.X / maxSize,
                point.Y / maxSize,
                point.Z / maxSize
            );
        }

        public Triangle ProjectTo2D(Vector2 max2D)
        {
            Vector2 Project(Vector3 point)
            {
                return new Vector2((point.X + 0.5f) * max2D.X, (point.Y + 0.5f) * max2D.Y);
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

            // 将归一化的范围修改
            normalizedZ = normalizedZ ;

            return normalizedZ;
        }
    }
}
