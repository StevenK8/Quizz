using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizzNoGood.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzNoGood.Tests
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public void TestConnection()
        {
            using (var c = new DBConnection())
            {
                Assert.IsTrue(c.IsConnected);
            }
        }

        [TestMethod]
        public void Test()
        {
            using (var c = new DBConnection())
            {
                Assert.IsTrue(c.IsConnected);
                User u = User.CreateNewUser(1, "TestPassword", "passwordNomCrypte");
                c.InsertUser(u);
                User test = c.SelectUser("TestPassword");
                Assert.IsFalse(test.VerifyPassword("passwordNkhckhdhfcomCrypte"));
                Assert.IsTrue(test.VerifyPassword("passwordNomCrypte"));

            }
        }

    }
}
