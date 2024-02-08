using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;
using System.Collections.Generic;

namespace LinearCalculationsTests
{
    [TestClass]
    public class TestFloatWeightedAverageCalculator
    {
        [TestMethod]
        public void TestCalculateWeightedAverage()
        {
            // Arrange
            var calculator = new FloatWeightedAverageCalculator();

            // Act
            var weightedData = new List<(float weight, float data)>
            {
                (0.2f, 1f),
                (0.3f, 2f),
                (0.5f, 3f)
            };
            var average = calculator.CalculateWeightedAverage(weightedData);

            // Assert
            var expectedAverage = 0.2f * 1f + 0.3f * 2f + 0.5f * 3f;
            Assert.AreEqual(expectedAverage, average, 1e-6f);
        }
    }
}