using Microsoft.AspNetCore.Mvc;
using Vendas.Api.Models;
using Vendas.Api.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var getCliente = new Cliente()
            {
                Id = 1,
                Nome = "Olifrans",
                Email = "olifrans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20)
            };

            var getCliente2 = new Cliente()
            {
                Id = 1,
                Nome = "Frans",
                Email = "frans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20)
            };

            var clientes = new List<Cliente>();
            clientes.Add(getCliente);
            clientes.Add(getCliente2);

            return clientes;

        }



        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(string id)
        {
            var getCliente = new Cliente()
            {                
                Id = 1,
                Nome = "Frans",
                Email = "frans@gmail",
                DT_Nascimento = DateTime.Now.AddYears(-20)
            };
            return getCliente;
        }

        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] Cliente clienteRequest)
        {
            var createCliente = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados cadastrado com sucesso"
            };
            return createCliente;
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public ActionResult<ReturnResponse> Put([FromBody] Cliente clienteRequest)
        {
            var putCliente = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados atualizado com sucesso"
            };
            return putCliente;
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            var deletCliente = new ReturnResponse()
            {
                Code = 200,
                Message = "Dados excluido com sucesso"
            };
            return deletCliente;
        }
    }
}
