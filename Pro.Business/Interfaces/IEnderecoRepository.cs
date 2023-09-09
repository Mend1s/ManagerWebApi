using Pro.Business.Models;

namespace Pro.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorCliente(int clienteId);

    }
}
