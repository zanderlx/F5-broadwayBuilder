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
            var numberOfBreaches = PasswordBreachValidator.GetNumberOfBreaches(plaintext);
            var expected = true;
            var actual = false;

            // Act
            if (numberOfBreaches > 0) actual = true;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConsumePasswordAPI_PasswordIsSecure_Pass()
        {
            // Arrange
            var plaintext = "Th!sP@assw0rd1sS3cuRed";
            var numberOfBreaches = PasswordBreachValidator.GetNumberOfBreaches(plaintext);
            var expected = true;
            var actual = false;

            // Act
            if (numberOfBreaches < 0) actual = true;

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

        [TestMethod]
        public void GetPrefixOfHash_Pass()
        {
            // Arrange
            string hash = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8".ToUpper();

            // The expected SHA-1 hash for the plaintext
            var expected = "5BAA6";
            var actual = "";

            // Act
            actual = PasswordBreachValidator.GetHashPrefix(hash);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHashSuffix_Pass()
        {
            // Arrange
            string hash = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8".ToUpper();

            // The expected SHA-1 hash for the plaintext
            var expected = "1e4c9b93f3f0682250b6cf8331b7ee68fd8".ToUpper();
            var actual = "";

            // Act
            actual = PasswordBreachValidator.GetHashSuffix(hash);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BreachFrequencyRange_NumberLessThanRange_Pass()
        {
            //Arrange 
            int secure = 1;

            //Act
            var expected = true;
            var actual = PasswordBreachValidator.ValidateBreachFrequencyRange(secure);

            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BreachFrequencyRange_NumberGreaterThanRange_Pass()
        {
            //Arrange 
            int secure = 3;

            //Act
            var expected = false;
            var actual = PasswordBreachValidator.ValidateBreachFrequencyRange(secure);

            //Assert 
            Assert.AreEqual(expected, actual);
        }

    }
}
