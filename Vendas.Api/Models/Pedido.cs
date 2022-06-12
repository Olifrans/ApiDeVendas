using Dapper.Contrib.Extensions;

namespace Vendas.Api.Models
{
    [Table("pedido")]
    public class Pedido : BaseModel
    {
        //[ExplicitKey] //Passando o Id de forma manual

        //public Pedido()
        //{
        //    Itens = new List<PedidoItem>();
        //}

        public int Nr_Pedido { get; set; }

        public DateTime Data { get; set; }
        public string? Tipo { get; set; }

        public Cliente Cliente { get; set; }
        public List<PedidoItem> Itens { get; set; }

      
    }
}