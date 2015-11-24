namespace Contacts.Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        BirthDate = c.DateTime(),
                        Favorite = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfo", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Tag", "ContactId", "dbo.Contact");
            DropIndex("dbo.Tag", new[] { "ContactId" });
            DropIndex("dbo.ContactInfo", new[] { "ContactId" });
            DropTable("dbo.Tag");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactInfo");
        }
    }
}
