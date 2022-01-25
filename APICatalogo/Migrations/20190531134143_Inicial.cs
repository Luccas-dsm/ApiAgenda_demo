using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Endereco = table.Column<string>(maxLength: 300, nullable: false),
                    Telefone = table.Column<string>(maxLength: 14, nullable: false)
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoId);
                   
                });

           /* migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");
           
        }
    }
}
