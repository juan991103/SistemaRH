using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SistemaRH.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gestion_capacitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nivel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Fecha_Desde = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_Hasta = table.Column<DateTime>(type: "datetime", nullable: false),
                    Institucion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gestion_capacitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gestion_competencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gestion_competencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gestion_idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gestion_idiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gestion_puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nivel_Riesgo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Minimo_Salario = table.Column<double>(type: "double", nullable: false),
                    Maximo_Salario = table.Column<double>(type: "double", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gestion_puestos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gestion_capacitacion");

            migrationBuilder.DropTable(
                name: "gestion_competencia");

            migrationBuilder.DropTable(
                name: "gestion_idiomas");

            migrationBuilder.DropTable(
                name: "gestion_puestos");
        }
    }
}
