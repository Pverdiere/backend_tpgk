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
                name: "commande",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    statusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtilisateurUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.id);
                    table.ForeignKey(
                        name: "FK_commande_Utilisateurs_UtilisateurUuid",
                        column: x => x.UtilisateurUuid,
                        principalTable: "Utilisateurs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_commande_status_statusId",
                        column: x => x.statusId,
                        principalTable: "status",
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

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("6b0df725-cfe8-48a5-8db7-a8c063bb6209"), "Assistant" },
                    { new Guid("bb005b53-f0a3-4092-a690-c8a247105358"), "Modérateur" },
                    { new Guid("d898a7dd-291e-4c68-99ec-9c5ea4aaa65d"), "Admin" },
                    { new Guid("ea8795a7-b012-4335-bb75-88ccc5cd7b5e"), "Responsable" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("24136cc1-25af-41e6-a84e-b6f3e8fae7ae"), "Livrée" },
                    { new Guid("8dd0310a-5339-4bc2-899d-693ed14e21dd"), "En Préparation" },
                    { new Guid("df7ffcdd-8345-41d6-b6db-429b722004fa"), "Préparée" },
                    { new Guid("e37d38ce-3d33-4356-a9fd-fe0f2991a72e"), "Expédiée" }
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
                name: "IX_commande_UtilisateurUuid",
                table: "commande",
                column: "UtilisateurUuid");

            migrationBuilder.CreateIndex(
                name: "IX_commandeProduit_commandeId",
                table: "commandeProduit",
                column: "commandeId");

            migrationBuilder.CreateIndex(
                name: "IX_commandeProduit_produitId",
                table: "commandeProduit",
                column: "produitId");

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
                name: "commande");

            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "fabricant");

            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "pays");

            migrationBuilder.DropTable(
                name: "rues");

            migrationBuilder.DropTable(
                name: "villes");
        }
    }
}
