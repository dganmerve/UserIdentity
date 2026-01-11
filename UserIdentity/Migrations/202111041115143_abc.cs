namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Basvurus");
            AddColumn("dbo.Basvurus", "Adres", c => c.String());
            AlterColumn("dbo.Basvurus", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Basvurus", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Basvurus");
            AlterColumn("dbo.Basvurus", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Basvurus", "Adres");
            AddPrimaryKey("dbo.Basvurus", "Id");
        }
    }
}
