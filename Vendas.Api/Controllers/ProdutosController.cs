using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Models;
using Vendas.Api.Repositories;
using Vendas.Api.Request;
using Vendas.Api.Responses;

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoResponse>> Get()
        {
            return ProdutosRepository.Buscar(0, "");

            //var produtoResponses = new List<ProdutoResponse>();
            //produtoResponses.Add(getProdutoResponse);
            //produtoResponses.Add(getProdutoResponse2);

            //return produtoResponses;
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoResponse> Get(string id)
        {
            var getProdutoResponse = new ProdutoResponse()
            {
                Id = 3,
                Descricao = "Nokia",
                Estoque = 25,
                Valor = 350
            };
            return getProdutoResponse;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest produtoRequest)
        {
            var createProdutoRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados cadastrado com sucesso"
            };
            return createProdutoRequest;
        }

        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest produtoRequest)
        {
            var putProdutoRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados atualizado com sucesso"
            };
            return putProdutoRequest;
        }


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