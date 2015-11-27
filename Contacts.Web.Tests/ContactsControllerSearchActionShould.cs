using System.Linq;
using Contacts.Web.Controllers.Api;
using Contacts.Web.Entities;
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

        [TestMethod]
        public void ReturnOneResultIfSearchPhraseIsVader()
        {
            var phrase = "vader";
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Search(phrase).Result;

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void ReturnOneResultIfSearchPhraseIsPrincess()
        {
            var phrase = "Princess";
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Search(phrase).Result;

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void OrderResultsAlphabetically()
        {
            var phrase = "a";
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Search(phrase).Result.ToList();

            Assert.AreEqual("Darth", result.First().FirstName);
            Assert.AreEqual("Leia", result.Skip(1).First().FirstName);
            Assert.AreEqual("Luke", result.Skip(2).First().FirstName);
        }
    }
}
