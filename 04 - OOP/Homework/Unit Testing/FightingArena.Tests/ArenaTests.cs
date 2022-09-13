namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_Enroll_Warrior()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Pesho", 100, 200));

            Assert.IsTrue(arena.Count == 1);
        }
        
        [Test]
        public void Test_Enroll_Same_Warrior()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Pesho", 100, 200));

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Pesho", 100, 200)));
        }
        
        [Test]
        public void Test_Warriors_Are_Read_Only()
        {
            Assert.IsTrue(typeof(Arena).GetProperty(nameof(Arena.Warriors)).CanWrite == false);
        }

        [Test]
        public void Test_Warriors_Have_Any()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Pesho", 100, 200));

            Assert.IsTrue(arena.Warriors.Count == 1);
        }

        [Test]
        public void Test_Valid_Fight()
        {
            var attacker = new Warrior("Joe", 100, 200);
            var defender = new Warrior("Shmoe", 90, 200);

            var arena = new Arena();
            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.DoesNotThrow(() => arena.Fight(attacker.Name, defender.Name));
        }
        
        [Test]
        public void Test_Invalid_Attacker()
        {
            var attacker = new Warrior("Joe", 100, 200);
            var defender = new Warrior("Shmoe", 90, 200);

            var arena = new Arena();
            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("joe", defender.Name));
        }
        
        [Test]
        public void Test_Invalid_Defender()
        {
            var attacker = new Warrior("Joe", 100, 200);
            var defender = new Warrior("Shmoe", 90, 200);

            var arena = new Arena();
            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Joe", "Pesho"));
        }
    }
}
