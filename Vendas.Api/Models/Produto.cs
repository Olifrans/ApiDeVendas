namespace Vendas.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Descrcao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}