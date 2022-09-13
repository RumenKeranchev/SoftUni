namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_Invalid_Make()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "test", 1.2, 20));
        }
        
        [Test]
        public void Test_Invalid_Model()
        {
            Assert.Throws<ArgumentException>(() => new Car("test", null, 1.2, 20));
        }
        
        [Test]
        public void Test_Invalid_Fuel_Consumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("test", "test", -1.2, 20));
        }
        
        [Test]
        public void Test_Invalid_Fuel_Capacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("test", "test", 1.2, -20));
        }
        
        [Test]
        public void Test_Valid_Constructor()
        {
            Assert.DoesNotThrow(() => new Car("test", "test", 1.2, 20));
        }

        [Test]
        public void Test_Refuel_Invalid_Amount()
        {
            var car = new Car("test", "test", 1.2, 20);

            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }
        
        [Test]
        public void Test_Refuel_Abundant_Amount()
        {
            var car = new Car("test", "test", 1.2, 20);
            car.Refuel(200);
            Assert.That(car.FuelAmount == car.FuelCapacity);
        }

        [Test]
        public void Test_Drive_Without_Refuel()
        {
            var car = new Car("test", "test", 1.2, 20);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10));
        }


        [Test]
        public void Test_Drive_With_Refuel()
        {
            var car = new Car("test", "test", 1.2, 20);
            car.Refuel(20);
            car.Drive(10);
            Assert.That(car.FuelAmount == 19.88);
        }
    }
}