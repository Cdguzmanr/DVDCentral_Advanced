using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(3, FormatManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Format format = new Format()
            {
                Description = "Test"
            };

            int results = FormatManager.Insert(format, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Format format = FormatManager.LoadById(3);
            format.Description = "UpdateTest";
            int results = FormatManager.Update(format, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = FormatManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}