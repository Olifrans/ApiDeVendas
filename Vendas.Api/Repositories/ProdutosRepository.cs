using Vendas.Api.Models;
using Vendas.Api.Responses;

namespace Vendas.Api.Repositories
{
    public static class ProdutosRepository
    {
        public static ReturnResponse Gravar(Produto produto)
        {
            try
            {
                BaseRepository.Command(produto);
                return new ReturnResponse(200, $"Produto {produto.Descricao} cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar o produto", ex.Message));
            }
        }

        public static ReturnResponse Atualizar(Produto produto)
        {
            try
            {
                BaseRepository.Command(produto, true);
                return new ReturnResponse(200, $"Produto {produto.Descricao} atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizar o produto", ex.Message));
            }
        }

        public static ReturnResponse Delete(int id)
        {
            try
            {
                BaseRepository.Delete<Produto>(id);
                return new ReturnResponse(200, $"Produto excluido com sucesso");
            }
            catch (Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao excluir o produto", ex.Message));
            }
        }

        public static List<Produto> Buscar(int id = 0, string descricao = "")
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