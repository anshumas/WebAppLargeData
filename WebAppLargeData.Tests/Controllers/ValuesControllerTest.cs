using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAppLargeData;
using WebAppLargeData.Controllers;
using WebAppLargeData.Manager;
using WebAppLargeData.POCO;

namespace WebAppLargeData.Tests.Controllers
{
    [TestClass]
    public class LargeDataControllerTest
    {
        private Mock<ILargeDataManager> _repo = null;
        [TestMethod]
        public void Get()
        {
            // Arrange
            _repo = new Mock<ILargeDataManager>(); 
            LargeDataController controller = new LargeDataController(_repo.Object);

            // Act
            IEnumerable<CustomLargeDataEntity> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            _repo = new Mock<ILargeDataManager>();
            LargeDataController controller = new LargeDataController(_repo.Object);

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            _repo = new Mock<ILargeDataManager>();
            LargeDataController controller = new LargeDataController(_repo.Object);

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            _repo = new Mock<ILargeDataManager>();
            LargeDataController controller = new LargeDataController(_repo.Object);

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            _repo = new Mock<ILargeDataManager>();
            LargeDataController controller = new LargeDataController(_repo.Object);

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
