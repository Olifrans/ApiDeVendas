using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Models;
using Vendas.Api.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        // GET: api/<PedidosController>
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var getPedido = new Pedido()
            {
                Nr_Pedido = 1,
                Cliente = new Cliente(),
                DT_Pedido = DateTime.Now,
                Tipo = "V",
                Itens = new List<PedidoItem>()
            };

            var getPedido2 = new Pedido()
            {
                Nr_Pedido = 2,
                Cliente = new Cliente(),
                DT_Pedido = DateTime.Now,
                Tipo = "V",
                Itens = new List<PedidoItem>()
            };

            var pedidos = new List<Pedido>();
            pedidos.Add(getPedido);
            pedidos.Add(getPedido2);

            return pedidos;
        }

        // GET api/<PedidosController>/5
        [HttpGet("{nr_pedido}")]
        public ActionResult<Pedido> Get(int nr_pedido)
        {
            var getPedido = new Pedido()
            {
                Nr_Pedido = 1,
                Cliente = new Cliente(),
                DT_Pedido = DateTime.Now,
                Tipo = "V",
                Itens = new List<PedidoItem>()
            };
            return getPedido;
        }

        // POST api/<PedidosController>
        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] Pedido pedidoRequest)
        {
            var postPedido = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados cadastrado com sucesso"
            };
            return postPedido;
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] Pedido pedidoRequest)
        {
            var putPedido = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados atualizado com sucesso"
            };
            return putPedido;
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(string id)
        {
            var deletePedido = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados excluido com sucesso"
            };
            return deletePedido;
        }
    }
}
