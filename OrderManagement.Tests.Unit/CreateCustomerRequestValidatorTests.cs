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
            var testData = CreateCorrectCustomer();
            var result = sut.Validate(testData);
            Assert.IsTrue(result.IsValid);
        }

        [TestCase("empty", "First name is required.")]
        [TestCase("length", "First name cannot exceed 50 characters.")]
        public void ShouldReturnErrorForWrongFirstName(string test, string errorMessage)
        {
            var testData = CreateCorrectCustomer();

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

        private CreateCustomerRequest CreateCorrectCustomer()
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