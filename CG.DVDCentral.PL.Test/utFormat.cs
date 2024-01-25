
using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 4;
            var formats = dc.tblFormats;
            Assert.AreEqual(expected, formats.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblFormat newRow = new tblFormat();

            newRow.Id = Guid.NewGuid();
            newRow.Description = "XXX";

            dc.tblFormats.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblFormat row = dc.tblFormats.FirstOrDefault();

            if (row != null)
            {
                row.Description = "YYYY";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {

            tblFormat row = dc.tblFormats.FirstOrDefault();

            if (row != null)
            {
                dc.tblFormats.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
