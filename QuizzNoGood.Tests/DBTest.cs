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
        public void TestInsert()
        {
            using (var c = new DBConnection())
            {
                Assert.IsTrue(c.IsConnected); ;
                c.InsertUser(User.CreateNewUser(1, "Lucas", "passwordNomCrypte"));
            }
        }

    }
}
