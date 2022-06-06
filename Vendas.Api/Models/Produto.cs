namespace Vendas.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}