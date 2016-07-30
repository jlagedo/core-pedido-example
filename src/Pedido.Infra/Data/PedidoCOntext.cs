using Microsoft.EntityFrameworkCore;
using Pedido.Model;

namespace Pedido.Infra.Data
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options) : base (options)
        {

        }
        public DbSet<PedidoCadastro> Pedidos { get; set; }
    }
}
