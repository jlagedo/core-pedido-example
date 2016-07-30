using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pedido.Infra.Data;

namespace Pedido.Service.Migrations
{
    [DbContext(typeof(PedidoContext))]
    partial class PedidoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pedido.Model.PedidoCadastro", b =>
                {
                    b.Property<int>("PedidoCadastroId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<Guid>("Guid");

                    b.Property<int>("IdPessoa");

                    b.HasKey("PedidoCadastroId");

                    b.ToTable("Pedidos");
                });
        }
    }
}
