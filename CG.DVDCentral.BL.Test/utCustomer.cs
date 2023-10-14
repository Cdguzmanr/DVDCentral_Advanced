using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        { 
            Assert.AreEqual(3, CustomerManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Customer customer = new Customer()
            {
                FirstName = "Test",
                LastName = "Test",
                UserId = 1,
                Address = "Test",
                City = "Test",
                State = "WI",
                ZIP = "Test",
                Phone = "Test",
                ImagePath = "Test"

            };

            int results = CustomerManager.Insert(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Customer customer = CustomerManager.LoadById(3);
            customer.FirstName = "UpdateTest";
            int results = CustomerManager.Update(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = CustomerManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}