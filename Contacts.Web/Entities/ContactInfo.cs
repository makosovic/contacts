namespace Contacts.Web.Entities
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public ContactInfoType Type { get; set; }
        public string Value { get; set; }

        public Contact Contact { get; set; }
    }
}

