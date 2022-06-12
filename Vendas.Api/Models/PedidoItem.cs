using Dapper.Contrib.Extensions;

namespace Vendas.Api.Models
{
    [Table("pedidoitem")]
    public class PedidoItem : BaseModel
    {
        [ExplicitKey] //Passando o Id de forma manual
        //[Key] Id gerado de forma automatico pelo BD
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_Unitario { get; set; }

        public Produto? Produto { get; set; }
    }
}