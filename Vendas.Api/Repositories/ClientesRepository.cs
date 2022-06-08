using Vendas.Api.Models;
namespace Vendas.Api.Repositories
{
    public static class ClientesRepository
    {
        public static void Gravar(Cliente cliente)
        {
            BaseRepository.Command(cliente);
        }

        public static void Atualizar(Cliente cliente)
        {
            BaseRepository.Command(cliente, true);
        }

        public static void Delete(int id)
        {
            BaseRepository.Delete<Cliente>(id);
        }

        public static List<Cliente> Buscar(int id = 0, string nome = "")
        {
            string sql = "select * from cliente";

            if (id > 0)
            {
                sql += " where id = @idCliente";
            }

            if (!string.IsNullOrEmpty(nome))
            {
                if (sql.Contains("where"))
                    sql += " and nome like @nomeCliente";
                else
                    sql += " where nome like @nomeCliente";
            }

            var getCliente = BaseRepository.QuerySql<Cliente>(sql, new { idCliente = id, nomeCliente = "%" + nome + "%" });
            return getCliente;
        }
    }
}