using HabitLogger;
namespace DatabaseManagerTest
{
    
    public class Tests
    {
        DatabaseManager manager;
        [SetUp]
        public void Setup()
        {
            manager = new DatabaseManager("HabitsTest");
            manager.deleteAll();
        }

        [Test]
        public void Test01AddHabitToDatabase()
        {
            manager.addToDatabase("Running");
            Assert.AreEqual(manager.count("Running"),1);
        }
        [Test]
        public void Test02AddDifferentHabitsToDatabase()
        {
            manager.addToDatabase("Running");
            manager.addToDatabase("Running");
            manager.addToDatabase("Studying");
            Assert.AreEqual(manager.count("Running"), 2);
            Assert.AreEqual(manager.count("Studying"), 1);
        }
    }
}