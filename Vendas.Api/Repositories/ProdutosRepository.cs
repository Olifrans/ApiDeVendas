using Vendas.Api.Models;

namespace Vendas.Api.Repositories
{
    public static class ProdutosRepository
    {
        public static void Gravar(Produto produto)
        {
        }

        public static void Atualizar(Produto produto)
        {
        }

        public static List<Produto> Buscar(int id, string descricao)
        {
            string sql = "select * from produto";

            if (id > 0)
            {
                sql += " where id = @idProduto";
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                if (sql.Contains("where"))
                    sql += " and descricao like @descricaoProduto";
                else
                    sql += " where descricao like @descricaoProduto";
            }

            var getProduto = BaseRepository.QuerySql<Produto>(sql, new { idProduto = id, descricaoProduto = "%" + descricao + "%" });
            return getProduto;
        }
    }
}