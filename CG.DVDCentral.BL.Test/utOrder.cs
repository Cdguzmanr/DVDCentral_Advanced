using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(3, OrderManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Order order = new Order()
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                UserId  = 1,
                ShipDate = DateTime.Now
            };

            int results = OrderManager.Insert(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Order order = OrderManager.LoadById(3);
            order.CustomerId = 2;
            int results = OrderManager.Update(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}