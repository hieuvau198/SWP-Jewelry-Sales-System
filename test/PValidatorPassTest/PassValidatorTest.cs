using NhatPValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PValidatorTest
{
    [TestClass]
    public class PassValidatorTest
    {
        [TestMethod]
        public void TestPasswordWithSpaces()
        {
            Assert.IsFalse(PassValidator.IsValid("Pass word1!"));
        }
        [TestMethod]
        public void TestPasswordWithoutDigits()
        {
            Assert.IsFalse(PassValidator.IsValid("Password!"));
        }

        [TestMethod]
        public void TestPasswordTooShort()
        {
            Assert.IsFalse(PassValidator.IsValid("P@ss1"));
        }

        [TestMethod]
        public void TestPasswordTooLong()
        {
            Assert.IsFalse(PassValidator.IsValid("P@ssword1ThisIsWayTooLong"));
        }

        [TestMethod]
        public void TestPasswordWithoutLowerCase()
        {
            Assert.IsFalse(PassValidator.IsValid("PASSWORD1!"));
        }

        [TestMethod]
        public void TestPasswordWithoutUpperCase()
        {
            Assert.IsFalse(PassValidator.IsValid("password1!"));
        }

        [TestMethod]
        public void TestPasswordWithoutSpecialCharacter()
        {
            // this should return fail : "Password1"
            Assert.IsFalse(PassValidator.IsValid("Password1!"));
        }

        [TestMethod]
        public void TestValidPassword()
        {
            // this should return fail : "Passw ord1!"
            Assert.IsTrue(PassValidator.IsValid("Passw ord1!"));
        }
    }
}
