using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var customers = dc.tblCustomers;
            Assert.AreEqual(expected, customers.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCustomer newRow = new tblCustomer();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Joe";
            newRow.LastName = "Billings";
            newRow.Address = "XXXXXX";
            newRow.City = "Greenville";
            newRow.State = "WI";
            newRow.ZIP = "54942";
            newRow.Phone = "xxx-xxx-xxxx";
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;

            dc.tblCustomers.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblCustomer row = dc.tblCustomers.FirstOrDefault();

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
            InsertTest();

            tblCustomer row = dc.tblCustomers.FirstOrDefault();

            if (row != null)
            {
                dc.tblCustomers.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
