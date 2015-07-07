using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem1_AnagramsOf_Documenting_;

namespace TestingCanBeAnagram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string toCheck="Hello";
            var a=toCheck.ToCharArray();
            var res=Class1.canBeAnagram(a,"Hell");
            Assert.IsTrue(res.ToString().Equals("Hell"));
            
            a = "sdfjdsfgd".ToCharArray();
            res = Class1.canBeAnagram(a, "sdfs");
            Assert.IsTrue(res.Equals("sdfs"));

            a = "Ionut".ToCharArray();
            res = Class1.canBeAnagram(a, "ion");
            Assert.IsTrue(res.Equals("Ion"));
            
        }
    }
}
