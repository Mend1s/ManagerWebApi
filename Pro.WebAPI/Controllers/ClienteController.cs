using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pro.Business.Interfaces;
using Pro.Business.Models;
using Pro.WebAPI.ViewModels;

namespace Pro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public ClienteController(
            IClienteRepository clienteRepository,
            IClienteService clienteService,
            IEnderecoRepository enderecoRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ListClientes()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodosComEnderecos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(int id)
        {
            var cliente = await ObterClienteEndereco(id);

            if (cliente == null) { return NotFound(); }

            return cliente;
        }

        [HttpPost]
        [Route("api/AdicionarCliente")]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel, [FromServices] IMapper _mapper)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            await _clienteService.Adicionar(_mapper.Map<Business.Models.Cliente>(clienteViewModel));

            return Ok(clienteViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) { return BadRequest(); }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            return Ok(clienteViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> Excluir(int id)
        {
            var clienteViewModel = await ObterClienteEndereco(id);

            if (clienteViewModel == null) return NotFound();

            await _clienteService.Remover(id);

            return CustomResponse(clienteViewModel);
        }

        [HttpGet("endereco/{id:int}")]
        public async Task<EnderecoViewModel> ObterEnderecoPorId(int id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
        }

        [HttpGet]
        [Route("/api/Enderecos")]
        public async Task<IEnumerable<EnderecoViewModel>> ObterTodosEnderecos()
        {
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterTodos());
        }

        [HttpPut("endereco/{id:int}")]
        public async Task<IActionResult> AtualizarEndereco(int id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        private async Task<ClienteViewModel> ObterClienteEndereco(int id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteEndereco(id));
        }
    }
}
