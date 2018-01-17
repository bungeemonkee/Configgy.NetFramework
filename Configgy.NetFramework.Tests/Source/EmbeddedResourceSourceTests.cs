﻿using System.Diagnostics.CodeAnalysis;
using Configgy.NetFramework.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configgy.NetFramework.Tests.Source
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EmbeddedResourceSourceTests
    {
        [TestMethod]
        public void Get_Returns_Value_From_conf_Resource()
        {
            const string name = "TestValue1Embedded";
            const string expected = "This is a string value.";

            var source = new EmbeddedResourceSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.AreEqual(expected, value);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_Returns_Value_From_json_Resource()
        {
            const string name = "TestValue2Embedded";
            const string expected = "[ \"string array\" ]";

            var source = new EmbeddedResourceSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.AreEqual(expected, value);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_Returns_Value_From_xml_Resource()
        {
            const string name = "TestValue3Embedded";
            const string expected = "<element>some xml</element>";

            var source = new EmbeddedResourceSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.AreEqual(expected, value);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_Allows_Names_With_Underscores()
        {
            const string name = "Test_Value_4_Embedded";
            const string expected = "Setting!";

            var source = new EmbeddedResourceSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.AreEqual(expected, value);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_Returns_Null_For_Resources_That_Dont_Exist()
        {
            const string name = "NOT ACTUALLY A RESOURCE!!!!!!";

            var source = new EmbeddedResourceSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.IsNull(value);
            Assert.IsFalse(result);
        }
    }
}
