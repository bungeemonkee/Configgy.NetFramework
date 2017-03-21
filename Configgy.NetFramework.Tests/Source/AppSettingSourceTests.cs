using System.Diagnostics.CodeAnalysis;
using Configgy.NetFramework.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configgy.NetFramework.Tests.Source
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AppSettingSourceTests
    {
        [TestMethod]
        public void Get_Returns_String_From_AppSettings()
        {
            const string name = "name";
            const string expected = "value";

            var source = new AppSettingSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.AreEqual(expected, value);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_Returns_Null_When_No_Matching_AppSettings_Value()
        {
            const string name = "kfnnpa";

            var source = new AppSettingSource();

            string value;
            var result = source.Get(name, null, out value);

            Assert.IsNull(value);
            Assert.IsFalse(result);
        }
    }
}
