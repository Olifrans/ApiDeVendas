using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Mapper;
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
            var getPedidos = PedidosRepository.Buscar().Select(p => PedidoMapper.Mapper(p));
            return getPedidos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<PedidoResponse> Get(int id)
        {
            var getPedidoId = PedidoMapper.Mapper(PedidosRepository.Buscar(id).FirstOrDefault());
            return getPedidoId;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] PedidoRequest pedidoRequest)
        {
            var novoPedido = PedidoMapper.Mapper(pedidoRequest);
            return PedidosRepository.Gravar(novoPedido);
        }

        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] PedidoRequest pedidoRequest)
        {
            var updatePedido = PedidoMapper.Mapper(pedidoRequest);
            return PedidosRepository.Atualizar(updatePedido);
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            return PedidosRepository.Delete(id);
        }
    }
}