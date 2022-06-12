using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using Vendas.Api.Models;

namespace Vendas.Api.Repositories
{
    public static class BaseRepository
    {
        //ConnectionString  getList<Pedido>
        private const string ConnectionString = "Server=V-DEVSERVER;Database=ApiDeVendas;Trusted_Connection=True;";

        //GetAll
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> querySelect;
            using (var connection = new SqlConnection(ConnectionString))
            {
                querySelect = connection.Query<T>(sql, parameter).ToList();
            }
            return querySelect;
        }

        //Post e Put
        public static void Command<T>(T objeto, bool editar = false, object parameter = null) where T : BaseModel
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (editar)
                    connection.Update(objeto);
                else
                    connection.Insert(objeto);
            }
        }

        //Delete
        public static void Delete<T>(int id) where T : BaseModel
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var tabela = typeof(T).Name;
                string queryDelete = $"select * from {tabela} where {BuscarColunaChave(tabela)} = @id";
                var objeto = connection.Query<T>(queryDelete, new { id });
                connection.Delete(objeto);
            }
        }

        private static string BuscarColunaChave(string nomeTabela)
        {
            //Busca chave primaria de uma tabela
            string query = @"SELECT Col.Column_Name from
                             INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab,
                             INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col
                             WHERE
                             Col.CONSTRAINT_NAME = Tab.CONSTRAINT_NAME
                             AND Col.TABLE_NAME = Tab.TABLE_NAME
                             AND CONSTRAINT_TYPE = 'Primary key'
                             AND Col.TABLE_NAME = @tablename";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<string>(query, new { tablename = nomeTabela }).FirstOrDefault();
            }
        }
    }
}