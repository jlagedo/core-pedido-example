using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pedido.Service.Migrations
{
    public partial class Pessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Pedidos");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                });

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PessoaId",
                table: "Pedidos",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Pessoa_PessoaId",
                table: "Pedidos",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Pessoa_PessoaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PessoaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.AddColumn<int>(
                name: "IdPessoa",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
