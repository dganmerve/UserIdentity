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
                        Id = c.Int(nullable: false, identity: true),
                        Isim = c.String(),
                        SoyIsim = c.String(),
                        Mail = c.String(),
                        Telefon = c.String(),
                        Adres = c.String(),
                        ProjeAdi = c.String(),
                        Aciklama = c.String(),
                        SehirSec = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Basvurus");
        }
    }
}
