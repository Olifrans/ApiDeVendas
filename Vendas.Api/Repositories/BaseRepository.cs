using Dapper;
using System.Data.SqlClient;

namespace Vendas.Api.Repositories
{
    public static class BaseRepository
    {
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> querySelect;

            using (var connection = new SqlConnection("Server=V-DEVSERVER;Database=ApiDeVendas;Trusted_Connection=True;"))
            {
                querySelect = connection.Query<T>(sql, parameter).ToList();
            }
            return querySelect;
        }
    }
}