using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using Vendas.Api.Models;
using System.Linq;

namespace Vendas.Api.Repositories
{
    public static class BaseRepository
    {
        //ConnectionString  getList<Pedido>
        public const string ConnectionString = "Server=V-DEVSERVER;Database=ApiDeVendas;Trusted_Connection=True;";


        //Get
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> querySelect;

            using (var connection = new SqlConnection("Server=V-DEVSERVER;Database=ApiDeVendas;Trusted_Connection=True;"))
            {
                querySelect = connection.Query<T>(sql, parameter).ToList();
            }
            return querySelect;
        }

        //Delete
        public static void Delete<T>(int id) where T : BaseModel
        {
            using (var connection = new SqlConnection("Server=V-DEVSERVER;Database=ApiDeVendas;Trusted_Connection=True;"))
            {
                string queryDelete = $"select * from {typeof(T).Name} where id = @id";
                var objeto = connection.Query<T>(queryDelete, new { id });
                connection.Delete(objeto);
            }
        }

        //Post e Put
        public static void Command<T>(T objeto, bool editar = false, object parameter = null) where T : BaseModel
        {
            using (var connection = new SqlConnection("Server=V-DEVSERVER;Database=ApiDeVendas;Trusted_Connection=True;"))
            {
                if (editar)
                    connection.Update(objeto);
                else
                    connection.Insert(objeto);
            }
        }
    }
}