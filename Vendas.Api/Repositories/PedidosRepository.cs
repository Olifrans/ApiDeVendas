using Vendas.Api.Models;
using Vendas.Api.Responses;

namespace Vendas.Api.Repositories
{
    public static class PedidosRepository
    {
        public static ReturnResponse Gravar(Pedido pedido)
        {
            try
            {
                BaseRepository.Command(pedido);
                return new ReturnResponse(200, $"Pedido {pedido.Cliente} realizado com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao realizar o pedido", ex.Message));
            }
        }

        public static ReturnResponse Atualizar(Pedido pedido)
        {
            try
            {
                BaseRepository.Command(pedido, true);
                return new ReturnResponse(200, $"Pedido {pedido.Cliente} atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizado o pedido", ex.Message));
            }
        }

        public static ReturnResponse Delete(int id)
        {
            try
            {
                BaseRepository.Delete<Pedido>(id);
                return new ReturnResponse(200, $"Pedido excluido com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao excluir o pedido", ex.Message));
            }
        }

        public static List<Pedido> Buscar(int nrpedido = 0, int clienteId = 0)
        {
            //string sql = @"select
            //                p.NumeroPedido as Nr_Pedido,
            //                p.Data,
            //                p.Tipo,
            //                p.id_cliente,
            //                c.Id,
            //                c.Nome,
            //                c.Email,
            //                c.DT_Nascimento
            //                from Pedido p
            //                join Cliente c on p.id_cliente = c.Id";

            string sql = "select * from Pedido";

            if (nrpedido > 0)
            {
                sql += " where numeroPedido = @Nrpedido";
            }

            if (clienteId > 0)
            {
                if (sql.Contains("where"))
                    sql += " and id_cliente = @Id_cliente";
                else
                    sql += " where id_cliente = @Id_cliente";
            }

            var retorno = BaseRepository.QuerySql<Pedido>(sql, new { Nrpedido = nrpedido, Id_cliente = clienteId });

            return retorno;

            //List<Pedido> querySelect;
            //using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            //{
            //    querySelect = connection.Query<Pedido, Cliente, Pedido>(sql, map: mapeiaPropriedades, splitOn: "id", param: new { Nrpedido = nrpedido, Id_cliente = clienteId }).ToList();
            //}

            //const string sqlitem = @"select * from pedidoitem where NumeroPedido = @NumeroPedido";

            //foreach (var item in querySelect)
            //{
            //    using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            //    {
            //        item.Itens.AddRange(connection.Query<PedidoItem>(sqlitem, param: new { NumeroPedido = item.Nr_Pedido }).ToList());
            //    }
            //}
            //return querySelect;
        }

        //private static Pedido mapeiaPropriedades(Pedido pedido, Cliente cliente)
        //{
        //    pedido.Cliente = cliente;
        //    return pedido;
        //}
    }
}