namespace PROJET_1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Activite> activites { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<association> associations { get; set; }
        public virtual DbSet<BDE> BDEs { get; set; }
        public virtual DbSet<club> clubs { get; set; }
        public virtual DbSet<filiere> filieres { get; set; }
        public virtual DbSet<gallerie> galleries { get; set; }
        public virtual DbSet<laureat> laureats { get; set; }
        public virtual DbSet<membre_BDE> membre_BDE { get; set; }
        public virtual DbSet<Responsable> Responsables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activite>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<Activite>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Activite>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Activite>()
                .Property(e => e.piece_joint)
                .IsUnicode(false);

            modelBuilder.Entity<Activite>()
                .HasMany(e => e.galleries)
                .WithRequired(e => e.activite)
                .HasForeignKey(e => e.id_activite)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.mdp)
                .IsUnicode(false);

            modelBuilder.Entity<BDE>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<BDE>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<BDE>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<BDE>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<BDE>()
                .HasMany(e => e.activites)
                .WithOptional(e => e.BDE1)
                .HasForeignKey(e => e.BDE);

            modelBuilder.Entity<BDE>()
                .HasMany(e => e.membre_BDE)
                .WithOptional(e => e.BDE)
                .HasForeignKey(e => e.bde_id);

            modelBuilder.Entity<club>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<club>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<club>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<filiere>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<filiere>()
                .Property(e => e.departement)
                .IsUnicode(false);

            modelBuilder.Entity<filiere>()
                .HasMany(e => e.laureats)
                .WithRequired(e => e.filiere1)
                .HasForeignKey(e => e.filiere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gallerie>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<gallerie>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<laureat>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<laureat>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<laureat>()
                .Property(e => e.email)
                .IsUnicode(false);

         

            modelBuilder.Entity<laureat>()
                .Property(e => e.societe_actuelle)
                .IsUnicode(false);

            modelBuilder.Entity<laureat>()
                .Property(e => e.bio)
                .IsUnicode(false);

            

            modelBuilder.Entity<membre_BDE>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<membre_BDE>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<membre_BDE>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<membre_BDE>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .HasMany(e => e.activites)
                .WithOptional(e => e.Responsable1)
                .HasForeignKey(e => e.responsable);

            modelBuilder.Entity<Responsable>()
                .HasMany(e => e.clubs)
                .WithRequired(e => e.Responsable)
                .HasForeignKey(e => e.id_respo)
                .WillCascadeOnDelete(false);
        }
    }
}
