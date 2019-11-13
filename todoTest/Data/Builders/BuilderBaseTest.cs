using NUnit.Framework;
using todoApi.Data.Builders;

namespace todoTest.Data.Builders
{
    public class BuilderBaseMock : BuilderBase
    {

    }

    public class BuilderBaseTest
    {
        [Test]
        public void getTest()
        {
            var instance = new BuilderBaseMock();
            Assert.AreEqual(1, instance.getTest());
        }
    }
}