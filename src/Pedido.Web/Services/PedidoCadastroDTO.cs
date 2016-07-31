using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Web.Services
{
    public class PedidoCadastroDTO
    {
        public int PedidoCadastroId { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public string Status { get; set; }
    }
}
