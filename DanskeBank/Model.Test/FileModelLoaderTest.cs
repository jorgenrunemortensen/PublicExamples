using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Model.Test
{
    [TestClass]
    public class FileModelLoaderTest
    {
        [TestMethod]
        [TestCategory("File Model Loader")]
        public void TestNode_1_1()
        {
            var sut = LoadModel();
            Assert.AreEqual(215, sut.RootNode.Value);
        }

        [TestMethod]
        [TestCategory("File Model Loader")]
        public void TestNode_4_5()
        {
            var sut = LoadModel();
            Assert.AreEqual(417, sut.RootNode.GetChildNodes()[0].GetChildNodes()[1].GetChildNodes()[1].GetChildNodes()[1].Value);
        }

        [TestMethod]
        [TestCategory("File Model Loader")]
        public void TestNode_6_6()
        {
            var sut = LoadModel();
            Assert.AreEqual(124, sut.RootNode.GetChildNodes()[1].GetChildNodes()[1].GetChildNodes()[1].GetChildNodes()[1].GetChildNodes()[1].Value);
        }

        [TestMethod]
        [TestCategory("File Model Loader")]
        public void TestNode_2_15()
        {
            var sut = LoadModel();
            Assert.AreEqual(622, sut.RootNode.
                GetChildNodes()[1].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].
                GetChildNodes()[0].Value);
        }

        [TestMethod]
        [TestCategory("File Model Loader")]
        public void TestNode_15_15()
        {
            var sut = LoadModel();
            Assert.AreEqual(233, sut.RootNode.
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].
                GetChildNodes()[1].Value);
        }

        [TestMethod]
        [TestCategory("File Model Loader")]
        public void TestDept()
        {
            var sut = LoadModel();
            var dept = GetDept(sut.RootNode);

            Assert.AreEqual(15, dept);
        }
        
        private static IModel<int> LoadModel()
        {
            var loader = new FileTriangleTreeModelLoader<int>("..\\..\\..\\Exercise-1.txt");
            var model = loader.LoadModel();
            return model;
        }

        private static int GetDept<T>(IValueNode<T> node)
        {
            if (node == null)
                return 0;

            if (node.GetChildNodes().Length == 0)
                return 1;

            return GetDept(node.ChildNodes.First()) + 1;
        }
    }
}
