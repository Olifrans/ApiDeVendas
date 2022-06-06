using Microsoft.AspNetCore.Mvc;
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
            var getClienteRequest = new ClienteResponse()
            {
                Id = "1",
                Nome = "Olifrans",
                Email = "olifrans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20).ToString(),
            };

            var getClienteRequest2 = new ClienteResponse()
            {
                Id = "2",
                Nome = "Frans",
                Email = "frans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20).ToString(),
            };

            var ClienteRequests = new List<ClienteResponse>();
            ClienteRequests.Add(getClienteRequest);
            ClienteRequests.Add(getClienteRequest2);

            return ClienteRequests;

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
