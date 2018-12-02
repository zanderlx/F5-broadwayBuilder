using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceLayer.Test
{
    [TestClass]
    public class PasswordBreachValidatorTests
    {
        [TestMethod]
        public void ConsumePasswordAPI_CheckValidSHA_Pass()
        {
            // Arrange
            string plaintext = "password";

            // The expected SHA-1 hash for the plaintext
            var expected = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8".ToUpper();
            var actual = "";

            // Act
            actual = PasswordBreachValidator.SHA1_ReturnHash(plaintext);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConsumePasswordAPI_PasswordIsInsecure_Pass()
        {
            // Arrange
            var plaintext = "password";
            var hash = PasswordBreachValidator.SHA1_ReturnHash(plaintext);
            var expected = PasswordBreachValidator.GetHashSuffix(hash) + ":" + PasswordBreachValidator.GetNumberOfBreaches(plaintext);
            var actual = "";

            // Act
            actual = PasswordBreachValidator.ConsumePasswordAPI(plaintext);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNumberOfBreaches_BreachesWithinRange_Pass()
        {
            // Arrange
            var plaintext = "password";
            var expected = false;
            var actual = false;

            int BreachFrequeny = PasswordBreachValidator.GetNumberOfBreaches(plaintext);

            // Act
            actual = PasswordBreachValidator.ValidateBreachFrequencyRange(BreachFrequeny);

            // Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
