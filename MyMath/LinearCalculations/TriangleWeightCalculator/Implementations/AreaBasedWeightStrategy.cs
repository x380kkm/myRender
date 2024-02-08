using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;
using MyMath.Triangle._2D.Implementations;
using MyMath.Triangle._3D.Implementations;

namespace MyMath.LinearCalculations.TriangleWeightCalculator.Implementations
{
    public class AreaBasedWeightStrategy : IWeightCalculationStrategy<Vector2>, IWeightCalculationStrategy<Vector3>
    {
        public (float, float, float) CalculateWeight(Vector2 pointA, Vector2 pointB, Vector2 pointC, Vector2 targetPoint)
        {
            var calculator = new TriangleAreaCalculator2D();
            float weightA = calculator.CalculateArea(targetPoint, pointB, pointC);
            float weightB = calculator.CalculateArea(targetPoint, pointA, pointC);
            float weightC = calculator.CalculateArea(targetPoint, pointA, pointB);

            float totalWeight = weightA + weightB + weightC;

            return (weightA / totalWeight, weightB / totalWeight, weightC / totalWeight);
        }

        public (float, float, float) CalculateWeight(Vector3 pointA, Vector3 pointB, Vector3 pointC, Vector3 targetPoint)
        {
            var calculator = new TriangleAreaCalculator3D();
            float weightA = calculator.CalculateArea(targetPoint, pointB, pointC);
            float weightB = calculator.CalculateArea(targetPoint, pointA, pointC);
            float weightC = calculator.CalculateArea(targetPoint, pointA, pointB);

            float totalWeight = weightA + weightB + weightC;

            return (weightA / totalWeight, weightB / totalWeight, weightC / totalWeight);
        }
    }
}