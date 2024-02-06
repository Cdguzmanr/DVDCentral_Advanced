namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Order> orders = new OrderManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, orders.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Guid id = new OrderManager(options).Load().LastOrDefault().Id;
            Order order = new OrderManager(options).LoadById(id);
            Assert.AreEqual(order.Id, id);
            Assert.IsTrue(order.OrderItems.Count > 0);
        }

        [TestMethod]
        public void LoadByCustomerIdTest()
        {
            Guid customerId = new OrderManager(options).Load().FirstOrDefault().CustomerId;

            Assert.AreEqual(new OrderManager(options).LoadByCustomerId(customerId)[0].CustomerId, customerId);
        }

        [TestMethod]
        public void InsertTest()
        {
            Order order = new Order
            {
                CustomerId = new CustomerManager(options).Load().FirstOrDefault().Id,
                OrderDate = DateTime.Now,
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                ShipDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };

            int result = new OrderManager(options).Insert(order, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void InsertOrderOrderItemsTest()
        {
            Order order = new Order
            {
                CustomerId = new CustomerManager(options).Load().FirstOrDefault().Id,
                OrderDate = DateTime.Now,
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                ShipDate = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Id = Guid.NewGuid(),
                                    MovieId = new MovieManager(options).Load().FirstOrDefault(x => x.Title.Contains("Jaws")).Id,
                                    Cost = 9.99,
                                    Quantity = 9},

                    new OrderItem { Id = Guid.NewGuid(),
                                    MovieId = new MovieManager(options).Load().FirstOrDefault(x => x.Title.Contains("Star")).Id,
                                    Cost = 9.99,
                                    Quantity = 9}
                }
            };

            int result = new OrderManager(options).Insert(order, true);
            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void UpdateTest()
        {
            Order order = new OrderManager(options).Load().FirstOrDefault();
            order.OrderDate = DateTime.Now;

            Assert.IsTrue(new OrderManager(options).Update(order, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Order order = new OrderManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new OrderManager(options).Delete(order.Id, true) > 0);
        }



    }
}
