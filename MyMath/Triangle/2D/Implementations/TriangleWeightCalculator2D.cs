using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;
using MyMath.LinearCalculations.TriangleWeightCalculator.Implementations;
using MyMath.Triangle._2D.Interfaces;

namespace MyMath.Triangle._2D.Implementations
{
    public class TriangleWeightCalculator2D : AbstractTriangleWeightCalculator<Vector2>, I2DTriangleWeightCalculator
    {
        public TriangleWeightCalculator2D()
        {
            SetStrategy(new AreaBasedWeightStrategy());
        }
    }
}