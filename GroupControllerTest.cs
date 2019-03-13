using System;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;
using WebApplication.Models;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class GroupControllerTest
    {
        [TestMethod]
        public void TestViewCreateGroup()
        {
            var controller = new GroupController();
            var db = new cap21t4Entities();
            var create = new Group();

            var viewResult = controller.Create() as ViewResult;

            Assert.IsNotNull(viewResult);

        }

        [TestMethod]
        public void TestCreateGroupSuccessfully()
        {

            //Arange
            var controller = new GroupController();
            var user = new Group();
            var db = new cap21t4Entities();
            Group edit = db.Groups.First();
            edit.GroupName = "Nhóm 1.5";
            edit.GroupDescription = "Mobile App";

            using (var scope = new TransactionScope())
            {

                var result1 = controller.Edit(db.Groups.First().ID.ToString()) as ViewResult;
                Assert.IsNotNull(result1);

            }

        }
    }

}
