using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Models;
using Vendas.Api.Responses;

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            var getProduto = new Produto()
            {
                Id = 1,
                Descricao = "Dell",
                Estoque = 10,
                Valor = 350
            };

            var getProduto2 = new Produto()
            {
                Id = 2,
                Descricao = "Lenovo",
                Estoque = 10,
                Valor = 350
            };

            var produtos = new List<Produto>();
            produtos.Add(getProduto);
            produtos.Add(getProduto2);

            return produtos;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(string id)
        {
            var getProduto = new Produto()
            {
                Id = 3,
                Descricao = "Nokia",
                Estoque = 25,
                Valor = 350
            };
            return getProduto;
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] Produto produtoRequest)
        {
            var createProduto = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados cadastrado com sucesso"
            };
            return createProduto;
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] Produto produtoRequest)
        {
            var putProduto = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados atualizado com sucesso"
            };
            return putProduto;
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            var deletProduto = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados excluido com sucesso"
            };
            return deletProduto;
        }
    }
}