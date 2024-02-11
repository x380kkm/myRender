using MyMath.LinearCalculations.WeightedDataCalculators.Implementations;

namespace LinearCalculationsTests;

[TestClass]
public class FloatWeightedAverageCalculatorTests
{
    [TestMethod]
    public void CalculateWeightedAverage_ReturnsCorrectResult_WhenGivenValidInput()
    {
        // Arrange
        var calculator = new FloatWeightedAverageCalculator();
        var weightedData = new List<(float weight, float data)>
        {
            (1f, 2f),
            (2f, 3f),
            (3f, 4f)
        };
        var expected = 3.33333333f; // (1*2 + 2*3 + 3*4) / (1 + 2 + 3)

        // Act
        var actual = calculator.CalculateWeightedAverage(weightedData);

        // Assert
        Assert.AreEqual(expected, actual, 0.000001f);
    }
}