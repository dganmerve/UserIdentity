namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId_eklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Basvurus", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Basvurus", "UserId");
        }
    }
}
