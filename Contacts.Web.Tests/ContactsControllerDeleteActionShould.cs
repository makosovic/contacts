using System.Web.Http.Results;
using Contacts.Web.Controllers.Api;
using Contacts.Web.Entities;
using Contacts.Web.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Contacts.Web.Tests
{
    [TestClass]
    public class ContactsControllerDeleteActionShould
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
        public void ReturnNotFoundIfIdDoesntExist()
        {
            var id = 4;
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Delete(id).Result;

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void RemoveNewContactFromTheDbContext()
        {
            var id = 3;
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Delete(id).Result;

            _mockDbContext.MockContactsDbSet.Verify(x => x.Remove(It.IsAny<Contact>()), Times.Exactly(1));
        }

        [TestMethod]
        public void InvokeSaveChangesOnDbContext()
        {
            var id = 3;
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Delete(id).Result;

            _mockDbContext.Verify(x => x.SaveChangesAsync(), Times.Exactly(1));
        }
    }
}
