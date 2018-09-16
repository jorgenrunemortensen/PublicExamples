using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Test
{
    [TestClass]
    public class ExampleModelTest
    {
        [TestMethod]
        [TestCategory("Example Model Loader")]
        public void TestNode_1_1()
        {
            var sut = new ExampleModelLoader().LoadModel();
            Assert.AreEqual(1, sut.RootNode.Value);
        }

        [TestMethod]
        [TestCategory("Example Model Loader")]
        public void TestNode_1_3()
        {
            var sut = new ExampleModelLoader().LoadModel();
            Assert.AreEqual(1, sut.RootNode.GetChildNodes()[0].GetChildNodes()[0].Value);
        }

        [TestMethod]
        [TestCategory("Example Model Loader")]
        public void TestNode_2_3()
        {
            var sut = new ExampleModelLoader().LoadModel();
            Assert.AreEqual(5, sut.RootNode.GetChildNodes()[0].GetChildNodes()[1].Value);
            Assert.AreEqual(5, sut.RootNode.GetChildNodes()[1].GetChildNodes()[0].Value);
        }

        [TestMethod]
        [TestCategory("Example Model Loader")]
        public void TestNode_2_4()
        {
            var sut = new ExampleModelLoader().LoadModel();
            Assert.AreEqual(5, sut.RootNode.GetChildNodes()[0].GetChildNodes()[1].GetChildNodes()[0].Value);
        }

        [TestMethod]
        [TestCategory("Example Model Loader")]
        public void TestNode_3_4()
        {
            var sut = new ExampleModelLoader().LoadModel();
            Assert.AreEqual(2, sut.RootNode.GetChildNodes()[0].GetChildNodes()[1].GetChildNodes()[1].Value);
        }

        [TestMethod]
        [TestCategory("Example Model Loader")]
        public void TestNode_4_4()
        {
            var sut = new ExampleModelLoader().LoadModel();
            Assert.AreEqual(3, sut.RootNode.GetChildNodes()[1].GetChildNodes()[1].GetChildNodes()[1].Value);
        }
    }
}
