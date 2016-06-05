using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONode.JSON;
using JArray = JSONode.JSON.Array;
using JAttribute = JSONode.JSON.Attribute;

namespace JSONodeTests
{
    /// <summary>
    /// Summary description for JSONUnitTest
    /// </summary>
    [TestClass]
    public class JSONUnitTest
    {

        public JSONUnitTest()
        {

            

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Create_Array()
        {
            JArray array = new JArray();
            Object[] items = { (Object)1, (Object)2, (Object)true, (Object)"Hello" };

            int itemCount = 0;

            foreach (Object item in items)
            {
                array.Add(item);
                itemCount++;
                Assert.AreEqual(array.Items.Length, itemCount, "Not enough items in Array.");
            }

            foreach (JArray.ArrayItem ai in array.Items)
            {
                Assert.AreEqual(ai.Type, ai.Value.ToAttrType(), "Attr Type Mismatch");
            }


            array.RemoveAt(0);
            Assert.AreEqual(array.Items.Length, itemCount - 1, "Item count didn't decrease.");

            array.Remove((object)2);
            Assert.AreEqual(array.Items.Length, itemCount - 2, "Item count didn't decrease;");
            

        }

    }
}
