using System.Numerics;

namespace Pac.Tool.Math
{
    public class Triangle3D
    {
        private Vector3 PointA { get; set; }
        private Vector3 PointB { get; set; }
        private Vector3 PointC { get; set; }
        private Vector3 OriginalPointA { get; set; }
        private Vector3 OriginalPointB { get; set; }
        private Vector3 OriginalPointC { get; set; }    
        private Vector3 TextureU { get; set; }
        private Vector3 TextureV { get; set; }

        public static Vector3 Min3D { get; set; }
        public static Vector3 Max3D { get; set; }

        public Triangle3D(Vector3 pointA, Vector3 pointB, Vector3 pointC,Vector3 textureU,Vector3 textureV)
        {
            
            OriginalPointA = pointA;
            OriginalPointB = pointB;
            OriginalPointC = pointC;
            TextureU = textureU;
            TextureV = textureV;
            float[] tX = [textureU.X, textureV.X];
            float[] tY = [textureU.Y, textureV.Y];
            float[] tZ = [textureU.Z, textureV.Z];

            
            // 创建一个包含顶点和对应的纹理坐标的临时数据结构
            var pointsWithTextures = new[]
            {
                new { Point = pointA, Texture = tX },
                new { Point = pointB, Texture = tY },
                new { Point = pointC, Texture = tZ }
            };

            // 对这个数据结构进行排序
            var sortedPointsWithTextures = pointsWithTextures.OrderBy(p => p.Point.Y).ToArray();

            // 将排序后的顶点和纹理坐标分别赋值给PointA、PointB、PointC
            PointA = TransformToUnitCube(sortedPointsWithTextures[0].Point);
            PointB = TransformToUnitCube(sortedPointsWithTextures[1].Point);
            PointC = TransformToUnitCube(sortedPointsWithTextures[2].Point);
            
            TextureU = new Vector3(tX[0], tY[0], tZ[0]);
            TextureV = new Vector3(tX[1], tY[1], tZ[1]);

        
        }
        private Vector3 TransformToUnitCube(Vector3 point)
        {
            // 计算模型的中心
           // Vector3 center = (Min3D + Max3D) / 2;

            // 将模型的原点移动到其几何中心
            //point -= center;
            float maxAxisLength = System.Math.Max(Max3D.X - Min3D.X, System.Math.Max(Max3D.Y - Min3D.Y, Max3D.Z - Min3D.Z));

            // 计算缩放比例，保持原有比例
            float scaleX = (Max3D.X - Min3D.X) / maxAxisLength;
            float scaleY = (Max3D.Y - Min3D.Y) / maxAxisLength;
            float scaleZ = (Max3D.Z - Min3D.Z) / maxAxisLength;

            // 将模型的尺寸缩放到新的空间内，并保持比例
            return new Vector3(
                (point.X - Min3D.X) / (Max3D.X - Min3D.X) * scaleX,
                (point.Y - Min3D.Y) / (Max3D.Y - Min3D.Y) * scaleY,
                (point.Z - Min3D.Z) / (Max3D.Z - Min3D.Z) * scaleZ
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
        //三角形两边叉积计算法线
        public Vector3 GetNormal()
        {
            Vector3 ab = OriginalPointB - OriginalPointA;
            Vector3 ac = OriginalPointC - OriginalPointA;
            Vector3 normal = Vector3.Cross(ab, ac);
            return Vector3.Normalize(normal);
        }

        public float GetDepth()
        {
            // 计算三角形的中点
            Vector3 center = (PointA + PointB + PointC) / 3;

            // 获取中点的Z坐标
            float z = center.Z;

            // 将Z坐标在模型空间的最大Z和最小Z之间进行归一化
            float normalizedZ = (z - Min3D.Z) / (Max3D.Z - Min3D.Z);

            // 确保normalizedZ在0到1之间
             if (normalizedZ > 1)
            {
                return 1;
            }
            return normalizedZ;
        }
        //计算贴图坐标
        public Vector2 UVmap(Vector3 weight)
        {
                // 将权重分别乘以三个顶点的贴图坐标，然后将结果相加
                Vector2 result = weight.X * new Vector2(TextureU.X, TextureV.X)
                                 + weight.Y * new Vector2(TextureU.Y, TextureV.Y)
                                 + weight.Z * new Vector2(TextureU.Z, TextureV.Z);
                return result;
        
        }

    }
}