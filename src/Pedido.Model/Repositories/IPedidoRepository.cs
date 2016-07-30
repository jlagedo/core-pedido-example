using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Model.Repositories
{
    public interface IPedidoRepository
    {
        Task<PedidoCadastro> Insert(PedidoCadastro pedidoCadastro);
    }
}
