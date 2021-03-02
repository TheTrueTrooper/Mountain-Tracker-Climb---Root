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
    public class _RockClimbingDifficultiesAPIControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            RockClimbingDifficultiesController controller = new  RockClimbingDifficultiesController();

            // Act
            IEnumerable<MTCSharedModels.Models.RockClimbingDifficulty> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(33, result.Count());
            //
            Assert.AreEqual(0, result.ElementAt(0).ID);
            Assert.AreEqual("5.1", result.ElementAt(0).EnglishCode.Trim());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            RockClimbingDifficultiesController controller = new RockClimbingDifficultiesController();

            // Act
            MTCSharedModels.Models.RockClimbingDifficulty result = controller.Get(0);

            // Assert
            Assert.AreEqual(0, result.ID);
            Assert.AreEqual("5.1", result.EnglishCode.Trim());
        }
    }
    //[TestClass]
    //public class ValuesControllerTest
    //{
    //    [TestMethod]
    //    public void Get()
    //    {
    //        // Arrange
    //        ValuesController controller = new ValuesController();

    //        // Act
    //        IEnumerable<string> result = controller.Get();

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(2, result.Count());
    //        Assert.AreEqual("value1", result.ElementAt(0));
    //        Assert.AreEqual("value2", result.ElementAt(1));
    //    }

    //    [TestMethod]
    //    public void GetById()
    //    {
    //        // Arrange
    //        ValuesController controller = new ValuesController();

    //        // Act
    //        string result = controller.Get(5);

    //        // Assert
    //        Assert.AreEqual("value", result);
    //    }

    //    [TestMethod]
    //    public void Post()
    //    {
    //        // Arrange
    //        ValuesController controller = new ValuesController();

    //        // Act
    //        controller.Post("value");

    //        // Assert
    //    }

    //    [TestMethod]
    //    public void Put()
    //    {
    //        // Arrange
    //        ValuesController controller = new ValuesController();

    //        // Act
    //        controller.Put(5, "value");

    //        // Assert
    //    }

    //    [TestMethod]
    //    public void Delete()
    //    {
    //        // Arrange
    //        ValuesController controller = new ValuesController();

    //        // Act
    //        controller.Delete(5);

    //        // Assert
    //    }
    //}
}
