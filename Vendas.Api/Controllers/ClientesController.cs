using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Mapper;
using Vendas.Api.Repositories;
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
            var getClientes = ClientesRepository.Buscar().Select(p => ClienteMapper.Mapper(p));
            return getClientes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteResponse> Get(int id)
        {
            var getClienteId = ClienteMapper.Mapper(ClientesRepository.Buscar(id).FirstOrDefault());
            return getClienteId;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ClienteRequest clienteRequest)
        {
            var novoCliente = ClienteMapper.Mapper(clienteRequest);
            ClientesRepository.Gravar(novoCliente);

            var retornar = new ReturnResponse()
            {
                Code = 200,
                Message = $"Cliente {clienteRequest.Nome} cadastrado com sucesso"
            };
            return retornar;
        }

        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] ClienteRequest clienteRequest)
        {
            var updateCliente = ClienteMapper.Mapper(clienteRequest);
            ClientesRepository.Atualizar(updateCliente);

            var retornar = new ReturnResponse()
            {
                Code = 200,
                Message = $"O cliente {clienteRequest.Nome} foi atualizado com sucesso"
            };
            return retornar;
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            ClientesRepository.Delete(id);
            var deleteCliente = new ReturnResponse()
            {
                Code = 200,
                Message = $"O cliente {(id)} será excluido definitivamente da base de dados"
            };
            return deleteCliente;
        }
    }
}