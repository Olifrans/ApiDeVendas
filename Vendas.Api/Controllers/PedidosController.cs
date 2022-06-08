using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Models;
using Vendas.Api.Request;
using Vendas.Api.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        //[HttpGet]
        //public ActionResult<List<PedidoResponse>> Get()
        //{
        //    var getPedidoResponse = new PedidoResponse()
        //    {
        //        Nr_PedidoResponse = "1",
        //        Cliente = new Cliente().ToString(),
        //        DT_PedidoResponse = DateTime.Now.ToString(),
        //        Tipo = "V",
        //        Itens = new List<PedidoResponseItem>().ToString(),
        //    };

        //    var getPedidoResponse2 = new PedidoResponse()
        //    {
        //        Nr_PedidoResponse = "2",
        //        Cliente = new Cliente().ToString(),
        //        DT_PedidoResponse = DateTime.Now.ToString(),
        //        Tipo = "V",
        //        Itens = new List<PedidoResponseItem>().ToString(),
        //    };

        //    var PedidoResponses = new List<PedidoResponse>();
        //    PedidoResponses.Add(getPedidoResponse);
        //    PedidoResponses.Add(getPedidoResponse2);

        //    return PedidoResponses;
        //}


        //[HttpGet("{nr_PedidoResponse}")]
        //public ActionResult<PedidoResponse> Get(int nr_PedidoResponse)
        //{
        //    var getPedidoResponse = new PedidoResponse()
        //    {
        //        Nr_PedidoResponse = "2",
        //        Cliente = new Cliente().ToString(),
        //        DT_PedidoResponse = DateTime.Now.ToString(),
        //        Tipo = "V",
        //        Itens = new List<PedidoResponseItem>().ToString(),
        //    };
        //    return getPedidoResponse;
        //}


        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] PedidoRequest pedidoRequest)
        {
            var postPedidoRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados cadastrado com sucesso"
            };
            return postPedidoRequest;
        }

        // PUT api/<PedidoRequestsController>/5
        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] PedidoRequest pedidoRequest)
        {
            var putPedidoRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados atualizado com sucesso"
            };
            return putPedidoRequest;
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
