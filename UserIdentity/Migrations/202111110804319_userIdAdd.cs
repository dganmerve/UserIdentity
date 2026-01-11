namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIdAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasvuruModels", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasvuruModels", "UserId");
        }
    }
}
