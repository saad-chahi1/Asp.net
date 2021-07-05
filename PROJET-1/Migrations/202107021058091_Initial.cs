namespace PROJET_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actualite",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(nullable: false, unicode: false, storeType: "text"),
                        date = c.DateTime(nullable: false, storeType: "date"),
                        description = c.String(nullable: false, unicode: false, storeType: "text"),
                        state = c.String(nullable: false, maxLength: 255, unicode: false),
                        piece_joint = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.laureat", "pays", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.laureat", "ville", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.laureat", "ville");
            DropColumn("dbo.laureat", "pays");
            DropTable("dbo.actualite");
        }
    }
}
