namespace Contacts.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contacts.Web.Entities.Context.ContactsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Entities\Migrations";
        }

        protected override void Seed(Contacts.Web.Entities.Context.ContactsDbContext context)
        {
            context.ContactInfos.AddOrUpdate(
                x => x.Id,
                new ContactInfo { Id = 1, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0137" }
                );

            context.Tags.AddOrUpdate(
                 x => x.Id,
                 new Tag { Id = 1, Name = "Red Five" }
                 );

            context.Contacts.AddOrUpdate(
                 x => x.Id,
                 new Contact { Id = 1, FirstName = "Luke", LastName = "Skywalker", Favorite = true, ContactInfos = context.ContactInfos.Where(x => x.Id == 1).ToArray(), Tags = context.Tags.Where(x => x.Id == 1).ToArray() }
                 );
        }
    }
}
