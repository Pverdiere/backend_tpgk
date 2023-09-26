﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_tpgk.Data;

#nullable disable

namespace backend_tpgk.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommandeUtilisateur", b =>
                {
                    b.Property<Guid>("CommandesUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UtilisateursUuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommandesUuid", "UtilisateursUuid");

                    b.HasIndex("UtilisateursUuid");

                    b.ToTable("CommandeUtilisateur");
                });

            modelBuilder.Entity("backend_tpgk.Models.Adresse", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("complement");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("number");

                    b.Property<Guid>("PaysId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("paysId");

                    b.Property<Guid>("RueUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rueId");

                    b.Property<Guid>("VilleUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("villeId");

                    b.HasKey("Uuid");

                    b.HasIndex("PaysId");

                    b.HasIndex("RueUuid");

                    b.HasIndex("VilleUuid");

                    b.ToTable("adresse");
                });

            modelBuilder.Entity("backend_tpgk.Models.Avis", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("ProduitUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProduitId");

                    b.Property<Guid>("UtilisateurUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("utilisateurId");

                    b.Property<bool?>("Validation")
                        .HasColumnType("bit")
                        .HasColumnName("validation");

                    b.HasKey("Uuid");

                    b.HasIndex("ProduitUuid");

                    b.HasIndex("UtilisateurUuid");

                    b.ToTable("avis");
                });

            modelBuilder.Entity("backend_tpgk.Models.Commande", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("StatusUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("statusId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedAt");

                    b.HasKey("Uuid");

                    b.HasIndex("StatusUuid");

                    b.ToTable("commande");
                });

            modelBuilder.Entity("backend_tpgk.Models.CommandeProduit", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("CommandeUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("commandeId");

                    b.Property<float>("Prix")
                        .HasColumnType("real")
                        .HasColumnName("prix");

                    b.Property<Guid>("ProduitUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("produitId");

                    b.Property<float?>("Promotion")
                        .HasColumnType("real")
                        .HasColumnName("promotion");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Uuid");

                    b.HasIndex("CommandeUuid");

                    b.HasIndex("ProduitUuid");

                    b.ToTable("commandeProduit");
                });

            modelBuilder.Entity("backend_tpgk.Models.Fabricant", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Uuid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("fabricant");
                });

            modelBuilder.Entity("backend_tpgk.Models.Pays", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Uuid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("pays");
                });

            modelBuilder.Entity("backend_tpgk.Models.Produit", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<float>("Capacite")
                        .HasColumnType("real")
                        .HasColumnName("capacite");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("code");

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("couleur");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit")
                        .HasColumnName("enable");

                    b.Property<Guid>("FabricantUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("fabricantId");

                    b.Property<float>("Hauteur")
                        .HasColumnType("real")
                        .HasColumnName("hauteur");

                    b.Property<float>("Largeur")
                        .HasColumnType("real")
                        .HasColumnName("largeur");

                    b.Property<float>("Longueur")
                        .HasColumnType("real")
                        .HasColumnName("longueur");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<float>("Poids")
                        .HasColumnType("real")
                        .HasColumnName("poids");

                    b.Property<float>("Prix")
                        .HasColumnType("real")
                        .HasColumnName("prix");

                    b.Property<float?>("Promotion")
                        .HasColumnType("real")
                        .HasColumnName("promotion");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedAt");

                    b.Property<string>("UrlImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("urlImg");

                    b.HasKey("Uuid");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("FabricantUuid");

                    b.ToTable("produit");
                });

            modelBuilder.Entity("backend_tpgk.Models.Role", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Uuid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Uuid = new Guid("aa6d0382-adae-465a-89ba-c9945def9226"),
                            Name = "Admin"
                        },
                        new
                        {
                            Uuid = new Guid("dcf7380b-c21b-47b2-acfe-1999b16ca553"),
                            Name = "Responsable"
                        },
                        new
                        {
                            Uuid = new Guid("5a82f657-9ece-4e06-8e7c-51e598554ddf"),
                            Name = "Assistant"
                        },
                        new
                        {
                            Uuid = new Guid("f207b07e-cac0-43e4-8e59-672c97b209b4"),
                            Name = "Modérateur"
                        });
                });

            modelBuilder.Entity("backend_tpgk.Models.Rue", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Uuid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("rues");
                });

            modelBuilder.Entity("backend_tpgk.Models.Status", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Uuid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("status");

                    b.HasData(
                        new
                        {
                            Uuid = new Guid("0b7a6853-6078-4665-aa9d-c4f1be736ec4"),
                            Name = "En Préparation"
                        },
                        new
                        {
                            Uuid = new Guid("b56c5c65-54f8-4ca2-bbaf-969700a8c960"),
                            Name = "Préparée"
                        },
                        new
                        {
                            Uuid = new Guid("8594381d-b3d9-4bd4-9016-4e568c06ea85"),
                            Name = "Expédiée"
                        },
                        new
                        {
                            Uuid = new Guid("7d700299-5739-4da3-9581-d8b37e2201e4"),
                            Name = "Livrée"
                        });
                });

            modelBuilder.Entity("backend_tpgk.Models.Utilisateur", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid?>("AdresseUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("adresseId");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit")
                        .HasColumnName("enable");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<Guid>("RoleUuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("roleId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedAt");

                    b.HasKey("Uuid");

                    b.HasIndex("AdresseUuid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleUuid");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("backend_tpgk.Models.Ville", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("codePostal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Uuid");

                    b.ToTable("villes");
                });

            modelBuilder.Entity("CommandeUtilisateur", b =>
                {
                    b.HasOne("backend_tpgk.Models.Commande", null)
                        .WithMany()
                        .HasForeignKey("CommandesUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend_tpgk.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UtilisateursUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("backend_tpgk.Models.Adresse", b =>
                {
                    b.HasOne("backend_tpgk.Models.Pays", "Pays")
                        .WithMany("Adresses")
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend_tpgk.Models.Rue", "Rue")
                        .WithMany("Adresses")
                        .HasForeignKey("RueUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend_tpgk.Models.Ville", "Ville")
                        .WithMany("Adresse")
                        .HasForeignKey("VilleUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pays");

                    b.Navigation("Rue");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("backend_tpgk.Models.Avis", b =>
                {
                    b.HasOne("backend_tpgk.Models.Produit", "Produit")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("ProduitUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend_tpgk.Models.Utilisateur", "Utilisateur")
                        .WithMany("Avis")
                        .HasForeignKey("UtilisateurUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produit");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("backend_tpgk.Models.Commande", b =>
                {
                    b.HasOne("backend_tpgk.Models.Status", "Status")
                        .WithMany("Commandes")
                        .HasForeignKey("StatusUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("backend_tpgk.Models.CommandeProduit", b =>
                {
                    b.HasOne("backend_tpgk.Models.Commande", "Commande")
                        .WithMany("CommandeProduits")
                        .HasForeignKey("CommandeUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend_tpgk.Models.Produit", "Produit")
                        .WithMany("CommandeProduit")
                        .HasForeignKey("ProduitUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Commande");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("backend_tpgk.Models.Produit", b =>
                {
                    b.HasOne("backend_tpgk.Models.Fabricant", "Fabricant")
                        .WithMany("Produit")
                        .HasForeignKey("FabricantUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Fabricant");
                });

            modelBuilder.Entity("backend_tpgk.Models.Utilisateur", b =>
                {
                    b.HasOne("backend_tpgk.Models.Adresse", "Adresse")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("AdresseUuid")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("backend_tpgk.Models.Role", "Role")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("RoleUuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adresse");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("backend_tpgk.Models.Adresse", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("backend_tpgk.Models.Commande", b =>
                {
                    b.Navigation("CommandeProduits");
                });

            modelBuilder.Entity("backend_tpgk.Models.Fabricant", b =>
                {
                    b.Navigation("Produit");
                });

            modelBuilder.Entity("backend_tpgk.Models.Pays", b =>
                {
                    b.Navigation("Adresses");
                });

            modelBuilder.Entity("backend_tpgk.Models.Produit", b =>
                {
                    b.Navigation("CommandeProduit");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("backend_tpgk.Models.Role", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("backend_tpgk.Models.Rue", b =>
                {
                    b.Navigation("Adresses");
                });

            modelBuilder.Entity("backend_tpgk.Models.Status", b =>
                {
                    b.Navigation("Commandes");
                });

            modelBuilder.Entity("backend_tpgk.Models.Utilisateur", b =>
                {
                    b.Navigation("Avis");
                });

            modelBuilder.Entity("backend_tpgk.Models.Ville", b =>
                {
                    b.Navigation("Adresse");
                });
#pragma warning restore 612, 618
        }
    }
}
