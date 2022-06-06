using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Api.Request
{
    public class ProdutoRequest
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
