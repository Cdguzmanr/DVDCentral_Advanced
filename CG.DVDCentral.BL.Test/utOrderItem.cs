using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(3, OrderItemManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            OrderItem orderItem = new OrderItem()
            {
                OrderId = 1,
                Quantity = 2,
                MovieId  = 1,
                Cost = 14
            };

            int results = OrderItemManager.Insert(orderItem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            OrderItem orderItem = OrderItemManager.LoadById(3);
            orderItem.OrderId = 1;
            int results = OrderItemManager.Update(orderItem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderItemManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }

        // Checkpoint 4
        [TestMethod]
        public void LoadByOrderIdTest()
        {
            int orderId = OrderItemManager.Load().FirstOrDefault().OrderId; 
            Assert.IsTrue(OrderItemManager.LoadByOrderId(orderId).Count > 0);
        }
    }
}