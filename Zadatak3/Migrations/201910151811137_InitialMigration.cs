namespace Zadatak3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ucenici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 50),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Prosjek = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ucenici");
        }
    }
}
