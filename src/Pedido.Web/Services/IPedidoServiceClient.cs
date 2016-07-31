using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Web.Services
{
    public interface IPedidoServiceClient
    {
        Task<PedidoCadastroDTO> PesquisaPorIdAsync(int id);
        Task RegistrarAsync(PedidoCadastroDTO pedido);
    }
}
