using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Api.Repositories
{
    public static class BaseRepositories
    {
        public static List<T>  QuerySql<T>(string sql, object[] parameter)
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
