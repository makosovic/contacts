using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Contacts.Web.Entities.Context
{
    public class ContactsDbInitializer : CreateDatabaseIfNotExists<ContactsDbContext>
    {
        protected override void Seed(ContactsDbContext context)
        {
            context.Contacts.AddOrUpdate(
                 x => x.Id,
                 new Contact { Id = 1, FirstName = "Luke", LastName = "Skywalker", Favorite = true }
                 );

            context.ContactInfos.AddOrUpdate(
                x => x.Id,
                new ContactInfo { Id = 1, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0137", ContactId = 1 }
                );

            context.Tags.AddOrUpdate(
                 x => x.Id,
                 new Tag { Id = 1, Name = "Red Five", ContactId = 1 }
                 );
    }
    }

}
