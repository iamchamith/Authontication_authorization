namespace Auth.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authonthcation", newName: "Authentication");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Authentication", newName: "Authonthcation");
        }
    }
}
