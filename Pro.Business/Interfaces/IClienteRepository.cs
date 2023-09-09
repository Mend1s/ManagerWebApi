using Pro.Business.Models;

namespace Pro.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteEndereco(int id);
        Task<List<Cliente>> ObterTodosComEnderecos();
    }
}
