//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Pro.Business.Interfaces;
//using Pro.WebAPI.ViewModels;

//namespace Pro.API.Endpoints.Client
//{
//    public class ObterClientePorId : ControllerBase
//    {
//        private readonly IClienteRepository _clienteRepository;
//        private readonly IMapper _mapper;
//        public ObterClientePorId(
//            IMapper mapper,
//            IClienteRepository clienteRepository)
//        {
//            _clienteRepository = clienteRepository;
//            _mapper = mapper;
//        }
//        [HttpGet("api/ObterCliente/{id:int}")]
//        public async Task<ActionResult<ClienteViewModel>> ObterPorId(int id)
//       {
//            var cliente = await ObterClienteEndereco(id);

//            if (cliente == null) { return NotFound(); }

//            return cliente;
//        }

//        private async Task<ClienteViewModel> ObterClienteEndereco(int id)
//        {
//            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteEndereco(id));
//        }
//    }
//}
