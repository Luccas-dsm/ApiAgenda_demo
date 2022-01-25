using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into contatos(Nome, Endereco, Telefone) Values('Luiza','Rua Berlim', '3199999-9999')");
         
        }

        protected override void Down(MigrationBuilder mb)
        {
           
            mb.Sql("Delete from contatos");
        }
    }
}
