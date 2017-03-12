namespace Auth.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addErrorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Exception = c.String(nullable: false),
                        ExceptionMessage = c.String(nullable: false),
                        ExceptionStackTrace = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        CreatedUser = c.String(),
                        ExceptionType = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        Descripton = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Errors");
        }
    }
}
