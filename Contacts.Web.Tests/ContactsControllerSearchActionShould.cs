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
    public class ContactsControllerSearchActionShould
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
        public void ReturnNoResultsIfSearchPhraseIsEmpty()
        {
            var phrase = "";
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Search(phrase).Result;

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void ReturnNoResultsIfSearchPhraseIsNull()
        {
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Search(null).Result;

            Assert.AreEqual(0, result.Count());
        }
    }
}
