namespace Contacts.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "Address", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "Address");
        }
    }
}
