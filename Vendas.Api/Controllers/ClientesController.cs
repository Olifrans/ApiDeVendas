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
            return ClientesRepository.Gravar(novoCliente);
        }

        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] ClienteRequest clienteRequest)
        {
            var updateCliente = ClienteMapper.Mapper(clienteRequest);
            return ClientesRepository.Atualizar(updateCliente);
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            return ClientesRepository.Delete(id);
        }
    }
}