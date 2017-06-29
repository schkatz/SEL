using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using SELClient.Interfaces;
using System.Collections.Generic;
using Resfull.Models;
using SELClient.Controller;

namespace SELTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //arrange
            Mock<IGet> test = new Mock<IGet>();
            test.Setup(x=>x.GetUsers()).Returns(new List<Users>() { new Users() {UserNick="testowy"} } );
            //act
            List<Users> expected = new List<Users>() { new Users() { UserNick = "testowy" } };
            var expected2 = new GetTables(test.Object);
            List<Users> expected3 = expected2.GetUsers();
            //assert
            NUnit.Framework.Assert.AreEqual(expected,expected3);
        }
    }
}
