// MyMath/LinearCalculations/Interfaces/ITriangleAreaCalculator.cs
namespace MyMath.LinearCalculations.TriangleAreaCalculator.Interfaces
{
    public interface ITriangleAreaCalculator<TPoint>
    {
        float CalculateArea(TPoint pointA, TPoint pointB, TPoint pointC);
    }
}