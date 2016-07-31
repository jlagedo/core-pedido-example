using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pedido.Infra.Data;

namespace Pedido.Service.Migrations
{
    [DbContext(typeof(PedidoContext))]
    [Migration("20160731193944_Pessoa")]
    partial class Pessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("PessoaId");

                    b.HasKey("PedidoCadastroId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Pedido.Model.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CPF");

                    b.Property<string>("Nome");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Pedido.Model.PedidoCadastro", b =>
                {
                    b.HasOne("Pedido.Model.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });
        }
    }
}
