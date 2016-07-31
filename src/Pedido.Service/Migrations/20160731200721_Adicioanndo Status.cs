using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Pedido.Model;

namespace Pedido.Service.Migrations
{
    public partial class AdicioanndoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pedidos",
                nullable: false,
                defaultValue: PedidoStatus.Novo);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pedidos");
        }
    }
}
