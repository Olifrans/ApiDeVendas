using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Mapper;
using Vendas.Api.Models;
using Vendas.Api.Repositories;
using Vendas.Api.Request;
using Vendas.Api.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<PedidoResponse>> Get()
        {
            var getProdutos = PedidosRepository.Buscar().Select(p => PedidoMapper.Mapper(p));
            return getProdutos.ToList();
        }

        //[HttpGet("{id}")]
        //public ActionResult<ProdutoResponse> Get(int Nr_Pedido)
        //{
        //    var getPedidoId = PedidoMapper.Mapper(PedidosRepository.Buscar(Nr_Pedido).FirstOrDefault());
        //    return getPedidoId;
        //}

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest produtoRequest)
        {
            var novoProduto = ProdutoMapper.Mapper(produtoRequest);
            ProdutosRepository.Gravar(novoProduto);

            var retornar = new ReturnResponse()
            {
                Code = 200,
                Message = $"Produto {produtoRequest.Descricao} cadastrado com sucesso"
            };
            return retornar;
        }

        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest produtoRequest)
        {
            var updateProduto = ProdutoMapper.Mapper(produtoRequest);
            ProdutosRepository.Atualizar(updateProduto);

            var retornar = new ReturnResponse()
            {
                Code = 200,
                Message = "Produto atualizado com sucesso"
            };
            return retornar;
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
