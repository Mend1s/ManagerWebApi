using Pro.Business.Interfaces;
using Pro.Business.Models;
using Pro.Business.Models.Validations;

namespace Pro.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(INotificador notificador,
                              IEnderecoRepository enderecoRepository,
                              IClienteRepository clienteRepository) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)
                || !ExecutarValidacao(new EnderecoValidation(), cliente.Endereco)) return false;

            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento).Result.Any())
            {
                Notificar("Já existe um cliente com este documento informado.");
                return false;
            }

            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento && c.Id != cliente.Id).Result.Any())
            {
                Notificar("Já existe um cliente com este documento informado.");
                return false;
            }

            await _clienteRepository.Atualizar(cliente);
            return true;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(int id)
        {
            //if (_clienteRepository.ObterClienteEndereco(id).Result.Enderecos.Any())
            //{
            //    Notificar("O cliente possui endereços cadastrados!");
            //    return false;
            //}

            var endereco = await _enderecoRepository.ObterEnderecoPorCliente(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _clienteRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
