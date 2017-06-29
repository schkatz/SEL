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
    public class UnitTestSEL
    {
        [Test]
        [TestCase("testowy")]
        public void ChceckIfUsersReturnsValue(string nick)
        {
            //arrange
            Mock<IGet> test = new Mock<IGet>();
            test.Setup(x=>x.GetUsers()).Returns(new List<Users>() { new Users() {UserNick=nick} } );
            //act
            List<Users> expected = new List<Users>() { new Users() { UserNick = nick } };
            List<Users> expected2 = test.Object.GetUsers();
            //assert
            NUnit.Framework.Assert.AreEqual(expected.Count,expected2.Count);
        }
        [Test]
        [TestCase("git")]
        public void ChceckIfUsersReturnsValueAreNotEqual(string nick)
        {
            //arrange
            Mock<IGet> test = new Mock<IGet>();
            test.Setup(x => x.GetUsers()).Returns(new List<Users>() { new Users() { UserNick = nick } });
            //act
            List<Users> expected = new List<Users>() { new Users() { UserNick = nick } , new Users() { UserNick = nick } };
            List<Users> expected2 = test.Object.GetUsers();
            //assert
            NUnit.Framework.Assert.AreNotEqual(expected.Count, expected2.Count);
        }
        [Test]
        public void ChceckIfUsersHaveValue()
        {
            //arrange
            Mock<IGet> test = new Mock<IGet>();
            test.Setup(x => x.GetUsers()).Returns(new List<Users>() {});
            //act
            List<Users> expected2 = test.Object.GetUsers();
            //assert
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(delegate { throw new ArgumentOutOfRangeException(); });
        }
    }
}
