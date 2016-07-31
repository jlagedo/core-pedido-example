using Pedido.Model.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Model.Services
{
    public interface IPedidoCadastroService
    {
        Task<PedidoCadastro> RegistrarAsync(RegistroPedidoCadastroCommand command);
        Task<PedidoCadastro> PesquisarAsync(int id);
        Task<List<PedidoCadastro>> ListarTopPorData(int top, string nome);
    }
}
