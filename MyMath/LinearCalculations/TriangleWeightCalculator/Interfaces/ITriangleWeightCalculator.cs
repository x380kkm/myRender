namespace MyMath.LinearCalculations.TriangleWeightCalculator.Interfaces
{
    public interface ITriangleWeightCalculator<TPoint>
    {
        (float, float, float) CalculateWeight(TPoint pointA, TPoint pointB, TPoint pointC, TPoint targetPoint);
    }
}