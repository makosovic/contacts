﻿
namespace Contacts.Web.Models.Contact
{
    public class ContactListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool Favorite { get; set; }
    }
}

