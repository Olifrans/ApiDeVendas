using Vendas.Api.Models;
using Vendas.Api.Responses;

namespace Vendas.Api.Repositories
{
    public static class ClientesRepository
    {
        public static ReturnResponse Gravar(Cliente cliente)
        {
            try
            {
                BaseRepository.Command(cliente);
                return new ReturnResponse(200, $"O Cliente {cliente.Nome} cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar o cliente", ex.Message));
            }
        }

        public static ReturnResponse Atualizar(Cliente cliente)
        {
            try
            {
                BaseRepository.Command(cliente, true);
                return new ReturnResponse(200, $"O Cliente {cliente.Nome} atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizar o cliente", ex.Message));
            }
        }

        public static ReturnResponse Delete(int id)
        {
            try
            {
                BaseRepository.Delete<Cliente>(id);
                return new ReturnResponse(200, $"Cliente excluido da base de dados?");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao excluir o cliente", ex.Message));
            }
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