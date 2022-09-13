namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Test_Capacity_Cant_Be_More_Than_16()
        {
            Assert.Throws<ArgumentException>(() => new Database
            (
                new Person(1,"1"),
                new Person(2,"2"),
                new Person(3,"3"),
                new Person(4,"4"),
                new Person(5,"5"),
                new Person(6,"6"),
                new Person(7,"7"),
                new Person(8,"8"),
                new Person(9,"9"),
                new Person(10,"10"),
                new Person(11,"11"),
                new Person(12,"12"),
                new Person(13,"13"),
                new Person(14,"14"),
                new Person(15,"15"),
                new Person(16,"16"),
                new Person(17,"17")
            ));
        }

        [Test]
        public void Test_Add_Above_Max_Capacity()
        {
            var db = new Database(
                new Person(1, "1"),
                new Person(2, "2"),
                new Person(3, "3"),
                new Person(4, "4"),
                new Person(5, "5"),
                new Person(6, "6"),
                new Person(7, "7"),
                new Person(8, "8"),
                new Person(9, "9"),
                new Person(10, "10"),
                new Person(11, "11"),
                new Person(12, "12"),
                new Person(13, "13"),
                new Person(14, "14"),
                new Person(15, "15"),
                new Person(16, "16")
                );

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(17, "17")));
        }

        [Test]
        public void Test_Add_Below_Max_Capacity()
        {
            var db = new Database(new Person(1, "1"));

            db.Add(new Person(2, "2"));

            Assert.IsTrue(db.Count == 2);
        }
        
        [Test]
        public void Test_Add_With_Same_Name()
        {
            var db = new Database(new Person(1, "1"));
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(2, "1")));
        }  
        
        [Test]
        public void Test_Add_With_Same_Id()
        {
            var db = new Database(new Person(1, "1"));
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "2")));
        }

        [Test]
        public void Test_Remove_Empty_Database()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void Test_FindByUsername_For_Non_Existing_User()
        {
            var db = new Database(new Person(1, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Pesho"));
        }
        
        [Test]
        public void Test_FindByUsername_For_Existing_User()
        {
            var db = new Database(new Person(1, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("ivan"));
        }
        
        [Test]
        public void Test_FindByUsername_With_Null()
        {
            var db = new Database(new Person(1, "Ivan"));

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        public void Test_FindById_For_Non_Existing_User()
        {
            var db = new Database(new Person(1, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }
        
        [Test]
        public void Test_FindById_With_Invalid_Id()
        {
            var db = new Database(new Person(-1, "Ivan"));

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void Test_Remove_Valid_User()
        {
            var db = new Database(new Person(1, "Ivan"));
            db.Remove();

            Assert.Zero(db.Count);
        }
        
        [Test]
        public void Test_Find_Valid_User_By_UserName()
        {
            var db = new Database(new Person(1, "Ivan"));
            var user = db.FindByUsername("Ivan");

            Assert.That(user.Id == 1);
        }
        
        [Test]
        public void Test_Find_Valid_User_By_Id()
        {
            var db = new Database(new Person(1, "Ivan"));
            var user = db.FindById(1);

            Assert.That(user.UserName == "Ivan");
        }
    }
}