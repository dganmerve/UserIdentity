namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class son : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tercihs", newName: "BasvuruModels");
            AddColumn("dbo.BasvuruModels", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasvuruModels", "dateTime");
            RenameTable(name: "dbo.BasvuruModels", newName: "Tercihs");
        }
    }
}
