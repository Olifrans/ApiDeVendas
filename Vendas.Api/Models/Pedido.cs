namespace Vendas.Api.Models
{
    public class Pedido
    {
        public int Nr_Pedido { get; set; }
        public DateTime DT_Pedido { get; set; }
        public string? Tipo { get; set; }
        public Cliente Cliente { get; set; }

        public List<PedidoItem> Itens { get; set; }
    }
}