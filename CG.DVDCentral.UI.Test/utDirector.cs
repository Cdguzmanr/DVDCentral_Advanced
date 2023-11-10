using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void IndexTest()
        {
            DirectorController controller = new DirectorController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Director));
        }

        [TestMethod]
        public void DetailsTest()
        {
            // Arrange
            DirectorController controller = new DirectorController();

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Director));
        }

        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            DirectorController controller = new DirectorController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditTest()
        {
            // Arrange
            DirectorController controller = new DirectorController();

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Director));
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            DirectorController controller = new DirectorController();

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Director));
        }
    }
}