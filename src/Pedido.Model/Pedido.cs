using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Model
{
    public class PedidoCadastro
    {
        public int PedidoCadastroId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid Guid { get; set; }
        public int IdPessoa { get; set; }
    }
}
