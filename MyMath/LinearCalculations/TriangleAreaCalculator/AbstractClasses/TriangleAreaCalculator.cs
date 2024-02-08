// MyMath/LinearCalculations/Implementations/AbstractTriangleAreaCalculator.cs

using MyMath.LinearCalculations.TriangleAreaCalculator.Interfaces;

namespace MyMath.LinearCalculations.TriangleAreaCalculator.AbstractClasses
{
    public abstract class AbstractTriangleAreaCalculator<TPoint> : ITriangleAreaCalculator<TPoint>
    {
        public abstract float CalculateArea(TPoint pointA, TPoint pointB, TPoint pointC);
    }
}