namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Test_Capacity_Cant_Be_More_Than_16()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Test_Add_Above_Max_Capacity()
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => db.Add(17));
        }

        [Test]
        public void Test_Add_Below_Max_Capacity()
        {
            var db = new Database(1, 2, 3, 4, 5);

            db.Add(1);

            Assert.IsTrue(db.Count == 6);
        }

        [Test]
        public void Test_Remove_Empty_Database()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void Test_Fetch_Returns_Array()
        {
            var db = new Database(1, 2, 3, 4, 5);

            var fetch = db.Fetch();

            Assert.That(fetch, Is.TypeOf(typeof(int[])));

            Assert.That(fetch.Length == db.Count);
        }

        [Test]
        public void Test_Remove_Valid()
        {
            Database db = new Database(1,2,3);
            db.Remove();

            Assert.That(db.Count == 2);
        }
    }
}
