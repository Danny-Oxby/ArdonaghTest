using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammingTest.Services.Tests
{
    [TestClass()]
    public class ValidationServiceTests
    {
        #region name tests
        [TestMethod()]
        public void NameValidationCorrectInputTest()
        {
            Assert.IsTrue(ValidationService.NameValidation("Henry Cavel"), "NameValidationCorrectInputTest Returned False instead of True");
        }
        [TestMethod()]
        public void NameValidationInCorrectInputTest()
        {
            string lengthtest = "123456789012345678901234567890123456789012345678901234567890";

            Assert.IsTrue(lengthtest.Length > 50, "Not testing the correct length of input");
            Assert.IsFalse(ValidationService.NameValidation(lengthtest), "NameValidationInCorrectInputTest Returned True instead of False");
        }
        [TestMethod()]
        public void NameValidationNullInputTest()
        {
            Assert.IsFalse(ValidationService.NameValidation(null), "NameValidationNullInputTest Returned True instead of False");
        }
        #endregion

        #region age tests
        [TestMethod()]
        public void AgeValidationCorrectInputTest()
        {
            int agetest = 48;

            Assert.IsTrue(agetest >= 0 && agetest <= 110, "Testing value is out of intended scope");
            Assert.IsTrue(ValidationService.AgeValidation(agetest), "AgeValidationCorrectInputTest Returned False instead of True");

            int boundryagetest = 110;
            Assert.IsTrue(boundryagetest >= 0 && boundryagetest <= 110, "Testing boundry value is out of intended scope");
            Assert.IsTrue(ValidationService.AgeValidation(boundryagetest), "AgeValidationCorrectInputTest boundry Returned False instead of True");

        }

        [TestMethod()]
        public void AgeValidationInCorrectInputTest()
        {
            int agetest = -1;

            Assert.IsTrue(agetest < 0, "Testing value is out of intended scope");
            Assert.IsFalse(ValidationService.AgeValidation(agetest), "AgeValidationCorrectInputTest Returned True instead of False");

            int boundryagetest = 111;
            Assert.IsTrue(boundryagetest > 110, "Testing boundry value is out of intended scope");
            Assert.IsFalse(ValidationService.AgeValidation(boundryagetest), "AgeValidationCorrectInputTest boundry Returned True instead of False");

        }
        #endregion

        #region postcode tests
        [TestMethod()]
        public void PostcodeValidationCorrectInputTest() {
            Assert.IsTrue(ValidationService.PostCodeValidation("AS21 4FG"), "PostCodeVaildation Returned False instead of True");
        }

        [TestMethod()]
        public void PostcodeValidationInCorrectInputTest() { 
            Assert.IsFalse(ValidationService.PostCodeValidation("ASGB UFG"), "PostCodeVaildation Returned True instead of False");
        }
        #endregion

        #region age tests
        [TestMethod()]
        public void HeightValidationCorrectInputTest()
        {
            double hieghttest = 1.48;
            Assert.IsTrue(hieghttest > 0 && hieghttest <= 2.50, "Testing value is out of intended scope");
            Assert.IsTrue(ValidationService.HeightValidation(hieghttest), "HeightValidationCorrectInputTest Returned False instead of True");

            double boundryhieghttest = 2.50;
            Assert.IsTrue(hieghttest > 0 && hieghttest <= 2.50, "Testing boundry value is out of intended scope");
            Assert.IsTrue(ValidationService.HeightValidation(boundryhieghttest), "HeightValidationCorrectInputTest boundry Returned False instead of True");

        }

        [TestMethod()]
        public void HeightValidationInCorrectInputTest()
        {
            double agetest = -1;

            Assert.IsTrue(agetest < 0, "Testing value is out of intended scope");
            Assert.IsFalse(ValidationService.HeightValidation(agetest), "HeightValidationInCorrectInputTest Returned True instead of False");

            double boundryagetest = 2.51;
            Assert.IsTrue(boundryagetest > 2.50, "Testing boundry value is out of intended scope");
            Assert.IsFalse(ValidationService.HeightValidation(boundryagetest), "HeightValidationInCorrectInputTest boundry Returned True instead of False");

        }
        #endregion
    }
}