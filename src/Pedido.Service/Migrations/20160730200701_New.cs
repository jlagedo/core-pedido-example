using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pedido.Service.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoCadastroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Guid = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoCadastroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
