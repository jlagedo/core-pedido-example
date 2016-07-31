using Pedido.Infra.Repositories;
using Pedido.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedido.Model;
using Pedido.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Pedido.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext dbContext;

        public PedidoRepository(PedidoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PedidoCadastro> Insert(PedidoCadastro pedidoCadastro)
        {
            dbContext.Pedidos.Add(pedidoCadastro);
            await dbContext.SaveChangesAsync();
            return pedidoCadastro;
        }

        public Task<List<PedidoCadastro>> ListarTopPorData(int top, string nome)
        {
            if (top <= 0)
                throw new ArgumentOutOfRangeException("top");

            var pedidos = dbContext.Pedidos
                            .Include(p => p.Pessoa)
                            .OrderByDescending(p => p.DataAlteracao)
                            .Take(top);

            if (!string.IsNullOrEmpty(nome))
            {
                //TODO: There's a bug on EF core, it's evaluating this on client side
                pedidos = pedidos.Where(p => p.Pessoa.Nome.Contains(nome));
            }

            return pedidos.ToListAsync();
        }

        public Task<PedidoCadastro> Pesquisar(int id)
        {
            return dbContext.Pedidos.FirstOrDefaultAsync(p => p.PedidoCadastroId == id);
        }
    }
}
