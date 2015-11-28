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
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [MaxLength(256)]
        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        public bool Favorite { get; set; }

        public ICollection<ContactInfoEditModel> ContactInfos { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}

