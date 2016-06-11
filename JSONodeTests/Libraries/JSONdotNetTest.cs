using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONode.Processing;

namespace JSONodeTests.Libraries
{
    [TestClass]
    public class JSONdotNetTest
    {

        const String jsonFile = //@"Y:/git/wadeh/JSONode/JSONodeTests/dummy.json";
          @"Y:/git/wadeh/JSONode/JSONodeTests/simple.json";

        [TestMethod]
        public void TestMethod1()
        {
            JSONode.Processing.JsonIO.LoadFile(jsonFile);
        }
    }
}
