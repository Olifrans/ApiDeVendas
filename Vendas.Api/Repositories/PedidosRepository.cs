using Dapper;
using System.Data.SqlClient;
using Vendas.Api.Models;

namespace Vendas.Api.Repositories
{
    public static class PedidosRepository
    {
        public static void Gravar(Pedido pedido)
        {
            BaseRepository.Command(pedido);
        }

        public static void Atualizar(Pedido pedido)
        {
            BaseRepository.Command(pedido, true);
        }

        public static void Delete(int id)
        {
            BaseRepository.Delete<Pedido>(id);
        }

        public static List<Pedido> Buscar(int nrpedido = 0, int clienteId = 0)
        {
            string sql = @"select
                            p.NumeroPedido as Nr_Pedido,
                            p.Data,
                            p.Tipo,
                            p.id_cliente,
                            c.Id,
                            c.Nome,
                            c.Email,
                            c.DT_Nascimento
                            from Pedido p
                            join Cliente c on p.id_cliente = c.Id";

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

            List<Pedido> querySelect;
            using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            {
                querySelect = connection.Query<Pedido, Cliente, Pedido>(sql, map: mapeiaPropriedades, splitOn: "id", param: new { Nrpedido = nrpedido, Id_cliente = clienteId }).ToList();
            }

            const string sqlitem = @"select * from pedidoitem where NumeroPedido = @NumeroPedido";

            foreach (var item in querySelect)
            {
                using (var connection = new SqlConnection(BaseRepository.ConnectionString))
                {
                    item.Itens.AddRange(connection.Query<PedidoItem>(sqlitem, param: new { NumeroPedido = item.Nr_Pedido }).ToList());
                }
            }

            return querySelect;
        }

        private static Pedido mapeiaPropriedades(Pedido pedido, Cliente cliente)
        {
            pedido.Cliente = cliente;
            return pedido;
        }
    }
}