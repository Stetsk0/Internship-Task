using Internship_Task.Data;

namespace Tests
{
    public class EmailValidatorTests
    {
        [TestCase("valid.email@example.com")]
        [TestCase("onemore.valid.email@example.co.uk")]
        [TestCase("test.email123@example-domain.com")]
        public void IsValidEmail_ValidEmail_ReturnsTrue(string email)
        {
            EmailValidator emailValidator = new EmailValidator();

            bool isValid = emailValidator.IsValidEmail(email);

            Assert.IsTrue(isValid);
        }

        [TestCase("invalid.email")]
        [TestCase("12345@")]
        [TestCase("invalid.email@")]
        [TestCase("invalid.email@.com")]
        public void IsValidEmail_InvalidEmail_ReturnsFalse(string email)
        {
            EmailValidator emailValidator = new EmailValidator();

            bool isValid = emailValidator.IsValidEmail(email);

            Assert.IsFalse(isValid);
        }
    }
}