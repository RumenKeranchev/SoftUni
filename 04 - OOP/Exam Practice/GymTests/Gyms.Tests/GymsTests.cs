namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void Test_Null_Gym_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 20));
        }
        
        [Test]
        public void Test_Below_0_Gym_Capacity()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Gymbo", -1));
        }
        
        [Test]
        public void Test_0_Gym_Capacity()
        {
            var gym = new Gym("Gymbo", 0);

            Assert.Zero(gym.Capacity);
        }
        
        [Test]
        public void Test_Gym_Athletes_Count()
        {
            var gym = new Gym("Gymbo", 0);

            Assert.Zero(gym.Count);
        }
        
        [Test]
        public void Test_Add_Athletes_Above_Capacity()
        {
            var gym = new Gym("Gymbo", 0);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("JoJo")));
        }
        
        [Test]
        public void Test_Add_Athletes_Below_Capacity()
        {
            var gym = new Gym("Gymbo", 2);
            gym.AddAthlete(new Athlete("JoJo"));
            Assert.IsTrue(gym.Count == 1);
        }
        
        [Test]
        public void Test_Remove_Missing_Athlete()
        {
            var gym = new Gym("Gymbo", 2);
            gym.AddAthlete(new Athlete("JoJo"));
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Dio"));
        }
        
        [Test]
        public void Test_Remove_Exisitng_Athlete()
        {
            var gym = new Gym("Gymbo", 2);
            gym.AddAthlete(new Athlete("JoJo"));
            gym.RemoveAthlete("JoJo");

            Assert.IsTrue(gym.Count == 0);
        }
        
        [Test]
        public void Test_Injure_Exisiting_Athlete()
        {
            var gym = new Gym("Gymbo", 2);
            gym.AddAthlete(new Athlete("JoJo"));
            var athlete = gym.InjureAthlete("JoJo");

            Assert.IsTrue(athlete.IsInjured);
        }
        
        [Test]
        public void Test_Injure_Missing_Athlete()
        {
            var gym = new Gym("Gymbo", 2);
            gym.AddAthlete(new Athlete("JoJo"));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Dio"));
        }
        
        [Test]
        public void Test_Report()
        {
            var gym = new Gym("Gymbo", 2);
            gym.AddAthlete(new Athlete("JoJo"));
            gym.AddAthlete(new Athlete("Dio"));
            gym.InjureAthlete("Dio");

            var expectedReport = $"Active athletes at Gymbo: JoJo";

            Assert.AreEqual(expectedReport, gym.Report());
        }
    }
}
