using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Alura.Infrastructure.Migrations
{
    public partial class AtualizandoTabelaDeDestinos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Destinos",
                newName: "Foto2");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto1",
                table: "Destinos",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destinos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TextoDescritivo",
                table: "Destinos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto1",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "TextoDescritivo",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "Foto2",
                table: "Destinos",
                newName: "Foto");
        }
    }
}
