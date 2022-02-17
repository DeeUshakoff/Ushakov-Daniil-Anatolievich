using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programming.SimpleOperations;
using DeeULib;

namespace UnitTests
{
    [TestClass]
    public class SimpleOperationTest
    {
        [TestMethod]
        public void DivisionTest()
        {
            Assert.AreEqual(0.5, SimpleOperations.Div(1, 2)); 
        }
        [TestMethod]
        public void SquareTest()
        {
            Assert.AreEqual(16,SimpleOperations.Square(4));
        }
    }
}