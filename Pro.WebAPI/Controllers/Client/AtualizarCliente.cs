//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Pro.Business.Interfaces;
//using Pro.Business.Models;
//using Pro.WebAPI.ViewModels;

//namespace Pro.API.Endpoints.Client
//{
//    public class AtualizarCliente : ControllerBase
//    {
//        private readonly IMapper _mapper;
//        private readonly IClienteService _clienteService;

//        public AtualizarCliente(
//            IClienteService clienteService,
//            IMapper mapper)
//        {
//            _mapper = mapper;
//            _clienteService = clienteService;
//        }

//        [HttpPut("{id:int}")]
//        public async Task<ActionResult<ClienteViewModel>> Atualizar(int id, ClienteViewModel clienteViewModel)
//        {
//            if (id != clienteViewModel.Id) { return BadRequest(); }

//            //if (!ModelState.IsValid) return CustomResponse(ModelState);

//            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

//            return Ok(clienteViewModel);
//        }
//    }
//}
