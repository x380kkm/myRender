using System.Numerics;

namespace Pac.Tool.Math
{
    public class Triangle
    {
        public Vector2 PointA { get; private set; }
        public Vector2 PointB { get; private set; }
        public Vector2 PointC { get; private set; }
        private readonly Vector2 initialCenter; // 初始中心点，保持不变

        public Triangle(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
            initialCenter = CalculateCenter();
        }

        private Vector2 CalculateCenter()
        {
            int x = (int)((PointA.X + PointB.X + PointC.X) / 3);
            int y = (int)((PointA.Y + PointB.Y + PointC.Y) / 3);
            return new Vector2(x, y);
        }

        public Triangle? NextTriangle(int scaleFactor, float tolerance = 1.0f)
        {
            bool hasUpdated = false;

            // 更新PointA
            PointA = UpdateVertex(PointA, initialCenter, ref hasUpdated, scaleFactor, tolerance);

            // 更新PointB
            PointB = UpdateVertex(PointB, initialCenter, ref hasUpdated, scaleFactor, tolerance);

            // 更新PointC
            PointC = UpdateVertex(PointC, initialCenter, ref hasUpdated, scaleFactor, tolerance);

            if (!hasUpdated)
            {
                return null; // 如果没有任何顶点更新，则返回null
            }

            return new Triangle(PointA, PointB, PointC);
        }

        private Vector2 UpdateVertex(Vector2 point, Vector2 center, ref bool hasUpdated, int scaleFactor, float tolerance)
        {
            Vector2 delta = point - center;
            delta = new Vector2(delta.X * scaleFactor, delta.Y * scaleFactor);

            if (delta.Length() > tolerance)
            {
                point = new Vector2(point.X + (delta.X > 0 ? -1 : 1), point.Y + (delta.Y > 0 ? -1 : 1));
                hasUpdated = true;
            }
            return point;
        }
    }
}