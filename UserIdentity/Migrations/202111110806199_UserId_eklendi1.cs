namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId_eklendi1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tercihs", "UserId", c => c.String());
            DropColumn("dbo.Basvurus", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Basvurus", "UserId", c => c.String());
            DropColumn("dbo.Tercihs", "UserId");
        }
    }
}
