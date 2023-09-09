//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Pro.Business.Interfaces;
//using Pro.WebAPI.ViewModels;

//namespace Pro.WebAPI.Endpoints.Client
//{
//    public class AdicionarCliente : ControllerBase
//    {
//        private readonly IClienteService _clienteService;
//        private readonly IMapper _mapper;
//        public AdicionarCliente(
//            IMapper mapper,
//            IClienteService clienteService)
//        {
//            _mapper = mapper;
//            _clienteService = clienteService;
//        }

//        [HttpPost]
//        [Route("api/AdicionarCliente")]
//        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel, [FromServices] IMapper _mapper)
//        {
//            if (!ModelState.IsValid) { return BadRequest(ModelState); }

//            await _clienteService.Adicionar(_mapper.Map<Business.Models.Cliente>(clienteViewModel));

//            return Ok(clienteViewModel);
//        }
//    }
//}
