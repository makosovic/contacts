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
                 new Contact { Id = 1, FirstName = "Luke", LastName = "Skywalker", Favorite = true },
                 new Contact { Id = 2, FirstName = "Leia", LastName = "Organa", Favorite = false },
                 new Contact { Id = 3, FirstName = "Darth", LastName = "Vader", Favorite = true },
                 new Contact { Id = 4, FirstName = "Han", LastName = "Solo", Favorite = true },
                 new Contact { Id = 5, FirstName = "Obi-Wan", LastName = "Kenobi", Favorite = false },
                 new Contact { Id = 6, FirstName = "Yoda", Favorite = false },
                 new Contact { Id = 7, FirstName = "Boba", LastName = "Fett", Favorite = false },
                 new Contact { Id = 8, FirstName = "Darth", LastName = "Sidious", Favorite = false },
                 new Contact { Id = 9, FirstName = "R2-D2", Favorite = false },
                 new Contact { Id = 10, FirstName = "Chewbacca", Favorite = false }
                 );

            context.ContactInfos.AddOrUpdate(
                x => x.Id,
                new ContactInfo { Id = 1, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0137", ContactId = 1 },
                new ContactInfo { Id = 2, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0138", ContactId = 2 },
                new ContactInfo { Id = 3, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0139", ContactId = 3 },
                new ContactInfo { Id = 4, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0140", ContactId = 4 },
                new ContactInfo { Id = 5, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0141", ContactId = 5 },
                new ContactInfo { Id = 6, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0142", ContactId = 6 },
                new ContactInfo { Id = 7, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0143", ContactId = 7 },
                new ContactInfo { Id = 8, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0144", ContactId = 8 },
                new ContactInfo { Id = 9, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0145", ContactId = 9 },
                new ContactInfo { Id = 10, Name = "Phone", Type = ContactInfoType.Home, Value = "+1-202-555-0146", ContactId = 10 },
                new ContactInfo { Id = 11, Name = "Email", Type = ContactInfoType.Home, Value = "luke@starwars.com", ContactId = 1 },
                new ContactInfo { Id = 12, Name = "Email", Type = ContactInfoType.Home, Value = "leia@starwars.com", ContactId = 2 },
                new ContactInfo { Id = 13, Name = "Email", Type = ContactInfoType.Home, Value = "vader@starwars.com", ContactId = 3 },
                new ContactInfo { Id = 14, Name = "Email", Type = ContactInfoType.Home, Value = "han@starwars.com", ContactId = 4 },
                new ContactInfo { Id = 15, Name = "Email", Type = ContactInfoType.Home, Value = "obiwan@starwars.com", ContactId = 5 },
                new ContactInfo { Id = 16, Name = "Email", Type = ContactInfoType.Home, Value = "yoda@starwars.com", ContactId = 6 },
                new ContactInfo { Id = 17, Name = "Email", Type = ContactInfoType.Home, Value = "boba@starwars.com", ContactId = 7 },
                new ContactInfo { Id = 18, Name = "Email", Type = ContactInfoType.Home, Value = "palpatine@starwars.com", ContactId = 8 },
                new ContactInfo { Id = 19, Name = "Email", Type = ContactInfoType.Home, Value = "r2d2@starwars.com", ContactId = 9 },
                new ContactInfo { Id = 20, Name = "Email", Type = ContactInfoType.Home, Value = "chewie@starwars.com", ContactId = 10 }
                );

            context.Tags.AddOrUpdate(
                 x => x.Id,
                 new Tag { Id = 1, Name = "red five", ContactId = 1 },
                 new Tag { Id = 2, Name = "farmboy", ContactId = 1 },
                 new Tag { Id = 3, Name = "jedi", ContactId = 1 },
                 new Tag { Id = 4, Name = "princess", ContactId = 2 },
                 new Tag { Id = 5, Name = "rebel", ContactId = 2 },
                 new Tag { Id = 6, Name = "sith lord", ContactId = 3 },
                 new Tag { Id = 7, Name = "dark side", ContactId = 3 },
                 new Tag { Id = 8, Name = "smuggler", ContactId = 4 },
                 new Tag { Id = 9, Name = "captain", ContactId = 4 },
                 new Tag { Id = 10, Name = "mentor", ContactId = 5 },
                 new Tag { Id = 11, Name = "jedi", ContactId = 5 },
                 new Tag { Id = 12, Name = "legendary", ContactId = 6 },
                 new Tag { Id = 13, Name = "jedi", ContactId = 6 },
                 new Tag { Id = 14, Name = "bounty hunter", ContactId = 7 },
                 new Tag { Id = 15, Name = "emperor", ContactId = 8 },
                 new Tag { Id = 16, Name = "palpatine", ContactId = 8 },
                 new Tag { Id = 17, Name = "supreme chancellor", ContactId = 8 },
                 new Tag { Id = 18, Name = "droid", ContactId = 9 },
                 new Tag { Id = 19, Name = "wookiee", ContactId = 10 }
                 );
    }
    }

}
