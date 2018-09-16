using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Logic.Test
{
    [TestClass]
    public class ModelLogicTest
    {
        [TestMethod]
        [TestCategory("Model Logic")]
        public void ExampleTest()
        {
            var loader = new ExampleModelLoader();
            var model = loader.LoadModel();
            var max = ModelLogic.GetMaxSum(model, (n, c) => n.Value % 2 != c.Value % 2, out string path);
            Assert.AreEqual(16, max);
            Assert.AreEqual("1 -> 8 -> 5 -> 2", path);
        }
    }
}
