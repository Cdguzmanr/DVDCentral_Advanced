using Microsoft.EntityFrameworkCore.Storage;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector
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

            Assert.AreEqual(3, dc.tblDirectors.Count()); // Assert means "test"
            // Check Lenght
        }

        [TestMethod]
        public void InsertTest()
        {
            //Make an entity
            tblDirector entity = new tblDirector();
            entity.Id = -99;
            entity.FirstName = "Test";
            entity.LastName = "Test";

            //add the entity to the database
            dc.tblDirectors.Add(entity);

            //Commit the changes
            int result = dc.SaveChanges();

            // Check that the results are positive
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // select * from tblProgram - use the first one 
            tblDirector entity = dc.tblDirectors.FirstOrDefault();

            // Change property values
            entity.FirstName = "New FirstName";
            entity.LastName = "New LastName";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0); // Just a different way to assert 
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Select * from tblProgram where id = 2
            tblDirector entity = dc.tblDirectors.Where(e => e.Id == 2).FirstOrDefault();

            dc.tblDirectors.Remove(entity);

            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void LoadById()
        {
            // Two line test
            tblDirector entity = dc.tblDirectors.Where(e => e.Id == 2).FirstOrDefault();

            Assert.AreEqual(entity.Id, 2);
        }
    }
}