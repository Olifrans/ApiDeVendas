using Vendas.Api.Models;
using Vendas.Api.Request;
using Vendas.Api.Responses;

namespace Vendas.Api.Mapper
{
    public static class PedidoMapper
    {
        public static Pedido Mapper(PedidoRequest pedidoRequest)
        {
            return new Pedido()
            {
                Nr_Pedido = pedidoRequest.Nr_Pedido,
                Tipo = pedidoRequest.Tipo,
                Data = pedidoRequest.DT_Pedido,
                Cliente = ClienteMapper.Mapper(pedidoRequest.Cliente),
                Itens = pedidoRequest.Itens.Select(p => PedidoItemMapper.Mapper(p)).ToList()
            };
        }

        public static PedidoResponse Mapper(Pedido pedido)
        {
            return new PedidoResponse()
            {
                Nr_Pedido = pedido.Nr_Pedido.ToString(),
                Tipo = pedido.Tipo.ToString(),
                DT_Pedido = pedido.Data.ToString(),
                Cliente = ClienteMapper.Mapper(pedido.Cliente),
                Itens = pedido.Itens.Select(p => PedidoItemMapper.Mapper(p)).ToList()
            };
        }
    }
}