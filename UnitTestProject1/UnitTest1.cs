using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_Angular.Controllers;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEndDate_EndDateEqualToStartDate()
        {
            var ctrlObj = new CourseController();

            IHttpActionResult result = ctrlObj.PostCourse(new WebAPI_Angular.Models.Course { Name = "test", StartDate = new DateTime(2019, 1, 1), EndDate = new DateTime(2019, 1, 1) });
            Assert.IsTrue(((CreatedAtRouteNegotiatedContentResult<string>)result).RouteName == "EndDateNotValid");
        }

        [TestMethod]
        public void TestEndDate_StartDateIsAfterEndDate()
        {
            var ctrlObj = new CourseController();

            IHttpActionResult result = ctrlObj.PostCourse(new WebAPI_Angular.Models.Course { Name = "test", StartDate = new DateTime(2019, 1, 2), EndDate = new DateTime(2019, 1, 1) });
            Assert.IsTrue(((CreatedAtRouteNegotiatedContentResult<string>)result).RouteName == "EndDateNotValid");

        }

    }
}
