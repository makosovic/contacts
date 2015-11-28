using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Contacts.Web.Entities;
using Moq;

namespace Contacts.Web.Tests.Mocks
{
    internal sealed class MockContactsDbContext : Mock<IContactsDbContext>
    {
        private readonly MockDbSet<Contact> _mockContactsDbSet;
        private readonly MockDbSet<ContactInfo> _mockContactInfosDbSet;
        private readonly MockDbSet<Tag> _mockTagsDbSet;

        public MockDbSet<Contact> MockContactsDbSet { get { return _mockContactsDbSet; } }
        public MockDbSet<ContactInfo> MockContactInfosDbSet { get { return _mockContactInfosDbSet; } }
        public MockDbSet<Tag> MockTagsDbSet { get { return _mockTagsDbSet; } }

        public MockContactsDbContext()
        {
            var contactInfos = new List<ContactInfo>
            {
                new ContactInfo
                {
                    Id = 1,
                    Name = "Phone",
                    Type = ContactInfoType.Home,
                    Value = "+1-202-555-0137",
                    ContactId = 1
                },
                new ContactInfo
                {
                    Id = 2,
                    Name = "Email",
                    Type = ContactInfoType.Home,
                    Value = "luke@starwars.com",
                    ContactId = 1
                },
                new ContactInfo
                {
                    Id = 3,
                    Name = "Phone",
                    Type = ContactInfoType.Home,
                    Value = "+1-202-555-0138",
                    ContactId = 2
                },
                new ContactInfo
                {
                    Id = 4,
                    Name = "Email",
                    Type = ContactInfoType.Home,
                    Value = "leia@starwars.com",
                    ContactId = 2
                },
                new ContactInfo
                {
                    Id = 5,
                    Name = "Phone",
                    Type = ContactInfoType.Home,
                    Value = "+1-202-555-0139",
                    ContactId = 3
                },
                new ContactInfo
                {
                    Id = 6,
                    Name = "Email",
                    Type = ContactInfoType.Home,
                    Value = "vader@starwars.com",
                    ContactId = 3
                }
            }.AsQueryable();

            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "Red Five",
                    ContactId = 1
                },
                new Tag
                {
                    Id = 2,
                    Name = "Princess",
                    ContactId = 2
                },
                new Tag
                {
                    Id = 3,
                    Name = "Dark side",
                    ContactId = 3
                }
            }.AsQueryable();

            var contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    FirstName = "Luke",
                    LastName = "Skywalker",
                    Favorite = true,
                    ContactInfos = new List<ContactInfo>(),
                    Tags = new List<Tag>()
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Leia",
                    LastName = "Organa",
                    Favorite = true,
                    ContactInfos = new List<ContactInfo>(),
                    Tags = new List<Tag>()
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Darth",
                    LastName = "Vader",
                    Favorite = false,
                    ContactInfos = new List<ContactInfo>(),
                    Tags = new List<Tag>()
                }
            }.AsQueryable();

            foreach (var contact in contacts)
            {
                foreach (var contactInfo in contactInfos.Where(x => x.ContactId == contact.Id))
                {
                    contact.ContactInfos.Add(contactInfo);
                }

                foreach (var tag in tags.Where(x => x.ContactId == contact.Id))
                {
                    contact.Tags.Add(tag);
                }
            }

            _mockContactsDbSet = new MockDbSet<Contact>(contacts, contacts.Select(x => x.Id));
            _mockContactInfosDbSet = new MockDbSet<ContactInfo>(contactInfos, contactInfos.Select(x => x.Id));
            _mockTagsDbSet = new MockDbSet<Tag>(tags, tags.Select(x => x.Id));

            Setup(x => x.Contacts).Returns(_mockContactsDbSet.Object);
            Setup(x => x.ContactInfos).Returns(_mockContactInfosDbSet.Object);
            Setup(x => x.Tags).Returns(_mockTagsDbSet.Object);
        }
    }
}
