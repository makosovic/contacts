using System.Data.Entity;
using Contacts.Web.Entities.Mapping;

namespace Contacts.Web.Entities.Context
{
    public class ContactsDbContext : DbContext, IContactsDbContext
    {
        public ContactsDbContext()
            : base("Name=ContactsDbConnectionString")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContactInfoMap());
            modelBuilder.Configurations.Add(new TagMap());
        }
    }
}
