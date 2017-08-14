using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aplicacao.Controllers;
using Aplicacao.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aplicacao.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidatingList()
        {
            var list = Service.GitHubService.GetAll().items;
            var controller = new HomeController();
            var result = ((ViewResult)controller.Index()).Model as List<GitHubApiItem>;

            Assert.AreEqual(list.Count, result.Count);
        }

        [TestMethod]
        public void ValidatingDetails()
        {
            var item = Service.GitHubService.GetItem(44838949, "apple", "swift");
            var controller = new HomeController();
            var result = ((ViewResult)controller.Detalhes(44838949, "apple", "swift")).Model as GitHubApiItem;

            Assert.AreEqual(item.name, result.name);
        }
    }
}
