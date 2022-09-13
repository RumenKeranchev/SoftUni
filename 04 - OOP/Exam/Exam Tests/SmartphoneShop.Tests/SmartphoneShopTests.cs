using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_Invalid_Capacity()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-1));
        }
        
        [Test]
        public void Test_Valid_Capacity()
        {
            var shop = new Shop(2);

            Assert.AreEqual(shop.Capacity, 2);
        }
        
        [Test]
        public void Test_Add_Valid_Phone()
        {
            var shop = new Shop(2);
            var phone = new Smartphone("nova", 4000);

            shop.Add(phone);

            Assert.AreEqual(shop.Count, 1);
        }
        
        [Test]
        public void Test_Add_Phone_Twice()
        {
            var shop = new Shop(2);
            var phone = new Smartphone("nova", 4000);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone));
        }
        
        [Test]
        public void Test_Add_Phone_AboveCapacity()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);
            var phone3 = new Smartphone("experian ultra", 7000);

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone3));
        }
        
        [Test]
        public void Test_Remove_Valid_Phone()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            shop.Remove(phone1.ModelName);

            Assert.AreEqual(shop.Count, 1);
        }
        
        [Test]
        public void Test_Remove_Invalid_Phone()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Experian"));
        }
        
        [Test]
        public void Test_TestPhone_Invalid_Phone_Name()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Experian", 20));
        }
        
        [Test]
        public void Test_TestPhone_Invalid_Phone_Charge()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("experian", 6000));
        }
        
        [Test]
        public void Test_TestPhone_Valid_Phone_Charge()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            shop.TestPhone("experian", 3000);

            Assert.AreEqual(phone2.CurrentBateryCharge, 2000);
        }
        
        [Test]
        public void Test_Charge_Valid_Phone()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            shop.TestPhone(phone2.ModelName, 2000);
            shop.ChargePhone("experian");

            Assert.AreEqual(phone2.CurrentBateryCharge, 5000);
        }
        
        [Test]
        public void Test_Charge_Invalid_Phone()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("nova", 4000);
            var phone2 = new Smartphone("experian", 5000);

            shop.Add(phone1);
            shop.Add(phone2);

            shop.TestPhone(phone2.ModelName, 2000);
            Assert.Throws<InvalidOperationException>(() =>shop.ChargePhone("Experian"));
        }
    }
}