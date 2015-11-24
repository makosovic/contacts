using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Contacts.Web.Entities;
using Contacts.Web.Models.Contact;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Contacts.Web.Models;

namespace Contacts.Web.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private readonly IContactsDbContext _dbContext;

        public ContactsController(IContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("contacts")]
        [HttpGet]
        public async Task<IEnumerable<ContactListModel>> Search(string phrase)
        {
            return await _dbContext.Contacts
                .Include(x => x.Tags)
                .Where(x => x.FirstName.Contains(phrase) || x.LastName.Contains(phrase) || x.Tags.Any(y => y.Name.Contains(phrase)))
                .Take(5)
                .ProjectTo<ContactListModel>()
                .ToListAsync();
        }

        [Route("contacts")]
        public async Task<IEnumerable<ContactListModel>> Get(int skip = 0, int top = 10)
        {
            return await _dbContext.Contacts
                .Skip(skip)
                .Take(top)
                .ProjectTo<ContactListModel>()
                .ToListAsync();
        }

        [Route("contacts/{id}")]
        public async Task<ContactListModel> Get(int id)
        {
            var contact = await _dbContext.Contacts
                .FindAsync(id);
            return Mapper.Map<ContactListModel>(contact);
        }

        [Route("contacts")]
        public async Task<IHttpActionResult> Post([FromBody]ContactEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ContactFactory factory = new ContactFactory();
            Contact contact = factory.Create(model);

            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, Mapper.Map<ContactEditModel>(contact));

        }

        [Route("contacts/{id}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]ContactEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            Contact contact = await _dbContext.Contacts.FindAsync(model.Id);

            if (contact == null)
            {
                return NotFound();
            }

            ContactFactory factory = new ContactFactory();
            contact = factory.Update(model, contact);

            _dbContext.Entry(contact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("contacts/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Contact contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(Mapper.Map<ContactListModel>(contact));
        }
    }
}
