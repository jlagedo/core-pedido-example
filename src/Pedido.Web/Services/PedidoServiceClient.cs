using Microsoft.Extensions.Options;
using Pedido.Web.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pedido.Web.Services
{
    public class PedidoServiceClient : IPedidoServiceClient
    {
        private readonly IOptions<PedidoService> settings;

        public PedidoServiceClient(IOptions<PedidoService> settings)
        {
            this.settings = settings;
        }

        private HttpClient BuildClient()
        {            
            var client = new HttpClient();
            client.BaseAddress = new Uri(settings.Value.URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<PedidoCadastroDTO> PesquisaPorIdAsync(int id)
        {
            using (var client = BuildClient())
            {
                var response = await client.GetAsync($"/api/pedido?id={id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<PedidoCadastroDTO>();
            }

        }

        public async Task RegistrarAsync(PedidoCadastroDTO pedido)
        {
            using (var client = BuildClient())
            {
                var response = await client.PostAsJsonAsync("/api/pedido", pedido);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
