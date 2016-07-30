﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedido.Model.Commands;
using Pedido.Model.Repositories;

namespace Pedido.Model.Services
{
    public class PedidoCadastroService : IPedidoCadastroService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoCadastroService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }        

        public async Task<PedidoCadastro> RegistrarAsync(RegistroPedidoCadastroCommand command)
        {

            var pedido = new PedidoCadastro
            {
                DataAlteracao = DateTime.Now,
                Guid = Guid.NewGuid(),
                IdPessoa = command.IdPessoa
            };

            await pedidoRepository.Insert(pedido);

            return pedido;
        }
    }
}
