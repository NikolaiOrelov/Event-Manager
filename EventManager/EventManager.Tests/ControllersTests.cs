using Castle.DynamicProxy;
using EventManager.Controllers;
using EventManager.Data;
using EventManager.Data.Models;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ControllersTests
    {
        private Mock<EventManagerDbContext> fakeDbContext;
        private Mock<EventsController> fakeEventsController;

        [SetUp]
        public void Setup()
        {
            fakeDbContext = new Mock<EventManagerDbContext>();
            fakeEventsController = new Mock<EventsController>();
        }


        //EventsController Create Method Tests:
        /// <summary>
        /// EventsController Create Method Tests:
        /// </summary>
        [Test]
        public void CreateValidationIsWorkingIfNameIsNull()
        {
            DateTime time = default(DateTime);
            CreateAddressViewModel someViewModel = default(CreateAddressViewModel);

            Assert.Throws<InvalidProxyConstructorArgumentsException>
                (() => fakeEventsController.Object.Create(null, time, "description", "link", someViewModel),
                "There is no information in one or more of the following fields: EventName, AddressName, CityName and Date!");
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void CreateValidationIsWorkingIfDateIsMinValue()
        {
            DateTime time = DateTime.MinValue;
            CreateAddressViewModel someViewModel = default(CreateAddressViewModel);

            Assert.Throws<InvalidProxyConstructorArgumentsException>
                (() => fakeEventsController.Object.Create("eventName", time, "description", "link", someViewModel),
                "There is no information in one or more of the following fields: EventName, AddressName, CityName and Date!");
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void CreateValidationIsWorkingIfAddressViewModelIsNull()
        {
            DateTime time = DateTime.MinValue;
            CreateAddressViewModel someViewModel = null;

            Assert.Throws<InvalidProxyConstructorArgumentsException>
                (() => fakeEventsController.Object.Create("eventName", time, "description", "link", someViewModel),
                "There is no information in one or more of the following fields: EventName, AddressName, CityName and Date!");
        }

    }
}