using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Api.Request
{
    public class PedidoRequest
    {
        public int Nr_Pedido { get; set; }
        public DateTime DT_Pedido { get; set; }
        public string? Tipo { get; set; }
        public ClienteRequest Cliente { get; set; }
        public List<PedidoItemRequest> Itens { get; set; }
    }
}
