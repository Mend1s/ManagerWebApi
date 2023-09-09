using Pro.Business.Models;

namespace Pro.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Cliente cliente);
        Task<bool> Remover(int id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
