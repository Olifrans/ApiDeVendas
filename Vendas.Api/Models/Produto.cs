using Dapper.Contrib.Extensions;

namespace Vendas.Api.Models
{
    [Table("produto")]
    public class Produto : BaseModel
    {
        [ExplicitKey] //Passando o Id de forma manual
        //[Key] Id gerado de forma automatico pelo BD
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}