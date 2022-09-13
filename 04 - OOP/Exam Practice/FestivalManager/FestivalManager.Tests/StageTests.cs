// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Test_Add_Valid_Performer()
	    {
			var stage = new Stage();
			var performer = new Performer("Dio", "Brando", 25);
			stage.AddPerformer(performer);

			Assert.IsTrue(stage.Performers.Count == 1);
		}
		
		[Test]
	    public void Test_Add_Invalid_Performer()
	    {
			var stage = new Stage();
			var performer = new Performer("Dio", "Brando", 17);	

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}
		
		[Test]
	    public void Test_Add_Null_Song()
	    {
			var stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}
		
		[Test]
	    public void Test_Add_Invalid_Song()
	    {
			var stage = new Stage();
			var song = new Song("JoJo's theme", new TimeSpan(0, 0, 45));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}
		
		[Test]
	    public void Test_Add_Valid_Song()
	    {
			var stage = new Stage();
			var song = new Song("JoJo's theme", new TimeSpan(0, 1, 45));
			Assert.DoesNotThrow(() => stage.AddSong(song));
		}
		
		[Test]
	    public void Test_Add_Song_To_Invalid_Performer()
	    {
			var stage = new Stage();
			var song = new Song("JoJo's theme", new TimeSpan(0, 1, 45));
			var performer = new Performer("Dio", "Brando", 25);
			stage.AddSong(song);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("JoJo's theme", "dio"));
		}
		
		[Test]
	    public void Test_Add_Song_To_Valid_Performer()
	    {
			var stage = new Stage();
			var song = new Song("JoJo's theme", new TimeSpan(0, 1, 45));
			var performer = new Performer("Dio", "Brando", 25);
			stage.AddSong(song);
			stage.AddPerformer(performer);

			Assert.DoesNotThrow(() => stage.AddSongToPerformer("JoJo's theme", "Dio Brando"));
		}
		
		[Test]
	    public void Test_Add_Invalid_Song_To_Valid_Performer()
	    {
			var stage = new Stage();
			var song = new Song("JoJo's theme", new TimeSpan(0, 1, 45));
			var performer = new Performer("Dio", "Brando", 25);
			stage.AddSong(song);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("JoJo", "Dio Brando"));
		}

		[Test]
		public void Test_Play()
		{
			var stage = new Stage();
			var song = new Song("JoJo's theme", new TimeSpan(0, 1, 45));
			var performer = new Performer("Dio", "Brando", 25);
			stage.AddSong(song);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer("JoJo's theme", "Dio Brando");

			var result = stage.Play();
			var expected = $"{1} performers played {1} songs";

			Assert.IsTrue(expected.Equals(result));
		}
	}
}