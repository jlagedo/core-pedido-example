﻿using Pedido.Infra.Repositories;
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

        public Task<PedidoCadastro> Pesquisar(int id)
        {
            return dbContext.Pedidos.FirstOrDefaultAsync(p => p.PedidoCadastroId == id);
        }
    }
}
