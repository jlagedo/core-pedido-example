using Microsoft.AspNetCore.Mvc;
using Pedido.Web.Services;
using Pedido.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pedido.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoServiceClient pedidoService;

        public PedidoController(IPedidoServiceClient pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var dto = await pedidoService.PesquisaPorIdAsync(id);

            PedidoCadastroViewModel pedidoCadastro = new PedidoCadastroViewModel
            {
                DataAlteracao = dto.DataAlteracao,
                Guid = dto.Guid,
                IdPessoa = dto.IdPessoa,
                PedidoCadastroId = dto.PedidoCadastroId
            };

            return View(pedidoCadastro);
        }

    }
}

