using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces;

namespace MyMath.Triangle._3D.Implementations
{
    public class AreaBasedWeightStrategy3D : IWeightCalculationStrategy<Vector3>
    {
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