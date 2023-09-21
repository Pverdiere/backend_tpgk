using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using backend_tpgk.Models;
using Isopoh.Cryptography.Argon2;

namespace backend_tpgk.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Adresse> Adresse => Set<Adresse>();
        public DbSet<Avis> Avis => Set<Avis>();
        public DbSet<Commande> Commande => Set<Commande>();
        public DbSet<CommandeProduit> CommandeProduit => Set<CommandeProduit>();
        public DbSet<Fabricant> Fabricants => Set<Fabricant>();
        public DbSet<Pays> Pays => Set<Pays>();
        public DbSet<Produit> Produits => Set<Produit>();
        public DbSet<Role> Role => Set<Role>();
        public DbSet<Rue> Rue => Set<Rue>();
        public DbSet<Status> Status => Set<Status>();
        public DbSet<Utilisateur> Utilisateur => Set<Utilisateur>();
        public DbSet<Ville> Ville => Set<Ville>();

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            Status enPreparation = new() {Uuid = Guid.NewGuid(), Name = "En Préparation", Commandes = new Collection<Commande>()};
            Status preparee = new() {Uuid = Guid.NewGuid(), Name = "Préparée", Commandes = new Collection<Commande>()};
            Status expediee = new() {Uuid = Guid.NewGuid(), Name = "Expédiée", Commandes = new Collection<Commande>()};
            Status livree = new() {Uuid = Guid.NewGuid(), Name = "Livrée", Commandes = new Collection<Commande>()};

            Fabricant fabricant = new() {Uuid = Guid.NewGuid(), Name = "Roger", Produit = new Collection<Produit>()};

            modelBuilder.Entity<Role>().HasData(
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Admin"
                },
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Responsable"
                },
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Assistant"
                },
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Modérateur"
                }
            );

            modelBuilder.Entity<Status>().HasData(
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "En Préparation"
                },
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Préparée"
                },
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Expédiée"
                },
                new{
                    Uuid = Guid.NewGuid(),
                    Name = "Livrée"
                }
            );
        }
    }
}