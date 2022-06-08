using Vendas.Api.Models;
using Vendas.Api.Request;
using Vendas.Api.Responses;

namespace Vendas.Api.Mapper
{
    public static class PedidoItemMapper
    {
        public static PedidoItem Mapper(PedidoItemRequest pedidoItemRequest)
        {
            return new PedidoItem()
            {
                Id = pedidoItemRequest.Id,
                Quantidade = pedidoItemRequest.Quantidade,
                Valor_Unitario = pedidoItemRequest.Valor_Unitario,
                //Produto = pedidoItemRequest.Produto.ToString(),               
            };
        }


        public static PedidoItemResponse Mapper(PedidoItem pedidoItem)
        {
            return new PedidoItemResponse()
            {

                Id = pedidoItem.Id.ToString(),
                Quantidade = pedidoItem.Quantidade.ToString(),
                Valor_Unitario = pedidoItem.Valor_Unitario.ToString(),
                //Produto = pedidoItem.Produto.ToString(),   
            };
        }
    }
}