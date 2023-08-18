using NUnit.Framework;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Core.Validation;
using OrderManagement.Data.Entities;

namespace OrderManagement.Tests.Unit
{
    public class CreateCustomerRequestValidatorTests
    {
        private CreateCustomerRequestValidator sut;

        [SetUp]
        public void Setup()
        {
            sut = new CreateCustomerRequestValidator();
        }

        [Test]
        public void ShouldNotReturnErrorsForCorrectData()
        {
            var testData = CreateCorrectCustomerRequest();
            var result = sut.Validate(testData);
            Assert.IsTrue(result.IsValid);
        }

        [TestCase("empty", "First name is required.")]
        [TestCase("length", "First name cannot exceed 50 characters.")]
        public void ShouldReturnErrorForWrongFirstName(string test, string errorMessage)
        {
            var testData = CreateCorrectCustomerRequest();

            switch (test)
            {
                case "empty":
                    testData.FirstName = "";
                    break;
                case "length":
                    testData.FirstName = new string('a', 51);
                    break;
            }

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase("empty", "Last name is required.")]
        [TestCase("length", "Last name cannot exceed 50 characters.")]
        public void ShouldReturnErrorForWrongLastName(string test, string errorMessage)
        {
            var testData = CreateCorrectCustomerRequest();

            switch (test)
            {
                case "empty":
                    testData.LastName = "";
                    break;
                case "length":
                    testData.LastName = new string('a', 51);
                    break;
            }

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase("empty", "Email is required.")]
        [TestCase("length", "Email cannot exceed 50 characters.")]
        [TestCase("not-email", "Email must be a valid email address.")]
        public void ShouldReturnErrorForWrongEmail(string test, string errorMessage)
        {
            var testData = CreateCorrectCustomerRequest();

            switch (test)
            {
                case "empty":
                    testData.Email = "";
                    break;
                case "length":
                    testData.Email = "longemail" + new string('a', 40) + "@test.com";
                    break;
                case "not-email":
                    testData.Email = "invalid email";
                    break;

            }

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase("empty", "Phone is required.")]
        [TestCase("not-phone", "Invalid phone number format. It should be 12 digits long (066 included).")]
        public void ShouldReturnErrorForWrongPhone(string test, string errorMessage)
        {
            var testData = CreateCorrectCustomerRequest();

            switch (test)
            {
                case "empty":
                    testData.Phone = "";
                    break;
                case "not-phone":
                    testData.Phone = "+3123123123123123";
                    break;

            }

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(errorMessage));
        }

        private CreateCustomerRequest CreateCorrectCustomerRequest()
        {
            return new CreateCustomerRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johns@mail.com",
                Phone = "+301911122234"
            };
        }
    }
}