using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem1_AnagramsOf_Documenting_;

namespace TestingAreAnagrams
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert.IsTrue(Class1.areAnagrams("ionut", "pasca", "pascaionut"));
            //Assert.IsFalse(Class1.areAnagrams("ionut", "pasc", "pascaionut"));

            var x = Class1.getFrequenceVector("docum");
            var y = Class1.getFrequenceVector("enting");
            var z = Class1.getFrequenceVector("documenting");
            Assert.IsTrue(Class1.areAnagrams(x, y, z));

            var xx = Class1.getFrequenceVector("en");
            var yy = Class1.getFrequenceVector("documting");
            z = Class1.getFrequenceVector("documenting");
            Assert.IsTrue(Class1.areAnagrams(xx, yy, z));
        }
    }
}
