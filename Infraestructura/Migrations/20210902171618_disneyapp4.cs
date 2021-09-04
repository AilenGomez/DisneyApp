using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class disneyapp4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodaje",
                columns: table => new
                {
                    idRodaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "date", nullable: true),
                    calificacion = table.Column<int>(type: "int", nullable: true),
                    idPersonaje = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodaje", x => x.idRodaje);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    idGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    idRodaje = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.idGenero);
                    table.ForeignKey(
                        name: "FK_Genero_Rodaje",
                        column: x => x.idRodaje,
                        principalTable: "Rodaje",
                        principalColumn: "idRodaje",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    idPersonaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: true),
                    peso = table.Column<long>(type: "bigint", nullable: true),
                    historia = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    idRodaje = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.idPersonaje);
                    table.ForeignKey(
                        name: "FK_Personaje_Rodaje",
                        column: x => x.idRodaje,
                        principalTable: "Rodaje",
                        principalColumn: "idRodaje",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genero_idRodaje",
                table: "Genero",
                column: "idRodaje");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_idRodaje",
                table: "Personaje",
                column: "idRodaje");

            migrationBuilder.CreateIndex(
                name: "IX_Rodaje_idPersonaje",
                table: "Rodaje",
                column: "idPersonaje");

            migrationBuilder.AddForeignKey(
                name: "FK_Rodaje_Personaje",
                table: "Rodaje",
                column: "idPersonaje",
                principalTable: "Personaje",
                principalColumn: "idPersonaje",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_Rodaje",
                table: "Personaje");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Rodaje");

            migrationBuilder.DropTable(
                name: "Personaje");
        }
    }
}
