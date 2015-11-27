﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http.Results;
using Contacts.Web.Controllers.Api;
using Contacts.Web.Entities;
using Contacts.Web.Models.Contact;
using Contacts.Web.Tests.Async;
using Contacts.Web.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Contacts.Web.Tests
{
    [TestClass]
    public class ContactsControllerGetActionShould
    {
        private Mock<IContactsDbContext> _mockDbContext;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            AutoMapperConfig.RegisterMappings();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _mockDbContext = new MockContactsDbContext();
        }

        [TestMethod]
        public void ReturnOneResultIfParameterTopWasOne()
        {
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Get(top: 1).Result;

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void SkipFirstResultIfParamterSkipWasOne()
        {
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Get(skip: 1).Result;

            Assert.AreEqual(2, result.Select(x => x.Id).FirstOrDefault());
        }

        [TestMethod]
        public void OrderResultsAlphabetically()
        {
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Get().Result.ToList();

            Assert.AreEqual("Darth", result.First().FirstName);
            Assert.AreEqual("Leia", result.Skip(1).First().FirstName);
            Assert.AreEqual("Luke", result.Skip(2).First().FirstName);
        }

        [TestMethod]
        public void ReturnOneResultIfParameterIdWasGivenAndFound()
        {
            var id = 1;
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Get(id).Result;

            var okResult = result as OkNegotiatedContentResult<ContactListModel>;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(1, okResult.Content.Id);
        }

        [TestMethod]
        public void ReturnNotFoundIfParameterIdWasGivenButNotFound()
        {
            var id = 0;
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Get(id).Result;

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
