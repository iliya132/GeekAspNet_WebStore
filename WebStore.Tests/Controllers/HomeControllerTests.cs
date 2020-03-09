using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Controllers;
using WebStore.Interfaces.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [TestInitialize]
        public void Initialize()
        {
            var logger_mock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(logger_mock.Object);
        }

        [TestMethod]
        public void Index_Returns_View()
        {
            var result = _controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Blog_Returns_View()
        {
            var result = _controller.Blog();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void BlogSingle_Returns_View()
        {
            var result = _controller.BlogSingle();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var result = _controller.Contact();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void ThrowError_Throw_ApplicationException()
        {
            var result = _controller.ThrowError(null);
        }

        [TestMethod]
        public void ThrowError_Throw_ApplicationException2()
        {
            const string expected_exception_message = "Hello World2!";

            var exception = Assert.Throws<ApplicationException>(() => _controller.ThrowError(expected_exception_message));

            Assert.Equal(expected_exception_message, exception.Message);
        }

        [TestMethod]
        public void Error404_Returns_View()
        {
            var result = _controller.NotFound();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ErrorStatus_404_Redirect_to_Error404()
        {
            const string status_code = "404";
            var result = _controller.ErrorStatus(status_code);

            var redirect_to_action = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirect_to_action.ControllerName);
            Assert.Equal(nameof(HomeController.NotFound), redirect_to_action.ActionName);
        }
    }

}
