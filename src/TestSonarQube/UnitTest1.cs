using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSonarQube
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Foo foo = new Foo();

            var expected = 4;

            Assert.IsTrue(expected == foo.Add(2,2));
        }

        [TestMethod]
        public void RedundantToStringMethod()
        {
            Foo foo = new Foo();

            string beginning = "foo";
            string end = "bar";

            Assert.AreEqual("foobar", foo.Append(beginning, end).ToString()); //another redundant tostring()
        }
    }
}
