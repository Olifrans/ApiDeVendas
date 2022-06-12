using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Mapper;
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
            var getProdutos = ProdutosRepository.Buscar().Select(p => ProdutoMapper.Mapper(p));
            return getProdutos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoResponse> Get(int id)
        {
            var getProdutoId = ProdutoMapper.Mapper(ProdutosRepository.Buscar(id).FirstOrDefault());
            return getProdutoId;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest produtoRequest)
        {
            var novoProduto = ProdutoMapper.Mapper(produtoRequest);
            return ProdutosRepository.Gravar(novoProduto);
        }

        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest produtoRequest)
        {
            var updateProduto = ProdutoMapper.Mapper(produtoRequest);
            return ProdutosRepository.Atualizar(updateProduto);
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            return ProdutosRepository.Delete(id);
        }
    }
}