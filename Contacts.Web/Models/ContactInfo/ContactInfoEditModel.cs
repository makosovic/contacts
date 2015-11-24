using System.ComponentModel.DataAnnotations;

namespace Contacts.Web.Models.ContactInfo
{
    public class ContactInfoEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Value { get; set; }

        public bool IsNew => Id == 0;
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}

