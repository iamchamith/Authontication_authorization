namespace Auth.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authonthcation",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        IsValiedEmail = c.Boolean(nullable: false),
                        Roles = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Authorization",
                c => new
                    {
                        Roles = c.Int(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => new { t.Roles, t.Tag });
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authonthcation", new[] { "Email" });
            DropTable("dbo.Authorization");
            DropTable("dbo.Authonthcation");
        }
    }
}
