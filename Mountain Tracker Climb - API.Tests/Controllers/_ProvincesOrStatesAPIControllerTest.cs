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
    public class _ProvincesOrStatesAPIControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ProvincesOrStatesController controller = new ProvincesOrStatesController();

            // Act
            IEnumerable<MTCSharedModels.Models.ProvinceOrState> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(33, result.Count()); Lets not do this one as it will grow
            //
            Assert.IsNotNull(result.ElementAt(8).ID);
            Assert.AreEqual((short)8, result.ElementAt(8).ID.Value);
            Assert.AreEqual("AB", result.ElementAt(8).RegionCode.Trim());
            Assert.AreEqual("Alberta", result.ElementAt(8).EnglishFullName);
            Assert.AreEqual((byte)39, result.ElementAt(8).CountryID);
        }

        [TestMethod]
        public void GetByCountryID()
        {
            // Arrange
            ProvincesOrStatesController controller = new ProvincesOrStatesController();

            // Act
            IEnumerable<MTCSharedModels.Models.ProvinceOrState> result = controller.GetByCountry(39);

            // Assert
            Assert.IsNotNull(result.Where(x=>x.RegionCode.Trim() == "AB").ElementAt(0).ID);
            Assert.AreEqual((short)8, result.Where(x => x.RegionCode.Trim() == "AB").ElementAt(0).ID.Value);
            Assert.AreEqual("AB", result.Where(x => x.RegionCode.Trim() == "AB").ElementAt(0).RegionCode.Trim());
            Assert.AreEqual("Alberta", result.Where(x => x.RegionCode.Trim() == "AB").ElementAt(0).EnglishFullName);
            Assert.AreEqual((byte)39, result.Where(x => x.RegionCode.Trim() == "AB").ElementAt(0).CountryID);

            //check an empty too
            result = controller.GetByCountry(0);

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProvincesOrStatesController controller = new ProvincesOrStatesController();

            // Act
            MTCSharedModels.Models.ProvinceOrState result = controller.Get(8);

            // Assert
            Assert.IsNotNull(result.ID);
            Assert.AreEqual((short)8, result.ID.Value);
            Assert.AreEqual("AB", result.RegionCode.Trim());
            Assert.AreEqual("Alberta", result.EnglishFullName);
            Assert.AreEqual((byte)39, result.CountryID);
        }
    }
}
