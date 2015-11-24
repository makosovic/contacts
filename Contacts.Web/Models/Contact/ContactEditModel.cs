using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contacts.Web.Models.ContactInfo;

namespace Contacts.Web.Models.Contact
{
    public class ContactEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        public bool Favorite { get; set; }

        public ICollection<ContactInfoEditModel> ContactInfos { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}

