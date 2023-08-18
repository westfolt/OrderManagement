using NUnit.Framework;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Core.Validation;
using OrderManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Tests.Unit
{
    public class CreateOrderValidatorTests
    {
        private CreateOrdRequestValidator sut;

        [SetUp]
        public void Setup()
        {
            sut = new CreateOrdRequestValidator();
        }

        [Test]
        public void ShouldNotReturnErrorsForCorrectData()
        {
            var testData = CreateCorrectOrderRequest();
            var result = sut.Validate(testData);
            Assert.IsTrue(result.IsValid);
        }

        [TestCase("empty", "Order Date is required")]
        [TestCase("future", "Order Date cannot be in the future")]
        public void ShouldReturnErrorForWrongOrderDate(string test, string errorMessage)
        {
            var testData = CreateCorrectOrderRequest();

            switch (test)
            {
                case "empty":
                    testData.OrderDate = new DateTime();
                    break;
                case "future":
                    testData.OrderDate = testData.OrderDate.AddDays(1);
                    break;
            }

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase("empty", "Order Number is required")]
        [TestCase("length", "Order Number must be 10 characters or less")]
        public void ShouldReturnErrorForWrongLastName(string test, string errorMessage)
        {
            var testData = CreateCorrectOrderRequest();

            switch (test)
            {
                case "empty":
                    testData.OrderNumber = "";
                    break;
                case "length":
                    testData.OrderNumber = new string('a', 11);
                    break;
            }

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(errorMessage));
        }

        public void ShouldReturnErrorForWrongCustomerId(string test, string errorMessage)
        {
            var testData = CreateCorrectOrderRequest();

            testData.CustomerId = 0;

            var result = sut.Validate(testData);
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Customer Id should be above zero"));
        }

        private CreateOrderRequest CreateCorrectOrderRequest()
        {
            return new CreateOrderRequest
            {
                OrderNumber = "123456789",
                OrderDate = DateTime.Now.AddMinutes(-1),
                CustomerId = 1,
                Status = OrderStatus.Created
            };
        }
    }
}
