using System;

namespace Pedido.Web.ViewModel
{
    public class PedidoIndexItemViewModel
    {
        public int PedidoCadastroId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid Guid { get; set; }
        public int IdPessoa { get; set; }
    }
}