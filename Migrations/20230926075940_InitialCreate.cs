using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_tpgk.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fabricant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fabricant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pays",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pays", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rues",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "villes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codePostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false),
                    promotion = table.Column<float>(type: "real", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    enable = table.Column<bool>(type: "bit", nullable: false),
                    hauteur = table.Column<float>(type: "real", nullable: false),
                    largeur = table.Column<float>(type: "real", nullable: false),
                    longueur = table.Column<float>(type: "real", nullable: false),
                    poids = table.Column<float>(type: "real", nullable: false),
                    capacite = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    couleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fabricantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.id);
                    table.ForeignKey(
                        name: "FK_produit_fabricant_fabricantId",
                        column: x => x.fabricantId,
                        principalTable: "fabricant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    statusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.id);
                    table.ForeignKey(
                        name: "FK_commande_status_statusId",
                        column: x => x.statusId,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    villeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    paysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresse", x => x.id);
                    table.ForeignKey(
                        name: "FK_adresse_pays_paysId",
                        column: x => x.paysId,
                        principalTable: "pays",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_adresse_rues_rueId",
                        column: x => x.rueId,
                        principalTable: "rues",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_adresse_villes_villeId",
                        column: x => x.villeId,
                        principalTable: "villes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "commandeProduit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    commandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    produitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    promotion = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandeProduit", x => x.id);
                    table.ForeignKey(
                        name: "FK_commandeProduit_commande_commandeId",
                        column: x => x.commandeId,
                        principalTable: "commande",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_commandeProduit_produit_produitId",
                        column: x => x.produitId,
                        principalTable: "produit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    enable = table.Column<bool>(type: "bit", nullable: false),
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    adresseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_adresse_adresseId",
                        column: x => x.adresseId,
                        principalTable: "adresse",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Utilisateurs_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "avis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validation = table.Column<bool>(type: "bit", nullable: true),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProduitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avis", x => x.id);
                    table.ForeignKey(
                        name: "FK_avis_Utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_avis_produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CommandeUtilisateur",
                columns: table => new
                {
                    CommandesUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtilisateursUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeUtilisateur", x => new { x.CommandesUuid, x.UtilisateursUuid });
                    table.ForeignKey(
                        name: "FK_CommandeUtilisateur_Utilisateurs_UtilisateursUuid",
                        column: x => x.UtilisateursUuid,
                        principalTable: "Utilisateurs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CommandeUtilisateur_commande_CommandesUuid",
                        column: x => x.CommandesUuid,
                        principalTable: "commande",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("5a82f657-9ece-4e06-8e7c-51e598554ddf"), "Assistant" },
                    { new Guid("aa6d0382-adae-465a-89ba-c9945def9226"), "Admin" },
                    { new Guid("dcf7380b-c21b-47b2-acfe-1999b16ca553"), "Responsable" },
                    { new Guid("f207b07e-cac0-43e4-8e59-672c97b209b4"), "Modérateur" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0b7a6853-6078-4665-aa9d-c4f1be736ec4"), "En Préparation" },
                    { new Guid("7d700299-5739-4da3-9581-d8b37e2201e4"), "Livrée" },
                    { new Guid("8594381d-b3d9-4bd4-9016-4e568c06ea85"), "Expédiée" },
                    { new Guid("b56c5c65-54f8-4ca2-bbaf-969700a8c960"), "Préparée" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresse_paysId",
                table: "adresse",
                column: "paysId");

            migrationBuilder.CreateIndex(
                name: "IX_adresse_rueId",
                table: "adresse",
                column: "rueId");

            migrationBuilder.CreateIndex(
                name: "IX_adresse_villeId",
                table: "adresse",
                column: "villeId");

            migrationBuilder.CreateIndex(
                name: "IX_avis_ProduitId",
                table: "avis",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_avis_utilisateurId",
                table: "avis",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_commande_statusId",
                table: "commande",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_commandeProduit_commandeId",
                table: "commandeProduit",
                column: "commandeId");

            migrationBuilder.CreateIndex(
                name: "IX_commandeProduit_produitId",
                table: "commandeProduit",
                column: "produitId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeUtilisateur_UtilisateursUuid",
                table: "CommandeUtilisateur",
                column: "UtilisateursUuid");

            migrationBuilder.CreateIndex(
                name: "IX_fabricant_name",
                table: "fabricant",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pays_name",
                table: "pays",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produit_code",
                table: "produit",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produit_fabricantId",
                table: "produit",
                column: "fabricantId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rues_name",
                table: "rues",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_status_name",
                table: "status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_adresseId",
                table: "Utilisateurs",
                column: "adresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_email",
                table: "Utilisateurs",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_roleId",
                table: "Utilisateurs",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avis");

            migrationBuilder.DropTable(
                name: "commandeProduit");

            migrationBuilder.DropTable(
                name: "CommandeUtilisateur");

            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "commande");

            migrationBuilder.DropTable(
                name: "fabricant");

            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "pays");

            migrationBuilder.DropTable(
                name: "rues");

            migrationBuilder.DropTable(
                name: "villes");
        }
    }
}
