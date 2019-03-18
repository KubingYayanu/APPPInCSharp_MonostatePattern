using APPPInCSharp_MonostatePattern.Console;
using NUnit.Framework;

namespace APPPInCSharp_MonostatePattern.UnitTests
{
    [TestFixture]
    public class MonostateTests
    {
        [Test]
        public void TestInstance()
        {
            Monostate m = new Monostate();

            for (int x = 0; x < 10; x++)
            {
                m.X = x;
                Assert.That(x, Is.EqualTo(m.X));
            }
        }

        [Test]
        public void TestInstanceBehaveAsOne()
        {
            Monostate m1 = new Monostate();
            Monostate m2 = new Monostate();

            for (int x = 0; x < 10; x++)
            {
                m1.X = x;
                Assert.That(x, Is.EqualTo(m2.X));
            }
        }
    }
}