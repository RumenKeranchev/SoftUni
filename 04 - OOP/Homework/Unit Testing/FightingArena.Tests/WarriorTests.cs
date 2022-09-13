namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using FightingArena;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Test_Invalid_Name()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 200, 400));
        }
        
        [Test]
        public void Test_Invalid_Damage()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Joe", -200, 400));
        }
        
        [Test]
        public void Test_Invalid_HP()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Joe", 200, -400));
        }

        [Test]
        public void Test_Attack_With_Low_Attacker_HP()
        {
            var attacker = new Warrior("Joe", 100, 20);
            var defender = new Warrior("Shmoe", 90, 300);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        
        [Test]
        public void Test_Attack_With_Low_Defender_HP()
        {
            var attacker = new Warrior("Joe", 100, 200);
            var defender = new Warrior("Shmoe", 90, 20);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        
        [Test]
        public void Test_Attack_Stronger_Enemy()
        {
            var attacker = new Warrior("Joe", 100, 200);
            var defender = new Warrior("Shmoe", 900, 200);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        
        [Test]
        public void Test_Attack_Valid_Enemy_With_Normal_Strength()
        {
            var attacker = new Warrior("Joe", 100, 200);
            var defender = new Warrior("Shmoe", 90, 200);
            attacker.Attack(defender);

            Assert.That(attacker.HP == 110);
        }
        
        [Test]
        public void Test_Attack_Valid_Enemy_With_Super_Strength()
        {
            var attacker = new Warrior("Joe", 300, 200);
            var defender = new Warrior("Shmoe", 90, 200);
            attacker.Attack(defender);

            Assert.Zero(defender.HP);
        }
    }
}