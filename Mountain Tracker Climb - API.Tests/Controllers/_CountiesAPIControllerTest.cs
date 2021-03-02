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
    public class _CountiesAPIControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            CountiesController controller = new CountiesController();

            // Act
            IEnumerable<MTCSharedModels.Models.Country> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(249, result.Count());
            //
            Assert.AreEqual((byte)39, result.ElementAt(39).ID);
            Assert.AreEqual("Canada", result.ElementAt(39).EnglishFullName);
            Assert.AreEqual("CA", result.ElementAt(39).CountryCode.Trim());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CountiesController controller = new CountiesController();

            // Act
            MTCSharedModels.Models.Country result = controller.Get(39);

            // Assert
            Assert.AreEqual((byte)39, result.ID);
            Assert.AreEqual("Canada", result.EnglishFullName);
            Assert.AreEqual("CA", result.CountryCode.Trim());
        }
    }
}
