using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizzNoGood.Business;
using QuizzNoGood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzNoGood.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestHTML()
        {
            var u = User.CreateNewUser(1, "<h1>TEST</h1>", "mmmkbqzdmlqhbfmkb");
            Assert.AreEqual("TEST", u.Username);
        }

    }
}
