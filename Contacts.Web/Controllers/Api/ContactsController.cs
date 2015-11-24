using System.Collections.Generic;
using System.Web.Http;
using Contacts.Web.Entities;
using Contacts.Web.Models.Contact;

namespace Contacts.Web.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private IContactsDbContext _dbContext;

        public ContactsController(IContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("contacts")]
        [HttpGet]
        public IEnumerable<ContactListModel> Search(string phrase)
        {
            return new[] { new ContactListModel() };
        }

        [Route("contacts")]
        public IEnumerable<ContactListModel> Get(int skip = 0, int top = 10)
        {
            return new [] { new ContactListModel() };
        }

        [Route("contacts/{id}")]
        public ContactListModel Get(int id)
        {
            return new ContactListModel();
        }

        [Route("contacts")]
        public void Post([FromBody]ContactListModel value)
        {
        }

        [Route("contacts/{id}")]
        public void Put(int id, [FromBody]ContactListModel value)
        {
        }

        [Route("contacts/{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("contacts/{id}/contactinfo")]
        public void AddContactInfo([FromBody]ContactListModel value)
        {
        }

        [HttpDelete]
        [Route("contacts/{id}/contactinfo")]
        public void DeleteContactInfo(int id)
        {
        }
    }
}
