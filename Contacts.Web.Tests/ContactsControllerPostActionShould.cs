using System.Linq;
using System.Web.Http.Results;
using Contacts.Web.Controllers.Api;
using Contacts.Web.Entities;
using Contacts.Web.Models.Contact;
using Contacts.Web.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Contacts.Web.Tests
{
    [TestClass]
    public class ContactsControllerPostActionShould
    {
        private MockContactsDbContext _mockDbContext;

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
        public void AddNewContactToTheDbContext()
        {
            var model = new ContactEditModel
            {
                FirstName = "Han",
                LastName = "Solo"
            };
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Post(model).Result;

            _mockDbContext.MockContactsDbSet.Verify(x => x.Add(It.IsAny<Contact>()), Times.Exactly(1));
        }

        [TestMethod]
        public void InvokeSaveChangesOnDbContext()
        {
            var model = new ContactEditModel
            {
                FirstName = "Han",
                LastName = "Solo"
            };
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Post(model).Result;

            _mockDbContext.Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }
    }
}
