using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pac.Tool.Art3D._OBJ;
using System.Collections.Generic;

namespace ObjReaderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestObjFileReader_VerticesCount()
        {
            // 创建ObjFileReader实例
            var objFileReader = new ObjFileReader();

            // 替换为实际的OBJ文件路径
            string filePath = "read/african_head.obj";

            // 读取OBJ文件
            ObjModel model = objFileReader.ReadFile(filePath);

            // 测试：检查是否解析了顶点
            Assert.IsTrue(model.Vertices.Count > 0, "Vertices should be parsed from OBJ file.");
        }

        [TestMethod]
        public void TestObjFileReader_GroupsCount()
        {
            // 创建ObjFileReader实例
            var objFileReader = new ObjFileReader();

            // 替换为实际的OBJ文件路径
            string filePath = "read/african_head.obj";

            // 读取OBJ文件
            ObjModel model = objFileReader.ReadFile(filePath);

            // 测试：检查是否解析了组
            Assert.IsTrue(model.Groups.Count > 0, "Groups should be parsed from OBJ file.");
        }

        // 可以继续添加更多的测试方法...
    }
}