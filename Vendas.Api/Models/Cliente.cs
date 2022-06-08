using Dapper.Contrib.Extensions;

namespace Vendas.Api.Models
{
    [Table("cliente")]
    public class Cliente : BaseModel
    {
        [ExplicitKey] //Passando o Id de forma manual
        //[Key] Id gerado de forma automatico pelo BD
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DT_Nascimento { get; set; }
    }
}