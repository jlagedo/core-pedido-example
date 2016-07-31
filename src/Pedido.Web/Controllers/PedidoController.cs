using Microsoft.AspNetCore.Mvc;
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
        [ResponseCache(Duration =60)]
        public async Task<IActionResult> Index(int id)
        {
            PedidoCadastroViewModel pedidoCadastro = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"/api/pedido?id={id}");
                response.EnsureSuccessStatusCode();

                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                };

                pedidoCadastro = await response.Content.ReadAsAsync<PedidoCadastroViewModel>();
            }

            return View(pedidoCadastro);
        }


        public async Task<IActionResult> RegistrarPedido()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var pedido = new { IdPessoa = 10 };

                var response = await client.PostAsJsonAsync("/api/pedido", pedido);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }

            }

            return Ok();
        }

    }
}

