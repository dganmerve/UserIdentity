namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTercihsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Basvurus", newName: "Tercihs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tercihs", newName: "Basvurus");
        }
    }
}
