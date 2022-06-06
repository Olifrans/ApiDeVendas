using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Mapper;
using Vendas.Api.Models;
using Vendas.Api.Request;
using Vendas.Api.Responses;



namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteRequestsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteResponse>> Get()
        {
            var cliente = new Cliente()
            {
                Id = 1,
                Nome = "Olifrans",
                Email = "olifrans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20),
            };

            var cliente2 = new Cliente()
            {
                Id = 2,
                Nome = "Frans",
                Email = "frans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20),
            };

            var clienteResponses = new List<ClienteResponse>();
            clienteResponses.Add(ClienteMapper.Mapper(cliente));
            clienteResponses.Add(ClienteMapper.Mapper(cliente2));

            return clienteResponses;

        }


        [HttpGet("{id}")]
        public ActionResult<ClienteResponse> Get(string id)
        {
            var getClienteResponset = new ClienteResponse()
            {                
                Id = "1",
                Nome = "Frans",
                Email = "frans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20).ToString(),
            };
            return getClienteResponset;
        }

 
        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ClienteRequest clienteRequest)
        {
            var novoClienteRequest = ClienteMapper.Mapper(clienteRequest);
            var createClienteRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados cadastrado com sucesso"
            };
            return createClienteRequest;
        }

   
        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] ClienteRequest clienteRequest)
        {
            var putClienteRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados atualizado com sucesso"
            };
            return putClienteRequest;
        }


        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            var deletClienteRequest = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados excluido com sucesso"
            };
            return deletClienteRequest;
        }
    }
}
