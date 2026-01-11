namespace UserIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBasvurusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Basvurus",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Adi = c.String(),
                        SoyAdi = c.String(),
                        Cinsiyet = c.Boolean(nullable: false),
                        Email = c.String(),
                        Telefon = c.String(),
                        ProjeAdi = c.String(),
                        ProjeAciklamasi = c.String(),
                        ProjeninNiteligi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Basvurus");
        }
    }
}
