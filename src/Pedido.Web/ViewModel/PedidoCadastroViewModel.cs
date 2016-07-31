using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Web.ViewModel
{
    public class PedidoCadastroViewModel
    {
        public int PedidoCadastroId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid Guid { get; set; }
        public int IdPessoa { get; set; }
    }
}
