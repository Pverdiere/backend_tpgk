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
                    FabricantUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.id);
                    table.ForeignKey(
                        name: "FK_produit_fabricant_FabricantUuid",
                        column: x => x.FabricantUuid,
                        principalTable: "fabricant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "villes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaysUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villes", x => x.id);
                    table.ForeignKey(
                        name: "FK_villes_pays_PaysUuid",
                        column: x => x.PaysUuid,
                        principalTable: "pays",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.id);
                    table.ForeignKey(
                        name: "FK_commande_status_StatusUuid",
                        column: x => x.StatusUuid,
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
                    RueUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VilleUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaysUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresse", x => x.id);
                    table.ForeignKey(
                        name: "FK_adresse_pays_PaysUuid",
                        column: x => x.PaysUuid,
                        principalTable: "pays",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_adresse_rues_RueUuid",
                        column: x => x.RueUuid,
                        principalTable: "rues",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_adresse_villes_VilleUuid",
                        column: x => x.VilleUuid,
                        principalTable: "villes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "RueVille",
                columns: table => new
                {
                    RuesUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillesUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RueVille", x => new { x.RuesUuid, x.VillesUuid });
                    table.ForeignKey(
                        name: "FK_RueVille_rues_RuesUuid",
                        column: x => x.RuesUuid,
                        principalTable: "rues",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RueVille_villes_VillesUuid",
                        column: x => x.VillesUuid,
                        principalTable: "villes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "commandeProduit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommandeUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProduitUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    promotion = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandeProduit", x => x.id);
                    table.ForeignKey(
                        name: "FK_commandeProduit_commande_CommandeUuid",
                        column: x => x.CommandeUuid,
                        principalTable: "commande",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_commandeProduit_produit_ProduitUuid",
                        column: x => x.ProduitUuid,
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
                    RoleUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresseUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VilleUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_adresse_AdresseUuid",
                        column: x => x.AdresseUuid,
                        principalTable: "adresse",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Utilisateurs_roles_RoleUuid",
                        column: x => x.RoleUuid,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Utilisateurs_villes_VilleUuid",
                        column: x => x.VilleUuid,
                        principalTable: "villes",
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
                    UtilisateurUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProduitUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avis", x => x.id);
                    table.ForeignKey(
                        name: "FK_avis_Utilisateurs_UtilisateurUuid",
                        column: x => x.UtilisateurUuid,
                        principalTable: "Utilisateurs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_avis_produit_ProduitUuid",
                        column: x => x.ProduitUuid,
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
                    { new Guid("44c58005-9cfa-450c-93ba-72a528dd006f"), "Assistant" },
                    { new Guid("4cdaac44-07f2-4232-acdd-7203926856ca"), "Modérateur" },
                    { new Guid("7c22c36c-3438-49a2-85f2-c834c5dd8882"), "Admin" },
                    { new Guid("9bcadcb3-a539-4522-a86d-2460def47c30"), "Responsable" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("163460ef-5982-49a8-a803-0ef38cdf1b24"), "Expédiée" },
                    { new Guid("60c026c3-cf81-453a-a195-c01f853531a0"), "Livrée" },
                    { new Guid("7c345959-e697-4e0b-b750-c1237ae23ee0"), "Préparée" },
                    { new Guid("f98f64bf-db7a-4139-94fb-d64777f1d458"), "En Préparation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresse_PaysUuid",
                table: "adresse",
                column: "PaysUuid");

            migrationBuilder.CreateIndex(
                name: "IX_adresse_RueUuid",
                table: "adresse",
                column: "RueUuid");

            migrationBuilder.CreateIndex(
                name: "IX_adresse_VilleUuid",
                table: "adresse",
                column: "VilleUuid");

            migrationBuilder.CreateIndex(
                name: "IX_avis_ProduitUuid",
                table: "avis",
                column: "ProduitUuid");

            migrationBuilder.CreateIndex(
                name: "IX_avis_UtilisateurUuid",
                table: "avis",
                column: "UtilisateurUuid");

            migrationBuilder.CreateIndex(
                name: "IX_commande_StatusUuid",
                table: "commande",
                column: "StatusUuid");

            migrationBuilder.CreateIndex(
                name: "IX_commandeProduit_CommandeUuid",
                table: "commandeProduit",
                column: "CommandeUuid");

            migrationBuilder.CreateIndex(
                name: "IX_commandeProduit_ProduitUuid",
                table: "commandeProduit",
                column: "ProduitUuid");

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
                name: "IX_produit_FabricantUuid",
                table: "produit",
                column: "FabricantUuid");

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
                name: "IX_RueVille_VillesUuid",
                table: "RueVille",
                column: "VillesUuid");

            migrationBuilder.CreateIndex(
                name: "IX_status_name",
                table: "status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_AdresseUuid",
                table: "Utilisateurs",
                column: "AdresseUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_email",
                table: "Utilisateurs",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_RoleUuid",
                table: "Utilisateurs",
                column: "RoleUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_VilleUuid",
                table: "Utilisateurs",
                column: "VilleUuid");

            migrationBuilder.CreateIndex(
                name: "IX_villes_PaysUuid",
                table: "villes",
                column: "PaysUuid");
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
                name: "RueVille");

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
                name: "rues");

            migrationBuilder.DropTable(
                name: "villes");

            migrationBuilder.DropTable(
                name: "pays");
        }
    }
}
