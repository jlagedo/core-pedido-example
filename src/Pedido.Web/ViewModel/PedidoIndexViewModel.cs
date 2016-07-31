using System.Collections.Generic;

namespace Pedido.Web.ViewModel
{
    public class PedidoIndexViewModel
    {
        public List<PedidoIndexItemViewModel> Pedidos { get; set; }

        public PedidoIndexViewModel()
        {
            Pedidos = new List<PedidoIndexItemViewModel>();
        }
    }
}
