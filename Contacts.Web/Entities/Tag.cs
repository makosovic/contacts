using System;
using System.Collections.Generic;

namespace Contacts.Web.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }

        public Contact Contact { get; set; }
    }
}

