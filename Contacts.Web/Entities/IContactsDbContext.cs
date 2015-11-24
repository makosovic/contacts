using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.Web.Entities
{
    public interface IContactsDbContext : IDisposable
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactInfo> ContactInfos { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbEntityEntry Entry(object entity);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
