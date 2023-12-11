using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class KaycerKhouiniDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    NumMat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.NumMat);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TauxBenifice = table.Column<float>(type: "real", nullable: false),
                    VoitureNumMat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Voitures_VoitureNumMat",
                        column: x => x.VoitureNumMat,
                        principalTable: "Voitures",
                        principalColumn: "NumMat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ChauffeurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.CIN);
                    table.ForeignKey(
                        name: "FK_Clients_Chauffeurs_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    DateCourse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoitreFk = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientFk = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LieuDepart = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LieuArrive = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    PaiementEnligne = table.Column<bool>(type: "bit", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => new { x.VoitreFk, x.ClientFk, x.DateCourse });
                    table.ForeignKey(
                        name: "FK_Courses_Clients_ClientFk",
                        column: x => x.ClientFk,
                        principalTable: "Clients",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Voitures_VoitreFk",
                        column: x => x.VoitreFk,
                        principalTable: "Voitures",
                        principalColumn: "NumMat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_VoitureNumMat",
                table: "Chauffeurs",
                column: "VoitureNumMat");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ChauffeurId",
                table: "Clients",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClientFk",
                table: "Courses",
                column: "ClientFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}
