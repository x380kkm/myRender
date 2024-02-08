using System.Numerics;
using MyMath.LinearCalculations.TriangleWeightCalculator.AbstractClasses;
using MyMath.Triangle._3D.Interfaces;
using MyMath.Triangle._3D.Implementations;

namespace MyMath.Triangle._3D.Implementations
{
    public class TriangleWeightCalculator3D : AbstractTriangleWeightCalculator<Vector3>, I3DTriangleWeightCalculator
    {
        public TriangleWeightCalculator3D()
        {
            SetStrategy(new AreaBasedWeightStrategy3D());
        }
    }
}