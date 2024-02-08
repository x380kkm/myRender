using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;
using MyMath.Triangle._2D.Interfaces;
using MyMath.Triangle._2D.Implementations;

namespace MyMath.Triangle._2D.Implementations
{
    public class TriangleWeightCalculator2D : AbstractTriangleWeightCalculator<Vector2>, I2DTriangleWeightCalculator
    {
        public TriangleWeightCalculator2D()
        {
            SetStrategy(new AreaBasedWeightStrategy2D());
        }
    }
}