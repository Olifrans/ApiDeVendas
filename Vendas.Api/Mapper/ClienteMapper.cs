using Vendas.Api.Models;
using Vendas.Api.Request;
using Vendas.Api.Responses;

namespace Vendas.Api.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente Mapper(ClienteRequest clienteRequest)
        {
            return new Cliente()
            {
                Id = clienteRequest.Id,
                Nome = clienteRequest.Nome,
                Email = clienteRequest.Email,
                DT_Nascimento = clienteRequest.DT_Nascimento,
            };
        }

        public static ClienteResponse Mapper(Cliente cliente)
        {
            return new ClienteResponse()
            {
                Id = cliente.Id.ToString(),
                Nome = cliente.Nome,
                Email = cliente.Email,
                DT_Nascimento = cliente.DT_Nascimento.ToString(),
            };
        }
    }
}