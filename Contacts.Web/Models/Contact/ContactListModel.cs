
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Contacts.Web.Entities;

namespace Contacts.Web.Models.Contact
{
    public class ContactListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public ICollection<string> Tags { get; set; }
        public string TagsConcated => string.Join(", ", Tags);
        public bool Favorite { get; set; }
    }
}

