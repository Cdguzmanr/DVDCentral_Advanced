using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var orders = dc.tblOrders;
            Assert.AreEqual(expected, orders.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrder newRow = new tblOrder();

            newRow.Id = Guid.NewGuid();
            newRow.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            newRow.OrderDate = DateTime.Now;
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;
            newRow.ShipDate = DateTime.Now;

            dc.tblOrders.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblOrder row = dc.tblOrders.FirstOrDefault();

            if (row != null)
            {
                row.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblOrder row = dc.tblOrders.FirstOrDefault();

            if (row != null)
            {
                dc.tblOrders.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
