//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Pro.Business.Interfaces;
//using Pro.WebAPI.ViewModels;

//namespace Pro.WebAPI.Endpoints.Cliente
//{
//    public class ObterTodosClientes : ControllerBase
//    {
//        private readonly IClienteRepository _clienteRepository;
//        private readonly IMapper _mapper;

//        public ObterTodosClientes(
//            IMapper mapper,
//            IClienteRepository clienteRepository)
//        {
//            _mapper = mapper;
//            _clienteRepository = clienteRepository;
//        }

//        [HttpGet]
//        [Route("api/ObterTodosClientes")]
//        public async Task<IEnumerable<ClienteViewModel>> ListClientes()
//        {
//            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodosComEnderecos());
//        }
//    }
//}
