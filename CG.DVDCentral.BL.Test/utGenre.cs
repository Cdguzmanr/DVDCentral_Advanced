using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(4, GenreManager.Load().Count);
        }
    }
}