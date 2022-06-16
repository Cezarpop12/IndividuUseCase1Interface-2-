using BusnLogicLaag;
using FakeDAL;

namespace RatingUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly RatingContainer rc = new RatingContainer(new RatingFakeUTDAL())

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}