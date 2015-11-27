using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Contacts.Web.Controllers.Api;
using Contacts.Web.Entities;
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
        public void ReturnOneResultWithRequestedIdIfParameterIdWasGiven()
        {
            var id = 1;
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Get(id).Result;

            Assert.AreEqual(1, result.Id);
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
    }
}
