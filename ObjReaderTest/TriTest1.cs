using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pac.Tool.Math;
using System.Numerics;

namespace ObjReaderTest
{
    [TestClass]
    public class TriTest1
    {
        [TestMethod]
        public void NextTriangle_ReturnsNullWhenVerticesAreCloseToInitialCenter()
        {
            // 创建一个初始三角形
            var triangle = new Triangle(
                new Vector2(0, 0), 
                new Vector2(10, 0), 
                new Vector2(5, 10));

            Triangle? nextTriangle;
            int iterationCount = 0;
            const int maxIterations = 100; // 设置最大迭代次数以防止无限循环

            // 循环，直到NextTriangle返回null或达到最大迭代次数
            do
            {
                nextTriangle = triangle.NextTriangle(1, 1.0f);
                iterationCount++;
            } while (nextTriangle != null && iterationCount < maxIterations);

            // 验证NextTriangle最终返回null
            Assert.IsNull(nextTriangle, "NextTriangle did not return null after vertices are close to initial center.");

            // 还可以验证迭代次数是否符合预期
            // Assert.IsTrue(iterationCount < maxIterations, "Too many iterations before stopping.");
        }
    }
}