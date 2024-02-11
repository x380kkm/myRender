using System.Numerics;
using MyMath.Illumination.Implementations;

namespace LinearCalculationsTests
{
    [TestClass]
    public class DiffuseLightCalculatorTests
    {
        [TestMethod]
        public void CalculateDiffuseLight_WithLightIntensity()
        {
            // Arrange
            var calculator = new DiffuseLightCalculator();
            var materialColor = new Vector3(1, 0, 0); // 红色
            var normal = new Vector3(0, 0, 1); // 法线向上
            var lightDirection = new Vector3(0, 0, 1); // 光源从上方照射
            float lightIntensity = 1.0f; // 光源强度为1

            // Act
            var result = calculator.CalculateDiffuseLight(materialColor, normal, lightDirection, lightIntensity);

            // Assert
            Assert.AreEqual(materialColor, result); // 期望得到的漫反射颜色与材质颜色相同
        }

        [TestMethod]
        public void CalculateDiffuseLight_WithoutLightIntensity()
        {
            // Arrange
            var calculator = new DiffuseLightCalculator();
            var materialColor = new Vector3(1, 0, 0); // 红色
            var normal = new Vector3(0, 0, 1); // 法线向上
            var lightVector = new Vector3(0, 0, 2); // 光源向量指向上方，长度为2

            // Act
            var result = calculator.CalculateDiffuseLight(materialColor, normal, lightVector);

            // Assert
            Assert.AreEqual(2 * materialColor, result); // 期望得到的漫反射颜色是材质颜色的两倍，因为光源强度为2
        }
    }
}