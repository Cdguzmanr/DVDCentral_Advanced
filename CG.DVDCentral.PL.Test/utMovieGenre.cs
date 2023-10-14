using Microsoft.EntityFrameworkCore.Storage;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void Initialize()
        {
            dc = new DVDCentralEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }


        // Project Tests //

        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            Assert.AreEqual(3, dc.tblMovieGenres.Count()); // Assert means "test"
            // Check Lenght
        }

        [TestMethod]
        public void InsertTest()
        {
            //Make an entity
            tblMovieGenre entity = new tblMovieGenre();
            entity.MovieId = 1;
            entity.GenreId = 2;
            entity.Id = -99;

            //add the entity to the database
            dc.tblMovieGenres.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            // Check that the results are positive
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // select * from tblProgram - use the first one 
            tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault();

            // Change property values
            entity.MovieId = 3;

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0); // Just a different way to assert 
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblProgram where id = 2
            tblMovieGenre entity = dc.tblMovieGenres.Where(e => e.Id == 2).FirstOrDefault();

            dc.tblMovieGenres.Remove(entity);

            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadById()
        {
            // Two line test
            tblMovieGenre entity = dc.tblMovieGenres.Where(e => e.Id == 2).FirstOrDefault();

            Assert.AreEqual(entity.Id, 2);
        }
    }
}