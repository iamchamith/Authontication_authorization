namespace Auth.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorTables1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authentication", newName: "Authentications");
            RenameTable(name: "dbo.Authorization", newName: "Authorizations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Authorizations", newName: "Authorization");
            RenameTable(name: "dbo.Authentications", newName: "Authentication");
        }
    }
}
