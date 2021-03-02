using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mountain_Tracker_Climb___API;
using Mountain_Tracker_Climb___API.Controllers;

namespace Mountain_Tracker_Climb___API.Tests.Controllers
{
    [TestClass]
    public class _GearAPIControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            GearController controller = new GearController();

            // Act
            IEnumerable<MTCSharedModels.Models.Gear> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.Count());
            //
            Assert.AreEqual((byte)0, result.ElementAt(0).ID);
            Assert.AreEqual("Rope", result.ElementAt(0).EnglishFullName);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            GearController controller = new GearController();

            // Act
            MTCSharedModels.Models.Gear result = controller.Get(0);

            // Assert
            Assert.AreEqual((byte)0, result.ID);
            Assert.AreEqual("Rope", result.EnglishFullName);
        }
    }
}
