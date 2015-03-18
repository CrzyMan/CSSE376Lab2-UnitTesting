using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        private DateTime start, end, end2;

        [SetUp()]
        public void setup()
        {
            start = new DateTime(2015, 3, 17);
            end = new DateTime(2015, 3, 21);
            end2 = new DateTime(2015, 3, 22);
        }

		[Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(start, end, 500);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInvalidFlightDates()
        {
            new Flight(end, start, 100);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentOutOfRangeForMilesNegative()
        {
            new Flight(start, end, -100);
        }

        [Test()]
        public void TestThatFlightHasTheRightNumberOfMiles()
        {
            var target100 = new Flight(start, end, 100);
            var target200 = new Flight(start, end, 200);
            var target300 = new Flight(start, end, 300);
            var target400 = new Flight(start, end, 400);

            Assert.AreEqual(100, target100.Miles);
            Assert.AreEqual(200, target200.Miles);
            Assert.AreEqual(300, target300.Miles);
            Assert.AreEqual(400, target400.Miles);
        }

        [Test()]
        public void TestThatFlightCanBeEqual()
        {
            var f1 = new Flight(start, end, 100);
            var f2 = new Flight(start, end ,100);
            var f3= new Flight(start, end, 200);
            var f4 = new Flight(start, end2, 100);
            var f5 = new Flight(start, end2, 200);

            Assert.IsTrue(f1.Equals(f2));
            Assert.IsFalse(f1.Equals(f3));
            Assert.IsFalse(f1.Equals(f4));
            Assert.IsFalse(f1.Equals(f5));
        }

        [TearDown()]
        public void tearDown()
        {

        }
	}
}
