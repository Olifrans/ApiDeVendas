using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static IList<Produto> Buscar(int id, string descricao)
        {
            string sql = "select * from";

            var getProduto = BaseRepository.QuerySql<Produto>(sql);
            return getProduto;            
        }

    }
}
