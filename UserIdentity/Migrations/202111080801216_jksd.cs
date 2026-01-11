namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jksd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tercihs", "Onay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tercihs", "Onay");
        }
    }
}
