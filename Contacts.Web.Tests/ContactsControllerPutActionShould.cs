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
    public class ContactsControllerPutActionShould
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
        public void ReturnBadRequestIfIdInParameterAndModelDoNotMatch()
        {
            var model = new ContactEditModel
            {
                Id = 3,
                FirstName = "Darth",
                LastName = "Kitty"
            };
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Put(0, model).Result;

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void ReturnNotFoundIfIdDoesntExist()
        {
            var model = new ContactEditModel
            {
                Id = 4,
                FirstName = "Han",
                LastName = "Solo"
            };
            var contactsController = new ContactsController(_mockDbContext.Object);

            var result = contactsController.Put(model.Id, model).Result;

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
