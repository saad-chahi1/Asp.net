namespace PROJET_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.activite",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(nullable: false, unicode: false, storeType: "text"),
                        date = c.DateTime(nullable: false, storeType: "date"),
                        description = c.String(nullable: false, unicode: false, storeType: "text"),
                        state = c.String(nullable: false, maxLength: 255, unicode: false),
                        responsable = c.Int(),
                        piece_joint = c.String(nullable: false, maxLength: 255, unicode: false),
                        BDE = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BDE", t => t.BDE)
                .ForeignKey("dbo.Responsable", t => t.responsable)
                .Index(t => t.responsable)
                .Index(t => t.BDE);
            
            CreateTable(
                "dbo.BDE",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 255, unicode: false),
                        prenom = c.String(nullable: false, maxLength: 255, unicode: false),
                        email = c.String(nullable: false, maxLength: 255, unicode: false),
                        password = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.membre_BDE",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 255, unicode: false),
                        prenom = c.String(nullable: false, maxLength: 255, unicode: false),
                        role = c.String(nullable: false, maxLength: 255, unicode: false),
                        picture = c.String(nullable: false, maxLength: 255, unicode: false),
                        bde_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BDE", t => t.bde_id)
                .Index(t => t.bde_id);
            
            CreateTable(
                "dbo.gallerie",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false, storeType: "date"),
                        path = c.String(nullable: false, maxLength: 255, unicode: false),
                        type = c.String(nullable: false, maxLength: 255, unicode: false),
                        id_activite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.activite", t => t.id_activite)
                .Index(t => t.id_activite);
            
            CreateTable(
                "dbo.Responsable",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 255, unicode: false),
                        prenom = c.String(nullable: false, maxLength: 255, unicode: false),
                        email = c.String(nullable: false, maxLength: 255, unicode: false),
                        password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.club",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(nullable: false, unicode: false, storeType: "text"),
                        description = c.String(nullable: false, unicode: false, storeType: "text"),
                        date_creation = c.DateTime(nullable: false, storeType: "date"),
                        logo = c.String(nullable: false, maxLength: 255, unicode: false),
                        id_respo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Responsable", t => t.id_respo)
                .Index(t => t.id_respo);
            
            CreateTable(
                "dbo.admin",
                c => new
                    {
                        id_admin = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 255, unicode: false),
                        mdp = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id_admin);
            
            CreateTable(
                "dbo.association",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.filiere",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 255, unicode: false),
                        departement = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.laureat",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 255, unicode: false),
                        prenom = c.String(nullable: false, maxLength: 255, unicode: false),
                        email = c.String(nullable: false, maxLength: 255, unicode: false),
                        password = c.String(nullable: false, maxLength: 255, unicode: false),
                        societe_actuelle = c.String(nullable: false, maxLength: 255, unicode: false),
                        salaire = c.Single(nullable: false),
                        filiere = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        bio = c.String(nullable: false, unicode: false, storeType: "text"),
                        state = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.filiere", t => t.filiere)
                .Index(t => t.filiere);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.laureat", "filiere", "dbo.filiere");
            DropForeignKey("dbo.club", "id_respo", "dbo.Responsable");
            DropForeignKey("dbo.activite", "responsable", "dbo.Responsable");
            DropForeignKey("dbo.gallerie", "id_activite", "dbo.activite");
            DropForeignKey("dbo.membre_BDE", "bde_id", "dbo.BDE");
            DropForeignKey("dbo.activite", "BDE", "dbo.BDE");
            DropIndex("dbo.laureat", new[] { "filiere" });
            DropIndex("dbo.club", new[] { "id_respo" });
            DropIndex("dbo.gallerie", new[] { "id_activite" });
            DropIndex("dbo.membre_BDE", new[] { "bde_id" });
            DropIndex("dbo.activite", new[] { "BDE" });
            DropIndex("dbo.activite", new[] { "responsable" });
            DropTable("dbo.laureat");
            DropTable("dbo.filiere");
            DropTable("dbo.association");
            DropTable("dbo.admin");
            DropTable("dbo.club");
            DropTable("dbo.Responsable");
            DropTable("dbo.gallerie");
            DropTable("dbo.membre_BDE");
            DropTable("dbo.BDE");
            DropTable("dbo.activite");
        }
    }
}
