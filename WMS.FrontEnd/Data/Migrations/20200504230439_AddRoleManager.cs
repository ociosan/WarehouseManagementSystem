using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.FrontEnd.Data.Migrations
{
    public partial class AddRoleManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcecionariaVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    RFC = table.Column<string>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcecionariaVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionGlobalVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Valor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionGlobalVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoVM", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcecionariaVM");

            migrationBuilder.DropTable(
                name: "ConfiguracionGlobalVM");

            migrationBuilder.DropTable(
                name: "ProductoVM");
        }
    }
}
