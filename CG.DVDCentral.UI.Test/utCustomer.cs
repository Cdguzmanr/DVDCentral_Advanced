using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void IndexTest()
        {
            CustomerController controller = new CustomerController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Customer));
        }

        [TestMethod]
        public void DetailsTest()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Customer));
        }

        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditTest()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Customer));
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Customer));
        }
    }
}