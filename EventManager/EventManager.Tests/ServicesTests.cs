using Castle.DynamicProxy;
using EventManager.Controllers;
using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;

namespace EventManager.Tests
{
    public class ServicesTests
    {
        private Mock<EventManagerDbContext> fakeDbContext;
        private Mock<AddressService> fakeAddressService;
        private Mock<CityService> fakeCityService;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            fakeCityService = new Mock<CityService>(fakeDbContext);
            fakeAddressService = new Mock<AddressService>(fakeDbContext, fakeCityService);
        }

        //AddressService CreateAddress Method test:
        /// <summary>
        /// AddressService CreateAddress Method test:
        /// </summary>
        [Test]
        public void AddressCreateMethodValidationIsWorking()
        {
            CreateCityViewModel someViewModel = null;

            Assert.Throws<InvalidProxyConstructorArgumentsException>
                (() => fakeAddressService.Object.CreateAddress(null, someViewModel),
                "Address was not created properly, because of problems in method logic!");
        }

        //AddressService GetAddressIdByName Method test:
        /// <summary>
        /// AddressService GetAddressIdByName Method test:
        /// </summary>
        [Test]
        public void GetAddressIdByNameValidationIsWorking()
        {
            Assert.Throws<InvalidProxyConstructorArgumentsException>
                (() => fakeAddressService.Object.GetAddressIdByName(null),
                "There must be an address name!");
        }

        //CityService GetCityIdByName Method test:
        /// <summary>
        /// AddressService GetAddressIdByName Method test:
        /// </summary>
        [Test]
        public void GetCityIdByNameValidationIsWorking()
        {
            Assert.Throws<InvalidOperationException>
                (() => fakeCityService.Object.GetCityIdByName(null),
                "There must be a city name!");
        }


    }
}

