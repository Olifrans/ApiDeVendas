using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Api.Responses
{
    public class ProdutoResponse
    {
        public string? Id { get; set; }
        public string? Descricao { get; set; }
        public string? Estoque { get; set; }
        public string? Valor { get; set; }
    }
}
