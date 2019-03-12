using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication;
using WebApplication.Controllers;
using WebApplication.Models;



namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateGroupSuccessFully()
        {
            var controller = new GroupController();
            var user = new Group();
            var db = new cap21t4Entities();
            var file = new Mock<HttpPostedFileBase>();

            Group create = db.Groups.First();
            create.GroupParent = db.Groups.First().ID;
            create.GroupName = "Nhóm 1.4";
            create.GroupDescription = "Quality Management";

            file.Setup(f => f.ContentLength).Returns(1);
            using (var scope = new TransactionScope())
            {

                file.Setup(f => f.ContentLength).Returns(0);
                var result1 = controller.Create(create) as ViewResult;
                Assert.IsNotNull(result1);
                Assert.IsInstanceOfType(result1.ViewData["GroupParent"], typeof(SelectList));


            }
        }
        }
}
