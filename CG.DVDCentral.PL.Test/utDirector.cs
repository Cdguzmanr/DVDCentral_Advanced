
using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector : utBase
    {


        [TestMethod]
        public void LoadTest()
        {
            int expected = 6;
            var directors = dc.tblDirectors;
            Assert.AreEqual(expected, directors.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblDirector newRow = new tblDirector();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Joe";
            newRow.LastName = "Billings";

            dc.tblDirectors.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblDirector row = dc.tblDirectors.FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "Sarah";
                row.LastName = "Vicchiollo";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblDirector row = dc.tblDirectors.FirstOrDefault();

            if (row != null)
            {
                dc.tblDirectors.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
