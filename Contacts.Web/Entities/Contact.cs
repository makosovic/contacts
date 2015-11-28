using System;
using System.Collections.Generic;

namespace Contacts.Web.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Favorite { get; set; }

        public ICollection<ContactInfo> ContactInfos { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}

