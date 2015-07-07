using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem1_AnagramsOf_Documenting_;


namespace TestingIsAnagram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(!Class1.isAnagram("aba", "bab"));
            Assert.IsTrue(Class1.isAnagram("Ionut", "tunoi"));
            Assert.IsTrue(Class1.isAnagram("asda", "DASA"));
            Assert.IsFalse(Class1.isAnagram("iiii", "aaaa"));
            Assert.IsTrue(Class1.isAnagram("abababab", "aaaabbbb"));
            Assert.IsTrue(Class1.isAnagram("ababab", "aaabbb"));
        }
    }
}
