using Vendas.Api.Models;
using Vendas.Api.Request;
using Vendas.Api.Responses;

namespace Vendas.Api.Mapper
{
    public static class ProdutoMapper
    {
        public static Produto Mapper(ProdutoRequest produtoRequest)
        {
            return new Produto()
            {
                Id = produtoRequest.Id,
                Descricao = produtoRequest.Descricao,
                //Estoque = produtoRequest.Estoque,
                Valor = produtoRequest.Valor,
            };
        }

        public static ProdutoResponse Mapper(Produto Produto)
        {
            return new ProdutoResponse()
            {
                Id = Produto.Id.ToString(),
                Descricao = Produto.Descricao,
                Estoque = Produto.Estoque.ToString(),
                Valor = Produto.Valor.ToString(),
            };
        }
    }
}