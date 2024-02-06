using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase<tblOrder>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var orders = base.LoadTest();
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
            tblOrder row = dc.tblOrders.FirstOrDefault();

            if (row != null)
            {
                row.OrderDate = DateTime.Now;
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

    }
}
