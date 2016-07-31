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
using Microsoft.Extensions.DependencyInjection;

namespace Pedido.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoServiceClient pedidoService;

        public PedidoController(IPedidoServiceClient pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            var listaPedidoDTO = await pedidoService.PesquisaMaisRecentesAsync();

            var vm = new PedidoIndexViewModel();

            foreach (var item in listaPedidoDTO)
            {
                vm.Pedidos.Add(
                    new PedidoIndexItemViewModel
                    {
                        PedidoCadastroId = item.PedidoCadastroId,
                        CPF = item.CPF,
                        Nome = item.Nome,
                        Status = item.Status
                    }
                    );
            }

            return View(vm);
        }

    }
}

